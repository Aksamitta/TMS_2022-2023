using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12_Aksana.Patrubeika_Practice.Exceptions
{
    public class Car
    {
        public string Brand { get; set; }
        public double Price { get; set; }
        public string Engine { get; set; }

        //public Car(string brand, double price, string engine)
        //{
        //    Brand = brand;
        //    Price = price;
        //    Engine = engine;
        //}

        public string GetDiscount()
        {
            Price -= (Price * 0.1);
            //return Price;
            return $"Operation has gone succesfully! Price now is: {Price}";
        }
    }
}
