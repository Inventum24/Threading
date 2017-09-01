using System;
using System.Collections.Generic;
using System.Text;

namespace Threading.RxDotNet._02IObserverT
{
    public class IObserverTExample: IObserver<float>
    {
        public static void Run()
        {
            Console.WriteLine("Run");
            // OnNext* --> (OnError | OnCompleted) ?
            // OnCompleted -> Never it will be added
             
        }

        public void OnCompleted()
        {
            
        }

        public void OnError(Exception error)
        {
            
        }

        public void OnNext(float value)
        {
            Console.WriteLine($"Market gave us {value}");
        }
    }
}
