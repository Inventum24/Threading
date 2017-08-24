using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Threading.ParallelDotNet.TaskProgramming;
using Threading.ParallelDotNet._02CancellingTask;
using Threading.ParallelDotNet._03WaitingForTimeToPass;
using Threading.ParallelDotNet._04WaitingForTasks;
using Threading.ParallelDotNet._05ExceptionHandling;
using Threading.ParallelDotNet._06CriticalSections;
using Threading.ParallelDotNet._07InterlockedOperations;
using Threading.ParallelDotNet._08SpinLockingAndLockRecursion;
using Threading.ParallelDotNet._09Mutex;

namespace Threading.ParallelDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            //IntroducingTasksRunner.Runner();
            //CancellingTask.Runner();
            //WaitingForTimeToPass.Runner();
            //WaitingForTasks.Runner();
            //ExceptionHandling.Runner();
            //BankAccountRunner.Runner();
            //BankAccountRunnerInterlocked.Runner();
            //BankAccountSpinLockRunner.Runner();
            //LockRecursions.Runner();
            BankAccountRunnerMutex.Runner();
            Console.ReadKey();
         }
    }
}
