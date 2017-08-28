using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading.ParallelDotNet._12ConcurrentQueue
{
    public class ConcurrentQueueExample
    {
        static ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
        public static void Run()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);

            int result;
            if (queue.TryDequeue(out result))
            {
                Console.WriteLine($"Removed element {result}");
            }

            if (queue.TryPeek(out result))
            {
                Console.WriteLine($"From element is {result}");
            }
        }
    }
}
