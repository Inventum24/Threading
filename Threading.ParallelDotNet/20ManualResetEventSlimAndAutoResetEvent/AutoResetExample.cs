using System;
using System.Threading;
using System.Threading.Tasks;

namespace Threading.ParallelDotNet._20ManualResetEventSlimAndAutoResetEvent
{
    public partial class ManualResetExample
    {
        public class AutoResetExample
        {
            static AutoResetEvent evt = new AutoResetEvent(false); 

            public static void Run()
            {
                Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Boiling water");
                    Thread.Sleep(10000);
                    evt.Set(); //This sets true
                });

                var makeTea = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Waiting for water");
                    evt.WaitOne(); //This sets false
                    Console.WriteLine("Here is your tea");
                    var ok = evt.WaitOne(1000); //true if the current instance receives a signal; otherwise, false.

                    if (ok)
                    {
                        Console.WriteLine("Enjoy your tea");
                    }
                    else
                    {
                        Console.WriteLine("No tea for tea");
                    }
                });

                makeTea.Wait();
            }
        }
    }
}
