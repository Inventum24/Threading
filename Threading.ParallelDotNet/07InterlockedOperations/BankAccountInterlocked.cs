using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Threading.ParallelDotNet._07InterlockedOperations
{
    public class BankAccountInterlocked
    {
        private int _Balance;
        public int Balance { get { return _Balance; } set { _Balance = value; } }

        public void Deposit(int amount)
        {
            Interlocked.Add(ref _Balance, amount);
        }

        public void Withdraw(int amount)
        {
            Interlocked.Add(ref _Balance, -amount);
        }
    }

    public class BankAccountRunnerInterlocked
    {
        public static void Runner()
        {
            List<Task> tasks = new List<Task>();
            var ba = new BankAccountInterlocked();

            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        ba.Deposit(100);
                    }
                }));

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        ba.Withdraw(100);
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine($"Final balance is {ba.Balance}");
        }
    }
}