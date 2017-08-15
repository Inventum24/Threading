using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgrammingConcepts.AsynchronousProgramming
{
    public class SendQueueSampler
    {
        readonly object _locker = new object();
        private readonly List<int> _SendQueue = new List<int>();

        public void Enqueue(IEnumerable<int> dataEntries)
        {
            _SendQueue.AddRange(dataEntries);
            lock (_locker)
            {
                _SendQueue.AddRange(dataEntries);          // We must pulse because we're
                Monitor.Pulse(_locker);         // changing a blocking condition.
            }

        }
        public async Task Dequeue(Action action, CancellationToken ct)
        {
            while (true)                        // Keep consuming until
            {                                   // told otherwise.
                int item;
                lock (_locker)
                {
                    while (_SendQueue.Count == 0) Monitor.Wait(_locker);
                    item = _SendQueue.Last();
                }
                if (item == null) return;         // This signals our exit.
                action();                           // Execute item.
            }
        }

    }

        /// <summary>
        /// Container for long running tasks
        /// </summary>
        public class TaskContainer : IDisposable
        {
            /// <summary>
            /// Start task event, will be fired when the task has started
            /// </summary>
            public event EventHandler OnTaskStart;

            /// <summary>
            /// Task end event, will be fired when the task has ended
            /// </summary>
            public event EventHandler<EventArgs<TaskEndEvent>> OnTaskEnd;

            // the internal state 
            private InternalTaskContainer _TaskContainer;

            /// <summary>
            /// Create a new task container
            /// </summary>
            /// <param name="name">container/task name</param>
            /// <param name="spawner">the spawn function</param>
            /// <returns></returns>
            public static TaskContainer Create(string name, Func<CancellationToken, Task> spawner)
            {
                if (spawner == null)
                {
                    throw new ArgumentNullException(nameof(spawner));
                }

                var te = new TaskContainer
                {
                    SpawnerFunc = spawner,
                    Name = name
                };
                return te;
            }

            /// <summary>
            /// Start the task
            /// </summary>
            /// <returns></returns>
            public bool Start()
            {
                //return if running?
                if (_TaskContainer != null)
                {
                    return false;
                }

                ForceStart();
                return true;
            }

            // Start new task, independent from acutal task
            private void ForceStart()
            {
                // create new internal task
                var itc = new InternalTaskContainer { Cts = new CancellationTokenSource() };
                itc.Task = Task.Run(() => SpawnerFunc(itc.Cts.Token)).ContinueWith((t) => TaskEnd(this, t));
                //swap and stop old task
                var oldItc = Interlocked.Exchange(ref _TaskContainer, itc);
                Stop(oldItc, WaitTime);
                // event notifier
                OnTaskStart?.Invoke(this, EventArgs.Empty);
            }

            /// <summary>
            /// Restart task
            /// </summary>
            public void Restart()
            {
                Stop();
                Start();
            }

            /// <summary>
            /// Stop the task
            /// </summary>
            public void Stop()
            {
                var itc = Interlocked.Exchange(ref _TaskContainer, null);
                Stop(itc, WaitTime);
            }

            // internal stop/cleanup with timespan
            private static void Stop(InternalTaskContainer itc, TimeSpan waitTime)
            {
                if (itc == null)
                {
                    return;
                }

                try
                {
                    itc.Cts?.Cancel();
                    itc.Task?.Wait(waitTime);
                }
                finally
                {
                    itc.Cts?.Dispose();
                    itc.Task?.Dispose();
                }
            }

            // Handle end (continue) of task 
            private static void TaskEnd(TaskContainer te, Task t)
            {
                if (te == null || t == null)
                {
                    return;
                }

                // prepare task end event 
                var taskEndEvent = new TaskEndEvent
                {
                    AutoRestart = te.AutoRestart,
                    Task = t,
                    Name = te.Name
                };

                // Fire end notification
                te.OnTaskEnd?.Invoke(te, new EventArgs<TaskEndEvent>(taskEndEvent));

                // Check for auto restart
                if (taskEndEvent.AutoRestart)
                {
                    //Avoid deadlock better way?
                    Task.Run(() => te.ForceStart()).ConfigureAwait(false);
                }
                else // cleanup
                {
                    //Avoid deadlock better way?
                    Task.Run(() => te.Stop()).ConfigureAwait(false);
                }
            }

            /// <summary>
            /// Dispose container
            /// </summary>
            public void Dispose()
            {
                try
                {
                    Stop();
                }
                catch (Exception e)
                {
                    // don't throw in dispose
                    Debug.Write(e.ToString());
                }
            }

            /// <summary>
            /// Task name
            /// </summary>
            public string Name { get; internal set; }

            /// <summary>
            /// Get task status
            /// </summary>
            public TaskStatus TaskStatus
            {
                get
                {
                    var itc = _TaskContainer;
                    return itc.Task.Status;
                }
            }

            // function to spawn the task
            private Func<CancellationToken, Task> SpawnerFunc { get; set; }

            /// <summary>
            /// Flag to restart the task when task has ended
            /// </summary>
            public bool AutoRestart { get; set; }

            /// <summary>
            /// Wait time to end tasks
            /// </summary>
            public TimeSpan WaitTime { get; set; } = TimeSpan.FromSeconds(1);

            // internal container for thread safety
            private class InternalTaskContainer
            {
                public Task Task { get; set; }
                public CancellationTokenSource Cts { get; set; }
            }
        }

        /// <summary>
        /// Handle task end event
        /// </summary>
        public class TaskEndEvent
        {
            /// <summary>
            /// Auto restart flag
            /// </summary>
            public bool AutoRestart { get; set; }

            /// <summary>
            /// The corrosponding task
            /// </summary>
            public Task Task { get; set; }

            /// <summary>
            /// The task name
            /// </summary>
            public string Name { get; set; }
        }

        /// <summary>
        /// Generic event args
        /// </summary>
        /// <typeparam name="T">the event value type</typeparam>
        public class EventArgs<T> : System.EventArgs
        {
            /// <summary>
            /// Create new EventArgs with value
            /// </summary>
            /// <param name="value">the event value</param>
            public EventArgs(T value)
            {
                Value = value;
            }

            /// <summary>
            /// Get the value
            /// </summary>
            public T Value { get; }
        }
}

