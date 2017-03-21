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

namespace Threading.ProgramowsnieCS5.Chapter01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private async void button1_Click(object sender, EventArgs e)
        {
           //MessageBox.Show("Początek Button1");
            
            long wynik = await DoSomethingAsync("Zadanie 1.5");
            
            MessageBox.Show("Koniec Button1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Początek Button2");
            button1_Click(null, null);
            MessageBox.Show("Koniec Button2");
        }

        Task<long> DoSomethingAsync(object argument)
        {
            Func<object, long> akcja = (object _argument) =>
            {
                //MessageBox.Show("Początek DoSomethingAsync");
                Thread.Sleep(5000);
                MessageBox.Show(_argument.ToString());
                return DateTime.Now.Ticks;
            };

            Task<long> zadanie = new Task<long>(akcja, argument);
            zadanie.Start();
            return zadanie;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Func<object, long> akcja = (object _argument) =>
            {
                MessageBox.Show("Początek DoSomethingAsync");
                Thread.Sleep(5000);
                MessageBox.Show(_argument.ToString());
                return DateTime.Now.Ticks;
            };

            Task<long> zadanie = new Task<long>(akcja, "Zadanie zrealizowane");
            zadanie.Start();
            MessageBox.Show("Po starcie");
            MessageBox.Show("Wynik" + zadanie.Result.ToString());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
