using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading.Albahari._01_Introduction
{
    public class ThrReadTesRt_01
    {
        public static void Run()
        {
            Thread t = new Thread(WriteT);          // Kick off a new thread
            t.Start();                               // running WriteY()

            // Simultaneously, do something on the main thread.
            for (var i = 0; i < 1000; i++)
            {
                Console.Write("XxX\n");
            }
        }

        static void WriteT()
        {
            for (int i = 0; i < 1000; i++) Console.Write("TtT\n");
        }
    }
}
