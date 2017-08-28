using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading.ParallelDotNet._10ReaderWriterLocks
{
    public class ReaderWriterLocksRunner
    {
        static ReaderWriterLockSlim padlock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

        static Random random = new Random();

        public static void Runner()
        {
            int x = 0;
            var tasks = new List<Task>();

            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew( () => {


                    //padlock.EnterReadLock();
                    padlock.EnterUpgradeableReadLock();

                    if (i%2 ==0)
                    {
                        padlock.EnterWriteLock();
                        x = 123;
                        padlock.ExitWriteLock();
                    }

                    Console.WriteLine($"Entered read lock, x = {x}");
                    Thread.Sleep(5000);

                    //padlock.ExitReadLock();
                    padlock.ExitUpgradeableReadLock();
                    Console.WriteLine($"Exited read lock, x = {x}");
                }));
            }

            try
            {
                Task.WaitAll(tasks.ToArray());
            }
            catch (AggregateException ae)
            {
                ae.Handle(e => { Console.WriteLine(e); return true; });
            }

            while (true)
            {
                Console.ReadKey();
                padlock.EnterWriteLock();

                Console.Write("Write lock acquired");

                int newValue = random.Next();
                x = newValue;

                Console.WriteLine($"Set x={x}");
                padlock.ExitWriteLock();
                Console.WriteLine("Write lock released");

            }

        }
    }
}
