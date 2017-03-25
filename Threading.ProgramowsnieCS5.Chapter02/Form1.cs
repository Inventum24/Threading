using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Threading.ProgramowsnieCS5.Chapter02.LockClasses;

namespace Threading.ProgramowsnieCS5.Chapter02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(uruchomienieObliczen);
            t.Start();
            Thread.Sleep(500);
            t.Abort();
        }

        private void uruchomienieObliczen()
        {
            try
            {
                Thread.Sleep(new Random().Next(1000, 10000));
                //MessageBox.Show("Zakończono UruchomienieObliczen w wątku");
            }
            catch (ThreadAbortException tAbortEx)
            {
                MessageBox.Show("Działanie wątku zostało przerwane(" + tAbortEx.Message + ")");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(uruchomienieObliczen);
            t.Start();
            var isBG = t.IsBackground;
            Thread.Sleep(500);

            t.Suspend();
            Thread.Sleep(2000);
            t.Resume();
        }

        #region Użycie metody Join

        private static Random r = new Random();
        private const int ileWatkow = 5;
        private static double pi = 0; //zmienna współdzielona

        private void button3_Click(object sender, EventArgs e)
        {
            int czasPoczatkowy = Environment.TickCount;
            Thread[] tt = new Thread[ileWatkow];
            for (int i = 0; i < ileWatkow; ++i)
            {
                tt[i] = new Thread(uruchomienieObliczen);
                tt[i].Priority = ThreadPriority.Lowest;
                tt[i].Start();
            }
            //czekanie na zakończenie wątków
            foreach (Thread t in tt)
            {
                t.Join();
                MessageBox.Show("Zakończył działanie wątek w Main", t.ManagedThreadId.ToString());
            }
            //pi /= ileWatkow;
            MessageBox.Show("Wszystkie wątki zakończyły działanie.\nUśrednione Pi.");
            int czasKoncowy = Environment.TickCount;
            int roznica = czasKoncowy - czasPoczatkowy;
            MessageBox.Show("Czas obliczeń: " + (roznica).ToString());
        }

        #endregion Użycie metody Join

        private void button4_Click(object sender, EventArgs e)
        {
            List<Task> list = new List<Task>();
            ReadClass.HowMuchWillBeDone = 6;
            list.Add(new Task(ReadClass.SaveLockMessage));
            list.Add(new Task(ReadClass.SaveLockMessage));
            list.Add(new Task(ReadClass.SaveLockMessage));
            list.Add(new Task(ReadClass.SaveLockMessage));
            list.Add(new Task(ReadClass.SaveLockMessage));
            list.Add(new Task(ReadClass.SaveLockMessage));

            foreach (var task in list)
            {
                task.Start();
            }

            while (!ReadClass.CheckIsDone())
            { }

            Console.WriteLine("\n Skończone...");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PrintNumbers();
        }

        private static readonly object _object = new object();

        public static void PrintNumbers()
        {
            Boolean _lockTaken = false;

            Monitor.Enter(_object, ref _lockTaken);
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(100);
                    Debug.Write(i + ",");
                }
                
            }
            finally
            {
                if (_lockTaken)
                {
                    Monitor.Exit(_object);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int czasPoczatkowy = Environment.TickCount;
            WaitCallback wc = threadPoolMethod;

            //Sets the number of requests to the thread pool that can be active concurrently. 
            //All requests above that number remain queued until thread pool threads become available.
            ThreadPool.SetMaxThreads(30, 100);

            for (int i = 0; i < 100; ++i)
            {
                ThreadPool.QueueUserWorkItem(wc, i);
            }

            //czekanie na zakończenie wątków

            int ileDostepnychWatkowWPuli = 0; //nieużywane wątki puli
            int ileWszystkichWatkowWPuli = 0; //wszystkie wątki puli
            int ileDzialajacychWatkowPuli = 0; //używane wątki puli
            int tmp = 0;

            do
            {
                ThreadPool.GetAvailableThreads(out ileDostepnychWatkowWPuli, out tmp);
                ThreadPool.GetMaxThreads(out ileWszystkichWatkowWPuli, out tmp);
                ileDzialajacychWatkowPuli = ileWszystkichWatkowWPuli - ileDostepnychWatkowWPuli;
                Debug.WriteLine("Ilość aktywnych wątków puli: {0}", ileDzialajacychWatkowPuli);
                Thread.Sleep(1000);
            }
            while (ileDzialajacychWatkowPuli > 0);

            pi /= ileWatkow;
            Debug.WriteLine("Wszystkie wątki zakończyły działanie.\nUśrednione Pi={0},błąd ={1}", pi, Math.Abs(Math.PI - pi));

            int czasKoncowy = Environment.TickCount;
            int roznica = czasKoncowy - czasPoczatkowy;
            Console.WriteLine("Czas obliczeń: " + (roznica).ToString());
        }

        private void threadPoolMethod(object i)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Thread[] threads = new Thread[10];
            for (int i = 0; i < 10; ++i)

            {

                threads[i] = new Thread(someFunc);

                threads[i].Priority = ThreadPriority.Lowest;

                threads[i].Start(i);

            }
        }

        private void someFunc(object i)
        {
            try
            {
                int? param = i as int?;
                throw new NotImplementedException();
            }
            catch (ThreadAbortException ex)
            {
                Debug.WriteLine("Wyjątek (" + ex.Message + ")");
            }
            catch (Exception exc)

            {
                Debug.WriteLine("Wyjątek (" + exc.Message + ")");
            }
            finally
            {
                var a = 0;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}