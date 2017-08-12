using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgrammingConcepts.AsynchronousProgramming
{
    public class BlockingCollectionSampler
    {
        private static BlockingCollection<int> data = new BlockingCollection<int>();

        private static void Producer()

        {
            for (int ctr = 0; ctr < 10; ctr++)
            {
                data.Add(ctr);

                Thread.Sleep(100);
            }
        }

        private static void Consumer()

        {
            foreach (var item in data.GetConsumingEnumerable())

            {
                Console.WriteLine(item);
            }
        }

        private static void Start()
        {
            var producer = Task.Factory.StartNew(() => Producer());

            var consumer = Task.Factory.StartNew(() => Consumer());

            Console.Read();
        }
    }
}
