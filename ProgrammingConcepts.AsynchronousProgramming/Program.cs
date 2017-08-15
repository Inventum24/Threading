using ProgrammingConcepts.AsynchronousProgramming.Utils;
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
            Console.CancelKeyPress += (sender, e) =>
            {
                Console.WriteLine("Exiting...");
                Environment.Exit(0);
            };

            Console.WriteLine("Press ESC to Exit");

            var taskKeys = new Task(ReadKeys);
            var taskProcessFiles = new Task(ProcessFiles);

            taskKeys.Start();
            taskProcessFiles.Start();

            var tasks = new[] { taskKeys };
            Task.WaitAll(tasks);
        }

        private static void ProcessFiles()
        {
            var files = Enumerable.Range(1, 100).Select(n => "File" + n + ".txt");

            var taskBusy = new Task(BusyIndicator);
            taskBusy.Start();

            foreach (var file in files)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Procesing file {0}", file);
            }
        }

        private static void BusyIndicator()
        {
            var busy = new ConsoleBusyIndicator();
            busy.UpdateProgress();
        }

        private static void ReadKeys()
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();

            while (!Console.KeyAvailable && key.Key != ConsoleKey.Escape)
            {

                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        Console.WriteLine("UpArrow was pressed");
                        Counter c = new Counter();
                        TaskContainer.Create("tak", (tok) => AddCounterTask(tok, c));
                        break;
                    case ConsoleKey.DownArrow:
                        Console.WriteLine("DownArrow was pressed");
                        break;

                    case ConsoleKey.RightArrow:
                        Console.WriteLine("RightArrow was pressed");
                        break;

                    case ConsoleKey.LeftArrow:
                        Console.WriteLine("LeftArrow was pressed");
                        break;

                    case ConsoleKey.Escape:
                        break;

                    default:
                        if (Console.CapsLock && Console.NumberLock)
                        {
                            Console.WriteLine(key.KeyChar);
                        }
                        break;
                }
            }
        }

        public static async Task AddCounterTask(CancellationToken tok, Counter counter)
        {
            for (var i = 0; i < 10; i++)
            {
                counter.Increment();
            }
            await Task.Delay(0, tok);
        }
    }

    internal class ConsoleBusyIndicator
    {
        int _currentBusySymbol;

        public char[] BusySymbols { get; set; }

        public ConsoleBusyIndicator()
        {
            BusySymbols = new[] { '|', '/', '-', '\\' };
        }
        public void UpdateProgress()
        {
            while (true)
            {
                Thread.Sleep(100);
                var originalX = Console.CursorLeft;
                var originalY = Console.CursorTop;

                Console.Write(BusySymbols[_currentBusySymbol]);

                _currentBusySymbol++;

                if (_currentBusySymbol == BusySymbols.Length)
                {
                    _currentBusySymbol = 0;
                }

                Console.SetCursorPosition(originalX, originalY);
            }
        }


        //static void Main(string[] args)
        //{
        //    //Await
        //    //Test1();
        //    //AutoResetEventSampler
        //    AutoResetEventSampler.TestAutoResetEvent();
        //    //StartWorker();

        //    //Task<int> f = Task.Factory.StartNew(() => {
        //    //    return 42;
        //    //});

        //    //Task<byte[]> t = CompleteYourTasksTaskCompletionSource.FromWebClient(new WebClient(), new Uri("http://www.bing.com"));
        //    //// t.Wait();
        //    //t.ContinueWith(doneData => {
        //    //    var data = doneData.Result;
        //    //    var str = Encoding.UTF8.GetString(data);
        //    //    Console.WriteLine(str.Substring(0, 50));
        //    //});
        //    Console.WriteLine("after task.");

        //    Console.ReadKey();
        //}

        //private static void StartWorker()
        //{
        //    Worker.LogThread("Enter Main");
        //    var cts = new CancellationTokenSource(50000); // cancel after 5s
        //    var worker = new Worker(cts.Token);
        //    Task receiver = Task.Run(() => worker.ReceiverRun());
        //    Task main = worker.ProcessAsync();
        //    try
        //    {
        //        Task.WaitAll(main, receiver);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Exception: " + e.Message);
        //    }
        //    Worker.LogThread("Leave Main");
        //    Console.ReadLine();
        //}

        //private static void Test1()
        //{
        //     /*
        //     -1 => -1 => 500            
        //     */
        //    int lenght = -1;
        //    EasierToWrite etw = new EasierToWrite();
        //    Console.WriteLine(lenght);
        //    etw.AccessTheWebAsync().ContinueWith(t =>
        //    {
        //        Console.WriteLine(t.Result);
        //        lenght = t.Result;
        //    });
        //    Console.WriteLine(lenght);
        //}


    }
}
