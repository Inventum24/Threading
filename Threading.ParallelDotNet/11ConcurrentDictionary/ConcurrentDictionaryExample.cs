using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading.ParallelDotNet._11ConcurrentDictionary
{
    public static class ConcurrentDictionaryExample
    {
        private static ConcurrentDictionary<string, string> capitals = new ConcurrentDictionary<string, string>();

        public static void AddParis()
        {
            bool success = capitals.TryAdd("France","Paris");
            string who = Task.CurrentId.HasValue ? ($"Task {Task.CurrentId}") : "Main thread";
            Console.WriteLine($"{who} { (success ? "added" : "did not added") } the element");
        }


        public static void Run()
        {
            Task.Factory.StartNew(AddParis).Wait();
            AddParis();

            capitals["Russia"] = "Leningrad";
            capitals.AddOrUpdate("Russia", "Moscow", (k, old) => { return old + " --> Moscow"; });
            Console.WriteLine($"The Capital of Russia is { capitals["Russia"] }");

            capitals["Sweden"] = "Uppsala";
            var capitalOfSweden = capitals.GetOrAdd("Sweden", "Stockholm");
            Console.WriteLine($"The Capital of Sweden is { capitals["Sweden"] }");

            const string toRemove = "Russia";
            string removed;
            var didRussiaRemoved = capitals.TryRemove(toRemove, out removed);

            if (didRussiaRemoved)
            {
                Console.WriteLine($"We just removed {removed}");
            }
            else
            {
                Console.WriteLine($"Failed to remove the capital of {toRemove}");
            }

            //Not use Count because is slow

            foreach (var kv in capitals)
            {
                Console.WriteLine($" - {kv.Value} is the capital of {kv.Key}");
            }

        }
    }
}
