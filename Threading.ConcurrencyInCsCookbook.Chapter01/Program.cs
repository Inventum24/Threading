using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading.ConcurrencyInCsCookbook.Chapter01
{
    class Program
    {
        static void Main(string[] args)
        {
            DoSomethingAsync();

            var myTask = DoSomethingTaskAsync(); // call your method which will return control once it hits await
                                                 // now you can continue executing code here
            int result = myTask.Result; // wait for the task to complete to continue
                                           // use result

            Console.ReadKey();
        }
        static async void DoSomethingAsync()
        {
            int val = 13;
            // Asynchronously wait 1 second.
            await Task.Delay(TimeSpan.FromSeconds(1));
            val *= 2;
            // Asynchronously wait 1 second.
            await Task.Delay(TimeSpan.FromSeconds(1));
            Trace.WriteLine(val);
        }

        static async Task<int> DoSomethingTaskAsync()
        {
            int val = 13;
            // Asynchronously wait 1 second.
            await Task.Delay(TimeSpan.FromSeconds(1));
            val *= 2;
            // Asynchronously wait 1 second.
            await Task.Delay(TimeSpan.FromSeconds(1));
            return val;
        }
    }
}
