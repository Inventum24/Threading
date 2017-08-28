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
using Threading.ParallelDotNet._10ReaderWriterLocks;
using Threading.ParallelDotNet._11ConcurrentDictionary;
using Threading.ParallelDotNet._13ConcurrentStack;
using Threading.ParallelDotNet._15ConcurrentBlockingCollectionAndProducerConsumer;
using Threading.ParallelDotNet._16CreatingContinuations;
using Threading.ParallelDotNet._17ChildTasks;
using Threading.ParallelDotNet._18Barrier;
using Threading.ParallelDotNet._19CountDown;

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
            //BankAccountRunnerMutex.Runner();
            //GlobalMutexRunner.GlobalMutex();
            //ReaderWriterLocksRunner.Runner();
            //ConcurrentDictionaryExample.Run();
            //ConcurrentStackExample.Run();
            //ConcurrentBlockingExample.Run();
            //CreatingContinuations.Run();
            //ChildTasksExample.Run();
            //BarrierExample.Run();
            CountDownExample.Run();

            Console.ReadKey();
           
         }
    }
}
