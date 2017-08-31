using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading.ParallelDotNet._26AsParallelAndParallelQuery
{
    public class AsParallelAndParallelQueryExample
    {
        public static void Run()
        {
            const int count = 50;
            var items = Enumerable.Range(1, count).ToArray();
            var results = new int[count];

            items.AsParallel().ForAll(x => {
                int newValue = x * x * x;
                Console.WriteLine($"{newValue} ({Task.CurrentId})");
                results[x - 1] = newValue;
            });

            //foreach (var item in results)
            //{
            //    Console.WriteLine($"{item}\t");
            //}

            var cubes = items.AsParallel().AsOrdered().Select(x => x * x * x); //

            foreach (var item in cubes)
            {
                Console.WriteLine($"{item}\t");
            }

        }
    }
}
