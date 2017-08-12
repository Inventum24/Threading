using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgrammingConcepts.AsynchronousProgramming
{
    public class AutoResetEventSampler
    {
        static AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        static string dataFromServer = "";


        public static void TestAutoResetEvent()
        {
            Task task = Task.Factory.StartNew(() =>
            {
                GetDataFromServer();
            });

            //Put the current thread into waiting state until it receives the signal
            autoResetEvent.WaitOne();

            //Thread got the signal
            Console.WriteLine(dataFromServer);
        }

        static void GetDataFromServer()
        {
            //Calling any webservice to get data
            Thread.Sleep(TimeSpan.FromSeconds(10));
            dataFromServer = "Webservice data";
            autoResetEvent.Set();
        }
    }
}
