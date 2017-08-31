using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Collections.Concurrent;

namespace Threading.ParallelDotNet._25Partitioning
{
    public class PartitioningExample
    {
        [Benchmark]
        public void SquareEachValue()
        {
            const int count = 100000;
            var values = Enumerable.Range(0, count);
            var results = new int[count];
            Parallel.ForEach(values, x => { results[x] = (int)Math.Pow(x, 2); });
        }

        [Benchmark]
        public void SquareEachValueChunked()
        {
            const int count = 100000;
            var values = Enumerable.Range(0, count);
            var results = new int[count];
            var part = Partitioner.Create(0, count, 1000);
            Parallel.ForEach(part, range => {
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    results[i] = (int)Math.Pow(i, 2);
                }
            });
        }
        public static void Run()
        {
            var summary = BenchmarkRunner.Run<PartitioningExample>();
            Console.WriteLine(summary); 
        }
    }
}
