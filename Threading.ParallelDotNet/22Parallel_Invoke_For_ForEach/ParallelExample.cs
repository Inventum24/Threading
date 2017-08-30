using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading.ParallelDotNet._22Parallel_Invoke_For_ForEach
{
    public class ParallelExample
    {
        public static IEnumerable<int> Range(int start, int end, int step)
        {
            for (int i = start; i < end; i += step)
            {
                yield return i;
            }
        }
        public static void Run()
        {
            var a = new Action(()=> Console.WriteLine($"\tFirst {Task.CurrentId}"));
            var b = new Action(() => Console.WriteLine($"\tSecond {Task.CurrentId}"));
            var c = new Action(() => Console.WriteLine($"\tThird {Task.CurrentId}"));

            Console.WriteLine("\nParallel_Invoke:");
            Parallel.Invoke(a, b, c);

            Console.WriteLine("\nParallel_For:");
            Parallel.For(1, 11, i => { Console.WriteLine($"\t{i*i}"); });

            Console.WriteLine("\nParallel_ForEach:");

            string[] words = { "oh", "what", "a", "night" };

            var po = new ParallelOptions();
            Parallel.ForEach(words,po, word =>
            {
                Console.WriteLine($"{word} has lenght {word.Length} (task {Task.CurrentId})");
            });

            Console.WriteLine("\nParallel_ForEach_Range:");

            Parallel.ForEach(Range(1, 20, 3), Console.WriteLine);
        }
    }
}
