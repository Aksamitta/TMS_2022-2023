using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab31_Aksana.Patrubeika_Collections
{
    internal class Car
    {
        public string Model { get; set; }

        public string Number { get; set; }

        public override string ToString()
        {
            return Model + " " + Number;
        }
        
    }
}
