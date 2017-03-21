using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading.Albahari._01_Introduction
{
    public delegate void ThreadStart();    
    public class ThreadTest_02
    {
        public static void Run()
        {
            Thread t = new Thread(x => Console.WriteLine("hi"));
            t.Start();
        }
    }
}
