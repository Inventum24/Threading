﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading.ParallelDotNet._14ConcurrentBag
{
    public class ConcurrentBagExample
    {
        public static void Run()
        {
            //Stack LIFO
            //Queue FIFO

            var bag = new ConcurrentBag<int>();
            var tasks = new List<Task>();

            for (int i = 0; i < 10; i++)
            {
                var i1 = i;
                tasks.Add(Task.Factory.StartNew( () => {
                    bag.Add(i1);
                    Console.WriteLine($"{Task.CurrentId} has added {i1}");
                    int result;
                    if (bag.TryPeek(out result))
                        {
                            Console.WriteLine($"{Task.CurrentId} has peeked the value {result}");
                        }
                }));
            }

            Task.WaitAll(tasks.ToArray());
        }
    }
}
