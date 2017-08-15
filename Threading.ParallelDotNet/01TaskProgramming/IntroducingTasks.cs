using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Threading.ParallelDotNet.TaskProgramming
{
    public class IntroducingTasks
    {
        public static void Write(char c)
        {
            int i = 1000;
            while (i-- > 0)
            {
                Console.WriteLine(c);
            }
        }

        public static void Write(object o)
        {
            int i = 1000;
            while (i-- > 0)
            {
                Console.WriteLine(o);
            }
        }

        public static int TextLenght(object o)
        {
            Console.WriteLine($"Task with id{Task.CurrentId}");
            return o.ToString().Length;
        }
    }
}