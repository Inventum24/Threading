using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Threading.ParallelDotNet._08SpinLockingAndLockRecursion
{
    public class BankAccountSpinLock
    {
        public object padlock = new object();
        public int Balance { get; private set; }

        public void Deposit(int amount)
        {
                Balance += amount;
        }

        public void Withdraw(int amount)
        {
                Balance -= amount;
        }
    }

    public class BankAccountSpinLockRunner
    {
        public static void Runner()
        {
            List<Task> tasks = new List<Task>();
            var ba = new BankAccountSpinLock();

            SpinLock sl = new SpinLock(); 

            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        var lockTaken = false;

                        try
                        {
                            sl.Enter(ref lockTaken);
                            ba.Deposit(100);
                        }
                        finally
                        {
                            if (lockTaken) sl.Exit();
                        }
                    }
                }));

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        var lockTaken = false;

                        try
                        {
                            sl.Enter(ref lockTaken);
                            ba.Withdraw(100);
                        }
                        finally
                        {
                            if (lockTaken) sl.Exit();
                        }
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine($"Final balance is {ba.Balance}");
        }
    }
}