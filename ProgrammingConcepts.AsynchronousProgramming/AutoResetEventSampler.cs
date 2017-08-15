using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProgrammingConcepts.AsynchronousProgramming
{
    public class AutoResetEventSampler
    {
        private static readonly AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        private static string dataFromServer = "";

        public static string DataFromServer { get => dataFromServer; set => dataFromServer = value; }

        public static void TestAutoResetEvent()
        {
            var task = Task.Factory.StartNew(() => { GetDataFromServer(); });

            //Put the current thread into waiting state until it receives the signal
            autoResetEvent.WaitOne();

            //Thread got the signal
            Console.WriteLine(DataFromServer);
        }

        private static void GetDataFromServer()
        {
            //Calling any webservice to get data
            Thread.Sleep(TimeSpan.FromSeconds(10));
            DataFromServer = "Webservice data";
            autoResetEvent.Set();
        }
    }
}