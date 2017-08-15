using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading.ParallelDotNet._02CancellingTask
{
    public class CancellingTask
    {
        public static void Runner()
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            token.Register(() =>
            {
                //.1 Event on cancellation requested.
                Console.WriteLine("That was cancellation requested.");
            });

            var t = new Task(() =>
                {
                    int i = 0;
                    while (true)
                    {
                        ////Soft Exit
                        //if (cts.IsCancellationRequested)
                        //{
                        //    //break;                               //1.
                        //    throw new OperationCanceledException();//2.
                        //} 
                        token.ThrowIfCancellationRequested(); //.3 is equal to .2
                        Console.WriteLine($"{i++}\t");
                    }
                }, token
            );

            t.Start();

            Task.Factory.StartNew(() =>
            {
                token.WaitHandle.WaitOne();
                Console.WriteLine("Wait handle released");
            });

            Console.ReadKey();
            cts.Cancel();
        }

        public static void Runner2()
        {
            var planned = new CancellationTokenSource();
            var preventative = new CancellationTokenSource();
            var emergency = new CancellationTokenSource();

            var paranoid =
                CancellationTokenSource.CreateLinkedTokenSource(planned.Token, preventative.Token, emergency.Token);

            Task.Factory.StartNew(() =>
            {
                int i = 0;
                while (true)
                {
                    paranoid.Token.ThrowIfCancellationRequested();
                    Console.WriteLine($"{i++}\t");
                }
            }, paranoid.Token);

            Console.ReadKey();
            emergency.Cancel();
        }
    }
}
