using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reactive.Disposables;
using System.Text;
using Threading.RxDotNet._06ProxyAndBroadcast;

namespace Threading.RxDotNet._10ImplementingIObservable
{

    public class Market : IObservable<float>
    {
        // list?
        // hashset
        // concurrentbag
        private ImmutableHashSet<IObserver<float>> observers = ImmutableHashSet<IObserver<float>>.Empty;

        public IDisposable Subscribe(IObserver<float> observer)
        {
            observers = observers.Add(observer);
            return Disposable.Create(() =>
            {
                observers = observers.Remove(observer);
            });
        }

        public void Publish(float price)
        {
            foreach (var o in observers)
                o.OnNext(price);
        }
    }

    public class Subscription : IDisposable
    {
        public void Dispose()
        {
            
        }
    }
    public class ImplementingIObservableExample
    {
        public static void Run()
        {
            var market = new Market();
            var sub = market.Subscribe(
              value => Console.WriteLine($"Got market value {value}"));

            market.Publish(123);
            sub.Dispose();
        }
    }
}
