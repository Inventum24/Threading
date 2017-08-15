using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading.Albahari._02_BasicSynchronization
{
    public class BasicWaitHandle
    {
        static EventWaitHandle _waitHandle = new AutoResetEvent(false);

        public static void Run()
        {
            new Thread(Waiter).Start();
            Thread.Sleep(1000);                  // Pause for a second...
            _waitHandle.Set();                    // Wake up the Waiter.
        }

        static void Waiter()
        {
            Console.WriteLine("Waiting...");
            _waitHandle.WaitOne();                // Wait for notification
            Console.WriteLine("Notified");

        }
    }
}
