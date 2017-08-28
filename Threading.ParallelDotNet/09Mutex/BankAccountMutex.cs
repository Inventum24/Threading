using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Threading.ParallelDotNet._09Mutex
{
    public class BankAccountMutex
    {
        public object padlock = new object();
        public int Balance { get; private set; }

        public void Deposit(int amount)
        {
            lock (padlock)
            {
                Balance += amount;
            }
        }

        public void Withdraw(int amount)
        {
            lock (padlock)
            {
                Balance -= amount;
            }
        }

        public void Transfer(BankAccountMutex where,int amount)
        {
            Balance -= amount;
            where.Balance += amount;
        }
    }

    public class BankAccountRunnerMutex
    {
        public static void Runner()
        {
            Mutex mutex = new  Mutex();
            Mutex mutex2 = new Mutex();

            List<Task> tasks = new List<Task>();
            var ba = new BankAccountMutex();
            var ba2 = new BankAccountMutex();

            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        bool haveLock = mutex.WaitOne();
                        try
                        {
                            ba.Deposit(1);
                        }
                        finally
                        {
                            if (haveLock) mutex.ReleaseMutex();
                        }

                    }
                }));

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; ++j)
                    {
                        bool haveLock = mutex2.WaitOne();
                        try
                        {
                            ba2.Deposit(1); // deposit 10000
                        }
                        finally
                        {
                            if (haveLock) mutex2.ReleaseMutex();
                        }
                    }
                }));

                // transfer needs to lock both accounts
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        bool haveLock = Mutex.WaitAll(new[] { mutex, mutex2 });
                        try
                        {
                            ba.Transfer(ba2, 1); // transfer 10k from ba to ba2
                        }
                        finally
                        {
                            if (haveLock)
                            {
                                mutex.ReleaseMutex();
                                mutex2.ReleaseMutex();
                            }
                        }
                    }
                }

                        ));
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine($"Final balance ba is {ba.Balance}");
            Console.WriteLine($"Final balance ba2 is {ba2.Balance}");
        }
    }
}