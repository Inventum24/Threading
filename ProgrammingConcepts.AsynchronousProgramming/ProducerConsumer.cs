using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgrammingConcepts.AsynchronousProgramming
{
   public class ProducerConsumer
    {

        Queue<int> numbers = new Queue<int>();
        static Random rand = new Random();
        const int NumThreads = 3;
        int[] sums = new int[NumThreads];
        private int totalSum;

        void ProducerNumbers()
        {
            for (int i = 0; i < 10; i++)
            {
                int intToEnquque = rand.Next(10);
                Console.WriteLine("ProducerNumbers adding"+ intToEnquque + "to the queue");
                lock (numbers)
                    numbers.Enqueue(intToEnquque);
                Thread.Sleep(1000);
            }
        }

        void SumNumbers(object threadNumber)
        {
            DateTime startTime = DateTime.Now;

            int mySum = 0;
            while ((DateTime.Now - startTime).Seconds <10)
            {
                var numToSum = -1;
                lock (numbers)
                {
                    if (numbers.Count != 0)
                    {
                        try
                        {
                            numToSum = numbers.Dequeue();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Thread #{threadNumber} having an issue.");
                            throw;
                        }

                        Console.WriteLine("Consuming thread #" + threadNumber + "adding to sum" + numToSum + "to the queue to its total sum making" + numToSum + "fot the thread total.");
                    } 
                }

                if(numToSum > -1)
                mySum += numToSum;
            }

            sums[(int)threadNumber] = mySum;
        }

        void RunProdConsum()
        {
            new Thread(ProducerNumbers).Start();
            var threads = new Thread[NumThreads];

            for (int i = 0; i < NumThreads; i++)
            {
                threads[i] = new Thread(SumNumbers);
                threads[i].Start();
            }
            for (int i = 0; i < NumThreads; i++)
                threads[i].Join();
            for (int i = 0; i < NumThreads; i++)
                totalSum += sums[i];
            Console.WriteLine("Total sum"  + totalSum);
        }
            
    }
}
