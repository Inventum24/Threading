using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using Threading.RxDotNet._06ProxyAndBroadcast;

namespace Threading.RxDotNet._09AsyncSubjecT
{
    public class AsyncSubjectExample
    {
        public static void Run()
        {
            //Task<int> t = Task<int>.Factory.StartNew(() => 42);
            //int value = t.Result;

            var sensor = new AsyncSubject<double>();
            sensor.Inspect("async");

            sensor.OnNext(1.0);
            sensor.OnNext(2.0);
            sensor.OnNext(3.0);
            //Nothing
            sensor.OnCompleted();//Now it show a last result

            sensor.OnNext(3.0); //Nothing


        }
    }
}
