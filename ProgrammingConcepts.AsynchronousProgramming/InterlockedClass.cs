using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgrammingConcepts.AsynchronousProgramming
{
    /// <summary>
    /// Operations on 64-bit fields are guaranteed to be atomic only in a 64-bit runtime environment,
    /// and statements that combine more than one read/write operation are never atomic
    /// </summary>
    class Atomicity
    {
        static int _x, _y;
        static long _z;

        static void Test()
        {
            long myLocal;
            _x = 3;             // Atomic
            _z = 3;             // Nonatomic on 32-bit environs (_z is 64 bits)
            myLocal = _z;       // Nonatomic on 32-bit environs (_z is 64 bits)
            _y += _x;           // Nonatomic (read AND write operation)
            _x++;               // Nonatomic (read AND write operation)
        }
    }
    class ThreadUnsafe
    {
        static int _x = 1000;
        static void Go() { for (int i = 0; i < 100; i++) _x--; }
    }
    /// <summary>
    /// Use of memory barriers is not always enough when reading or writing fields in lock-free code.
    /// Operations on 64-bit fields, increments, and decrements require the heavier approach of using the Interlocked helper class. 
    /// </summary>
    public class InterlockedClass
    {
        static long _sum;

        static void InterlockedClassMain()
        {                                                             // _sum
                                                                      // Simple increment/decrement operations:
            Interlocked.Increment(ref _sum);                              // 1
            Interlocked.Decrement(ref _sum);                              // 0

            // Add/subtract a value:
            Interlocked.Add(ref _sum, 3);                                 // 3

            // Read a 64-bit field:
            Console.WriteLine(Interlocked.Read(ref _sum));               // 3

            // Write a 64-bit field while reading previous value:
            // (This prints "3" while updating _sum to 10)
            Console.WriteLine(Interlocked.Exchange(ref _sum, 10));       // 10

            // Update a field only if it matches a certain value (10):
            Console.WriteLine(Interlocked.CompareExchange(ref _sum, 123, 10));      // 123
        }
    }
}
