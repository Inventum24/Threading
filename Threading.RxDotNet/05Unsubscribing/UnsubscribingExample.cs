using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;

namespace Threading.RxDotNet._05Unsubscribing
{
    public class UnsubscribingExample
    {
        public static void Run()
        {
            var sensor = new Subject<float>();

            using (sensor.Subscribe(Console.WriteLine))
            {
                sensor.OnNext(1);
            }
            //OR//sensor.Dispose();
        }
    }
}
