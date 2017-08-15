using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading.ParallelDotNet._04WaitingForTasks
{
    public class WaitingForTasks
    {
        public static void Runner()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            
            var t1 = new Task(() =>
            {
                Console.WriteLine("I take 5 seconds");
                for (int i = 0; i < 5; i++)
                {
                    token.ThrowIfCancellationRequested();
                    Thread.Sleep(1000);
                }
                Console.WriteLine("I'm done. "); 
            },token);

            t1.Start();

            Task t2 = Task.Factory.StartNew(() => Thread.Sleep(3000), token);

            //Task.WaitAll(t1, t2);
            Task.WaitAny(new[] {t1, t2}, 4000,token); //Add token with timeout -> rules changed If changed ThrowIfCancellationRequested Error occures!
            
            Console.WriteLine($"Task t status is {t1.Status}");
            Console.WriteLine($"Task t status is {t2.Status}");
            Console.ReadKey();
        }
    }
}
