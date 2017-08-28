using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading.ParallelDotNet._19CountDown
{
    public class CountDownExample
    {
        private static int taskCount = 5;
        static CountdownEvent cte = new CountdownEvent(taskCount);
        private static Random random = new Random();

        public static void Run()
        {
            for (int i = 0; i < taskCount; i++)
            {
                Task.Factory.StartNew(()=> {
                    Console.WriteLine($"Entering task task {Task.CurrentId}");
                    Thread.Sleep(random.Next(3000));
                    cte.Signal();
                    Console.WriteLine($"Ending task task {Task.CurrentId}");
                });
            }

            var final = Task.Factory.StartNew(() => {
                Console.WriteLine($"Waiting for other task to complete in {Task.CurrentId}");
                cte.Wait();
                Console.WriteLine($"All task completed in {Task.CurrentId}");
            });

            final.Wait();
        }
    }
}
