using System;
using System.Collections.Generic;
using System.Text;

namespace Threading.RxDotNet._03IObservableT
{
    public class Market : IObservable<float>
    {
        public IDisposable Subscribe(IObserver<float> observer)
        {
            throw new NotImplementedException();
        }
    }

    public class IObserverTExample : IObserver<float>
    {
        public IObserverTExample()
        {
            Market market = new Market();
            market.Subscribe(this);
        }
        public static void Run()
        {
            Console.WriteLine("Run");
            // OnNext* --> (OnError | OnCompleted) ?
            // OnCompleted -> Never it will be added

        }

        public void OnCompleted()
        {
            Console.WriteLine($"Sequence is complete");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($"We got an error {error}");
        }

        public void OnNext(float value)
        {
            Console.WriteLine($"Market gave us {value}");
        }
    }
}
