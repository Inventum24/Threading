using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading.ParallelDotNet.CustomAggregation
{
    public class CustomAggregationExample
    {
        public static void Run()
        {
            //var sum = Enumerable.Range(1, 1000).Sum(); //Not paraller
            //var sum = Enumerable.Range(1, 1000)
            //    .Aggregate(0, (i, acc) =>  i + acc ); //Not paraller

            var sum = ParallelEnumerable.Range(0,1000).Aggregate(
                                                              0,
                                                              (partialSum, i) => partialSum += i,
                                                              (total,subtotal) => total += subtotal,
                                                              i => i
                                                              );

            Console.WriteLine($"Sum = {sum}");

        }
    }
}
