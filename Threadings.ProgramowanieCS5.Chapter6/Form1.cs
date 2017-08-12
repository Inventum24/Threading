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

namespace Threadings.ProgramowanieCS5.Chapter6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Action a = () =>
            {
                Console.WriteLine("Start zadania nr " + Task.CurrentId);
                Thread.SpinWait(new Random().Next(100000000));
                Console.WriteLine("Koniec zadania nr " + Task.CurrentId);
            };
            //kod tworzący wątki, uruchamiający je i czekający na ich zakończenie
            List<Task> listaZadan = new List<Task>();
            for (int i = 0; i < 100; i++)
            {
                listaZadan.Add(new Task(a));
            }
            listaZadan.ForEach(t => t.Start());
            listaZadan.ForEach(t => t.Wait());

        }

        private void button_6_2_Click(object sender, EventArgs e)
        {
            Task<String> t = new Task<String>(() => { return "Dzień dobry"; });
            t.Start();
            Console.WriteLine(t.Result);
        }

        private void button_6_3_Click(object sender, EventArgs e)
        {
            List<Task<int>> lista = new List<Task<int>>();

            Console.WriteLine("Sprawdz, czy liczba pierwsza:");
            int n = Int32.Parse(Console.ReadLine());

            for (int i = 2; i < (int)Math.Sqrt(n); i++)
            {
                lista.Add(new Task<int>((j) =>
                            {
                                if (n % (int)j == 0)
                                {
                                    return (int)j;
                                }
                                else
                                {
                                    return 0;
                                }
                            }, i));
            }

            foreach (Task<int> t in lista) { t.Start(); }
            foreach (Task<int> t in lista) { t.Wait(); }
            bool pierwsza = true;
            foreach (Task<int> t in lista)
            {
                if (t.Result != 0)
                {
                    Console.WriteLine("Liczba {0} dzieli się przez {1}.", n, t.Result);
                    pierwsza = false;
                }
            }
            if (pierwsza) Console.WriteLine("Liczba {0} jest liczbą pierwszą.", n);
        }

        private void button_6_4_Click(object sender, EventArgs e)
        {
            /*
             * Metoda WaitAll każe bieżącemu wątkowi czekać na wykonanie
             * wszystkich wymienionych w jej argumentach zadań, natomiast metoda WaitAny wznawia
             * pracę wątku głównego po zakończeniu dowolnego ze wskazanych zadań
             */

            Task t1, t2, t3;
            t1 = new Task(() => {
                Thread.Sleep(1000); Console.WriteLine("zadanie t1 o identyfikatorze {0} zakończone", Task.CurrentId); });
            t2 = new Task(() => {
                Thread.Sleep(2000); Console.WriteLine("zadanie t2 o identyfikatorze {0} zakończone", Task.CurrentId); });
            t3 = new Task(() => {
                Thread.Sleep(3000); Console.WriteLine("zadanie t3 o identyfikatorze {0} zakończone", Task.CurrentId); });

            t2.ContinueWith((t) => 
                {
                    Console.WriteLine("Zadanie o identyfikatorze {1} zostało wykonane po zakończeniu zadania t2 o identyfikatorze {0}", t.Id,Task.CurrentId);
                });

            Task[] zadania = { t1, t2, t3 };

            foreach (Task t in zadania) t.Start();
            foreach (Task t in zadania) t.Wait();
        }

        //t2.ContinueWith((t)=>{
        //  Console.WriteLine("Zadanie o identyfikatorze {1} zostało wykonane po zakończeniu zadania t2 o identyfikatorze {0}", t.Id,Task.CurrentId);
        //               });
    
    }
}
