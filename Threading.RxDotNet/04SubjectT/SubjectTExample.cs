using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Text;

namespace Threading.RxDotNet._04SubjectT
{
    public class SubjectTExample: IObserver<float>
    {
        public SubjectTExample()
        {
            var market = new Subject<float>();
            market.Subscribe(this);

            market.OnNext(1.24f);
            market.OnError(new Exception("opss"));
            //market.OnCompleted();
        }
        public static void Run()
        {

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

    public class SubjectTExample2
    {
        public SubjectTExample2()
        {
            var market = new Subject<float>();
            market.Subscribe(
                f => Console.WriteLine($"Prices is {f}"),
                () => Console.WriteLine("Sequence is complete")
                ); //next,completed

            market.OnNext(1.24f);
            market.OnError(new Exception("opss"));
        }
        public static void Run()
        {

        }
    }
}
