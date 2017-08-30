using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading.ParallelDotNet._20ManualResetEventSlimAndAutoResetEvent
{
    public partial class ManualResetExample
    {
        static ManualResetEventSlim evt = new ManualResetEventSlim();

        public static void Run()
        {
            Task.Factory.StartNew(()=>
            {
                Console.WriteLine("Boiling water");
                Thread.Sleep(10000);
                evt.Set();
            });

            var makeTea = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Waiting for water");
                evt.Wait(); //Without reset, wait does not stop action 
                evt.Reset(); //Now it works as AutoReset (Wait + Rest)
                Console.WriteLine("Here is your tea");
                evt.Wait();
                Console.WriteLine("Here is your tea2");
            });

            makeTea.Wait();
        }
    }
}
