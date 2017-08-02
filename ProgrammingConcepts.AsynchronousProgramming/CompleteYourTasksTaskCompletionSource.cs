using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace ProgrammingConcepts.AsynchronousProgramming
{
    public static class CompleteYourTasksTaskCompletionSource
    {
        public static Task<byte[]> FromWebClient(WebClient wc, Uri address)
        {
            var tcs = new TaskCompletionSource<byte[]>();

            wc.DownloadDataCompleted += (object sender, DownloadDataCompletedEventArgs e) => {
                if (e.Cancelled)
                    tcs.SetCanceled();
                else if (e.Error != null)
                    tcs.SetException(e.Error);
                else
                    tcs.SetResult(e.Result);
            };
            
            wc.DownloadDataAsync(address);

            return tcs.Task;
        }
    }

    internal static class WorkerExp
    {
        private static readonly BlockingCollection<Action> m_actions =
            new BlockingCollection<Action>();

        static WorkerExp()
        {
            Task.Run(() =>
            {
                foreach (var action in m_actions.GetConsumingEnumerable())
                {
                    try {
                            action();
                        } catch (Exception e)
                    { Debug.WriteLine(e); }
                }
            });
        }

        public static void Enqueue(Action action)
        {
            m_actions.Add(action);
        }

        public static void Clear()
        {
            Action dumped;
            while (m_actions.TryTake(out dumped)) ;
        }
    }
}