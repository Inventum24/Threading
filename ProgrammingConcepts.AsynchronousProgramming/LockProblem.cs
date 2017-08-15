using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgrammingConcepts.AsynchronousProgramming
{

    public class BathroomStall
    {
        public void BeUsed(int id)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Bathroom is used by {id}");
            }
        }
    }
    public class LockProblem
    {
        static BathroomStall stall = new BathroomStall();

        void Run()
        {
            for (int i = 0; i < 3; i++)
            {
                new Thread(RegularUsers).Start();
            }
            new Thread(TheWeirdGuy).Start();
        }

        private void TheWeirdGuy()
        {
            stall.BeUsed(99);
        }

        private void RegularUsers()
        {
            lock (stall)
                stall.BeUsed(Thread.CurrentThread.ManagedThreadId);

            //The same
            Monitor.Enter(stall);
            stall.BeUsed(Thread.CurrentThread.ManagedThreadId);
            Monitor.Exit(stall);

        }
    }
}
