using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading.ParallelDotNet._05ExceptionHandling
{
    public class ExceptionHandling
    {
        public static void Runner()
        {
            var t1 = Task.Factory.StartNew(
                () =>
                {
                    throw  new InvalidOperationException("Can't do this"){Source = "t1"};
                }
            );
            var t2 = Task.Factory.StartNew(() =>
            {
                throw new AccessViolationException("Can't access this!"){Source = "t2"};
            });

            try
            {
                Task.WaitAll(t1, t2);
            }
            catch (AggregateException ae)
            {
                //foreach (var er in ae.InnerExceptions)
                //{
                //    Console.WriteLine($"Exception type of {er.GetType()} from {er.Source}");
                //}
                ae.Handle((e) =>
                {
                    if (e is InvalidOperationException)
                    {
                        Console.WriteLine("Invalid op!");
                        return true;
                    }
                    return false;
                    
                });

            }
        }
    }
}
