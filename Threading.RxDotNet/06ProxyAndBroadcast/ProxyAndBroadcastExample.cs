using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Text;

namespace Threading.RxDotNet._06ProxyAndBroadcast
{
    //public static class ExtensionMethods
    //{
    //    public static IDisposable SubscribeTo<T>(this IObserver<T> observer, IObservable<T> observable)
    //    {
    //        return observable.Subscribe(observer);
    //    }
    //}
    public class ProxyAndBroadcastExample
    {
        public static void Run()
        {
            var market = new Subject<float>(); //Observable
            var marketConsumer = new Subject<float>(); // IObserver of 'market'
                                                       // AND Observable of self !!!

            //marketConsumer.SubscribeTo(market);
            //Equals
            market.Subscribe(marketConsumer);

            marketConsumer.Inspect("market consumer");

            market.OnNext(1);
            market.OnNext(2);
            market.OnNext(3);
            market.OnNext(4);
        }
    }

    public static class ExtensionMethods
    {
        public static IDisposable Inspect<T>(this IObservable<T> self,string name)
        {
            return self.Subscribe(
                x => Console.WriteLine($"{name} has generated value {x}"),
                Exception => Console.WriteLine($"{name} has generated exception {Exception.Message}"),
                () => Console.WriteLine($"{name} has completed.")
                );
        }

        public static IObserver<T> OnNext<T>(this IObserver<T> self, params T[] args)
        {
            foreach (var arg in args)
            {
                self.OnNext(arg);
            }

            return self;
        }
    }
}
