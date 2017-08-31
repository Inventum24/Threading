using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading.ParallelDotNet._24ThreadLocalStorage
{
    public class ThreadLocalStorageExample
    {

        public static void Run()
        {
            int sum = 0;
            //Parallel.For(1, 1001, x => {
            //    Interlocked.Add(ref sum, x); // a lot of accesses!!
            //});

            Parallel.For(1, 1001,
                () => 0, //ThreadLocalStorage Init (tls)
                (x, state, tls) => 
                {
                    tls = tls + x;
                    Console.WriteLine($"Task {Task.CurrentId} has sum {tls}");
                    return tls;
                },
                partialSum => {
                    Console.WriteLine($"Partial has sum {partialSum} Task {Task.CurrentId}");
                    Interlocked.Add(ref sum, partialSum);
                });

            Console.WriteLine($"Sum of 1..1000: {sum}");
        }
    }
}
