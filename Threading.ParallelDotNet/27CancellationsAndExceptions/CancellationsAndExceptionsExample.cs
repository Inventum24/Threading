using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading.ParallelDotNet._27CancellationsAndExceptions
{
    public class CancellationsAndExceptionsExample
    {
        public static void Run()
        {
            var cts = new CancellationTokenSource();
            var items = ParallelEnumerable.Range(1,20);

            var results = items.WithCancellation(cts.Token).Select(x =>
            {
                double res = Math.Log10(x);
                //if (res > 1)
                //    throw new InvalidOperationException();
                Console.WriteLine( $"i ={x}, tid = {Task.CurrentId}");
                return res;
            });

            try
            {
                foreach (var item in results)
                {
                    if (item > 1)
                        cts.Cancel();
                    Console.WriteLine($"results = {item}");
                }
            }
            catch (AggregateException ae)
            {
                ae.Handle(e =>
                {
                    Console.WriteLine($"{e.GetType().Name}: {e.Message}");
                    return true;
                });
            }
            catch (OperationCanceledException oce)
            {
                Console.WriteLine("Cancelled");
            }
        }
    }
}
