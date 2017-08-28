using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading.ParallelDotNet._09Mutex
{
    public class GlobalMutexRunner
    {
        public static void GlobalMutex()
        {
            const string appName = "MyApp";
            Mutex mutex;
            try
            {
                mutex = Mutex.OpenExisting(appName);
                Console.WriteLine($"Sorry, {appName} is already running.");
                return;
            }
            catch (WaitHandleCannotBeOpenedException e)
            {
                Console.WriteLine("We can run the program just fine.");
                // first arg = whether to give current thread initial ownership
                mutex = new Mutex(false, appName);
            }


            Console.ReadKey();
        }
    }
}
