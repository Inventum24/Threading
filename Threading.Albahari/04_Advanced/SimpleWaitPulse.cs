using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading.Albahari._04_Advanced
{
    public static class SimpleWaitPulse
    {
        static readonly object _locker = new object();
        static bool _go;

        public static void Run()
        {                                // The new thread will block
            new Thread(Work).Start();     // because _go==false.

            Console.WriteLine("Wait for user to hit Enter");
            Console.ReadLine();            // Wait for user to hit Enter

            lock (_locker)                 // Let's now wake up the thread by
            {                              // setting _go=true and pulsing.
                _go = true;
                Monitor.Pulse(_locker);
            }
        }

        public static void Work()
        {
            lock (_locker)
                while (!_go)
                {
                    Monitor.Wait(_locker);    // Lock is released while we’re waiting
                    var item = 1;             // After puls it starts from 
                }

            Console.WriteLine("Woken!!!");
        }
    }

    public static class SimpleWaitPulseSlim
    {
        static readonly object _locker = new object();
        static bool _go;

        static void Run()
        {
            //If Pulse executes first, the pulse is lost and the worker remains forever stuck.
            //FuckUP!

            //Pulse has no latching effect because you’re expected to write the latch yourself, using a “go” flag as we did before
            new Thread(Work).Start();
            lock (_locker) Monitor.Pulse(_locker);
        }

        static void Work()
        {
            lock (_locker) Monitor.Wait(_locker);
            Console.WriteLine("Woken!!!");
        }
    }
}
