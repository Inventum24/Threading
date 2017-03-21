using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        static Random r = new Random();
        const int ileWatkow = 5;
        static double pi = 0; //zmienna współdzielona

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
    }
}
