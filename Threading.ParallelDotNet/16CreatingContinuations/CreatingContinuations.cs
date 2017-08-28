using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading.ParallelDotNet._16CreatingContinuations
{
    public class CreatingContinuations
    {
        public static void Run()
        {
            ContinueWith();
            ContinueAllWith();
        }

        private static void ContinueAllWith()
        {
            var task = Task.Factory.StartNew(() => "Task 1");
            var task2 = Task.Factory.StartNew(() => "Task 2");

            // also ContinueWhenAny
            var task3 = Task.Factory.ContinueWhenAll(new[] { task, task2 },
              tasks =>
              {
                  Console.WriteLine("Tasks completed:");
                  foreach (var t in tasks)
                      Console.WriteLine(" - " + t.Result);
                  Console.WriteLine("All tasks done");
              });

            task3.Wait();
        }

        private static void ContinueWith()
        {
            var task = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Boiling water");
            });

            var task2 = task.ContinueWith(t =>
            {
                Console.WriteLine($"Completed task {t.Id}, pour water in cup.");
            });

            task2.Wait();
        }
    }
}
