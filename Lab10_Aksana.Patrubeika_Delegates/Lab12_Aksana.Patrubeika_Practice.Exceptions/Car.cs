using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_Aksana.Patrubeika_Delegates
{
    public class Car
    {
        public event EventHandler ChangePrice;
        public string Brand { get; set; }
        public string Engine { get; set; }
        //private double price;
        public double Price { get; set; }

        //public double Price
        //{
        //    get { return price; }
        //    set
        //    {
        //        if (price != value)
        //        {
        //            price = value;
        //            ChangePrice?.Invoke(this, new EventArgs());
        //        }
        //    }
        //}



        public string GetDiscount()
        {
            Price -= (Price * 0.1);            
            return $"Operation has gone succesfully! Price now is: {Price}";
        }


    }
}
