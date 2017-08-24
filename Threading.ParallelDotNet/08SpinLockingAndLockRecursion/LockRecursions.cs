using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading.ParallelDotNet._08SpinLockingAndLockRecursion
{
    public class LockRecursions
    {
        static SpinLock sl = new SpinLock();
        public static void LockRecursion(int x)
        {
            bool lockTaken = false;
            try
            {
                sl.Enter(ref lockTaken);
            }
            catch (LockRecursionException e)
            {
                Console.WriteLine("LockRecursionException" + e.Message);
            }
            finally
            {
                if (lockTaken)
                {
                    Console.WriteLine($"Took a lock, a = {x}");
                    LockRecursion(x - 1);
                    sl.Exit();
                }
                else
                {
                    Console.WriteLine($"Failed to take a lock, x = {x}");
                }
            }
        }

        public static void Runner()
        {
            LockRecursion(5);
        }
    }
}
