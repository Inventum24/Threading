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
using Threading.ParallelDotNet._20ManualResetEventSlimAndAutoResetEvent;
using Threading.ParallelDotNet._21SemaphoreSlim;
using Threading.ParallelDotNet._22Parallel_Invoke_For_ForEach;
using Threading.ParallelDotNet._23BreakingCancellationsAndExceptions;
using Threading.ParallelDotNet._24ThreadLocalStorage;
using Threading.ParallelDotNet._25Partitioning;
using Threading.ParallelDotNet._26AsParallelAndParallelQuery;
using Threading.ParallelDotNet._27CancellationsAndExceptions;
using Threading.ParallelDotNet._28MergeOptions;
using Threading.ParallelDotNet.CustomAggregation;

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
            //CountDownExample.Run();
            //ManualResetExample.Run();
            //SemaphoreSlimExample.Run();
            //ParallelExample.Run();
            //ParallelBreakingCancellationsAndExceptions.Run();
            //ThreadLocalStorageExample.Run();
            //PartitioningExample.Run();
            //AsParallelAndParallelQueryExample.Run();
            //CancellationsAndExceptionsExample.Run();
            //MergeExample.Run();
            CustomAggregationExample.Run();

            Console.ReadKey();
           
         }
    }
}
