using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading.ParallelDotNet._23BreakingCancellationsAndExceptions
{
    public static class ParallelBreakingCancellationsAndExceptions
    {
        private static ParallelLoopResult result;
        public static void Demo()
        {
            var cts = new CancellationTokenSource();
            ParallelOptions po = new ParallelOptions();
            po.CancellationToken = cts.Token;

            result =Parallel.For(1,20,po, (int x,ParallelLoopState s)=> {
                Console.WriteLine($"{x}[{Task.CurrentId}]\t");

                if (x == 10) {
                    //throw new Exception();
                    //s.Stop(); //End - only first 10
                    //s.Break(); //10
                    cts.Cancel(); //Unhandle Exceptions
                }
            });

            Console.WriteLine($"Was loop completed? {result.IsCompleted}");
            if (result.LowestBreakIteration.HasValue)
            {
                Console.WriteLine($"LowestBreakIteration {result.LowestBreakIteration}");
            }
        }

        public static void Run()
        {
            try
            {
                Demo();
            }
            catch (AggregateException ae)
            {
                ae.Handle(e =>
                {
                    Console.WriteLine(e.Message);
                    return true;
                });
            }
            catch (Exception e)
            {

            }
        }
    }
}
