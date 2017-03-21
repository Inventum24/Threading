using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading.ProgramowsnieCS5.Chapter02.LockClasses
{
    public class ReadClass
    {
        private static readonly object SyncObject = new object();
        private static TextWriter W;

        public static void SaveLockMessage()
        {
            Console.WriteLine("Przed Lockiem");

            lock (SyncObject)
            {
                i++;
                W = new StreamWriter("log.txt", true);
                Debug.WriteLine("\t Start zapisu do pliku: " + i);
                W.WriteLine("Otrzymana: {0} {1}",
                            DateTime.Now.ToLongTimeString(),
                            DateTime.Now.ToLongDateString());
                Thread.Sleep(1000);

                Debug.WriteLine("\t Skończyłem: " + i);
                W.Close();
            }
        }

        private static int i = 0;

        public static int HowMuchWillBeDone = 6;

        public static bool CheckIsDone()
        {
            return i >= HowMuchWillBeDone;
        }
    }
}
