using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading.ParallelDotNet._03WaitingForTimeToPass
{
    public class WaitingForTimeToPass
    {
        /// <summary>
        /// The best runner
        /// </summary>
        public static void Runner()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            var t = new Task(() =>
            {
                //Thread.SpinWait(1000);
                //Thread.SpinWait(1000);
                //SpinWait.SpinUntil();

                Console.WriteLine("Press any key to disarm; you have 5 seconds");
                bool cancelled = token.WaitHandle.WaitOne(5000);
                Console.WriteLine(cancelled?"Bomb disarmed." : "Boom");
            });
            t.Start();
            Console.ReadKey();
            cts.Cancel();
        }

    }
}
