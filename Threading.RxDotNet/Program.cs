using System;
using Threading.RxDotNet._01ObserverDesignPattern;
using Threading.RxDotNet._02IObserverT;
using Threading.RxDotNet._05Unsubscribing;
using Threading.RxDotNet._06ProxyAndBroadcast;
using Threading.RxDotNet._07ReplaySubjectT;
using Threading.RxDotNet._08BehaviorSubjectT;
using Threading.RxDotNet._09AsyncSubjecT;
using Threading.RxDotNet._10ImplementingIObservable;

namespace Threading.RxDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            //ObserverDesignPatternExample.Run();
            //IObserverTExample.Run();
            //UnsubscribingExample.Run();
            //ProxyAndBroadcastExample.Run();
            //ReplaySubjectTExample.Run();
            //BehaviorSubjectT.Run();
            //AsyncSubjectExample.Run();
            ImplementingIObservableExample.Run();
            Console.ReadKey();
        }
    }
}
