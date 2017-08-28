using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading.ParallelDotNet._18Barrier
{
    public class BarrierExample
    {
        static Barrier barrier = new Barrier(2, b =>
         {
             Console.WriteLine($"Phase {b.CurrentPhaseNumber} is finished.");
         });
        public static void Run()
        {
            var water = Task.Factory.StartNew(Water);
            var cup = Task.Factory.StartNew(Cup);

            var tea = Task.Factory.ContinueWhenAll(new[] { water, cup }, tasks => {
                Console.WriteLine("Enjoy your cup of tea.");
            });
        }
        private static void Water()
        {
            Console.WriteLine("Putting the kettle on (takes a bit longer)"); 
            Thread.Sleep(2000);
            barrier.SignalAndWait();// WAIT => +1 IF 2 => START
            Console.WriteLine("Pouring water into cup."); //Here the counte can be 0
            barrier.SignalAndWait();
            Console.WriteLine("Putting the kettle away.");
        }
        private static void Cup()
        {
            Console.WriteLine("Finding the nicest cup of tea (fast)"); 
            barrier.SignalAndWait();// WAIT => +1 IF 2 => START
            Console.WriteLine("Adding tea."); //Here the counte can be 0
            barrier.SignalAndWait();
            Console.WriteLine("Adding sugar.");
        }
    }
}
