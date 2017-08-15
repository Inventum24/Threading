using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgrammingConcepts.AsynchronousProgramming.Utils
{
    public class Counter
    {
        private int _Counter;

        public void Increment()
        {
            Interlocked.Increment(ref _Counter);
        }

        public int Value => _Counter;
    }
}
