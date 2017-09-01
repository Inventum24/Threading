using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;

namespace Threading.RxDotNet._07ReplaySubjectT
{
    public class ReplaySubjectTExample
    {
        public static void Run()
        {
            //var timeWindow = TimeSpan.FromMilliseconds(500);
            //var market = new ReplaySubject<float>(timeWindow);
            //var market = new ReplaySubject<float>()
            var market = new ReplaySubject<float>(1);    //Subject Not store messages eg OnNext -> Subscribe -> Nothing
                                                                   //But ReplaySubject store messages. IT COULD BE DANGEROUS!!!
            market.OnNext(123);
            Thread.Sleep(423);
            market.OnNext(564);
            Thread.Sleep(423);
            market.Subscribe(x => Console.WriteLine($"Got the price{x}"));
        }
    }
}
