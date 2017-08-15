using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading.Albahari._02_BasicSynchronization
{
    public class TwoWaySignaling
    {
        static EventWaitHandle _ready = new AutoResetEvent(false);
        static EventWaitHandle _go = new AutoResetEvent(false);
        static readonly object _locker = new object();
        static string _message;

        public static void Run()
        {
            new Thread(Work).Start();

            _ready.WaitOne();                  // First wait until worker is ready
            lock (_locker) _message = "ooo";
            _go.Set();                         // Tell worker to go

            _ready.WaitOne();
            lock (_locker) _message = "ahhh";  // Give the worker another message
            _go.Set();
            _ready.WaitOne();
            lock (_locker) _message = null;    // Signal the worker to exit
            _go.Set();
        }


        //Set daje znać, że może się ruszyć,
        //ale tak naprawdę to należy jeszcze zatrzymać bieżący wątek
        static void Work()
        {
            while (true)
            {
                _ready.Set();                          // Indicate that we're ready
                _go.WaitOne();                         // Wait to be kicked off...
                lock (_locker)
                {
                    if (_message == null) return;        // Gracefully exit
                    Console.WriteLine(_message);
                }
            }
        }
    }
}
