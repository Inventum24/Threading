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
                    return (int)j;
                },i ));
            }
        }
    }
}
