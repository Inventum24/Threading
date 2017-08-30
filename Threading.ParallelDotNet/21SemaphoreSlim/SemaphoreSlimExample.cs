using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading.ParallelDotNet._21SemaphoreSlim
{
    public class SemaphoreSlimExample
    {
        //Compared to the barriers and countdown here we can increase and decrease the counter
        //1 param = How many can be served 
        //2 param - How many can be request
        static SemaphoreSlim semaphore = new SemaphoreSlim(3,10);
        public static void Run()
        {
            for (int i = 0; i < 20; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    Console.WriteLine($"Entering task {Task.CurrentId}"); //Come in 3 ,2, 1 
                    Console.WriteLine($"Semapore count: {semaphore.CurrentCount}");
                    semaphore.Wait(); //ReleaseCount--   //Come in 3 ,2, 1 => Full so now i must wait
                    Console.WriteLine($"Processing task {Task.CurrentId}");
                }); 
            }

            while (semaphore.CurrentCount <= 2)
            {
                Console.WriteLine($"Semapore count: {semaphore.CurrentCount}");
                Console.ReadKey();
                semaphore.Release(2); //Can be released then 2 ReleaseCount++ ++
            } 
        }
    }
}
