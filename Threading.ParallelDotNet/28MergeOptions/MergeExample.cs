using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading.ParallelDotNet._28MergeOptions
{
    public class MergeExample
    {
        public static void Run()
        {
            var numbers = Enumerable.Range(1, 20).ToArray();

            var result = numbers
                .AsParallel()
                .WithMergeOptions(ParallelMergeOptions.NotBuffered) //Buffer As soon possible
                .Select(x => {
                var res = Math.Log10(x);
                Console.WriteLine($"P {res}");
                return res;
            });

            foreach (var item in result)
            {
                Console.WriteLine($"C {item}");
            }     
        }
    }
}
