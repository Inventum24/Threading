using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Text;
using Threading.RxDotNet._06ProxyAndBroadcast;

namespace Threading.RxDotNet._08BehaviorSubjectT
{
    public class BehaviorSubjectT
    {
        public class Scada
        {
            private BehaviorSubject<double> sensorValue;
            public IObservable<double> SensorValue => sensorValue;
        }
        public static void Run()
        {
            var sensorReading = new BehaviorSubject<double>(-1.0);
            sensorReading.Inspect("sensor");
            sensorReading.OnNext(0.99);
        }
    }
}
