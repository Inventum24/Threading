using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Threading.RxDotNet._01ObserverDesignPattern
{
    public class Market : INotifyPropertyChanged
    {
        private float volatility;

        public float Volatility
        {
            get => volatility;
            set
            {
                if (value.Equals(volatility)) return;
                volatility = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Market2
    {
        private List<float> prices = new List<float>();

        public void AddPrice(float price)
        {
            prices.Add(price);
            PriceAdded?.Invoke(this, price);
        }

        public event EventHandler<float> PriceAdded;

    }

    public class Market3
    {
        public BindingList<float> Prices = new BindingList<float>();

        public void AddPrice(float price)
        {
            Prices.Add(price);
        }

    }

    public class ObserverDesignPatternExample
    {
        public static void Run()
        {
            RunMarket1();
            RunMarket2();

            var market3 = new Market3();
            market3.Prices.ListChanged += (s,e) =>{
                    if (e.ListChangedType == ListChangedType.ItemAdded)
                    {
                        float price = ((BindingList<float>)s)[e.NewIndex];
                        Console.WriteLine($"ItemAdded {price}");
                     }
                };
            market3.AddPrice(2f);
        }


        private static void RunMarket2()
        {
            var market2 = new Market2();
            market2.PriceAdded += (s, f) =>
            {
                Console.WriteLine($"We got a price of {f}");
            };
            market2.AddPrice(2f);
        }

        private static void RunMarket1()
        {
            var market = new Market();
            market.PropertyChanged += Market_PropertyChanged;
            market.Volatility = 1f;
        }

        private static void Market_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Volatility")
            {
                var sth = ((Market)sender).Volatility;
            }
        }
    }
}