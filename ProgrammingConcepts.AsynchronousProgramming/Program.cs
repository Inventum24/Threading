using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgrammingConcepts.AsynchronousProgramming
{
    partial class Program
    {

        static void Main(string[] args)
        {
            //Await
            //Test1();
            //AutoResetEventSampler
            //AutoResetEventSampler.TestAutoResetEvent();
            //StartWorker();

            Task<int> f = Task.Factory.StartNew(() => {
                return 42;
            });

            Task<byte[]> t = CompleteYourTasksTaskCompletionSource.FromWebClient(new WebClient(), new Uri("http://www.bing.com"));
            // t.Wait();
            t.ContinueWith(doneData => {
                var data = doneData.Result;
                var str = Encoding.UTF8.GetString(data);
                Console.WriteLine(str.Substring(0, 50));
            });
            Console.WriteLine("after task.");

            Console.ReadKey();
        }

        private static void StartWorker()
        {
            Worker.LogThread("Enter Main");
            var cts = new CancellationTokenSource(50000); // cancel after 5s
            var worker = new Worker(cts.Token);
            Task receiver = Task.Run(() => worker.ReceiverRun());
            Task main = worker.ProcessAsync();
            try
            {
                Task.WaitAll(main, receiver);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            Worker.LogThread("Leave Main");
            Console.ReadLine();
        }

        private static void Test1()
        {
             /*
             -1 => -1 => 500            
             */
            int lenght = -1;
            EasierToWrite etw = new EasierToWrite();
            Console.WriteLine(lenght);
            etw.AccessTheWebAsync().ContinueWith(t =>
            {
                Console.WriteLine(t.Result);
                lenght = t.Result;
            });
            Console.WriteLine(lenght);
        }
    }
}
