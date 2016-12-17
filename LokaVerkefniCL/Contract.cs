using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LokaVerkefniCL
{
    class Contract
    {
        public int ID { get; set; }
        public int ApartmentID { get; set; }
        public Apartment Apartment { get; set; }
        public int PersonID { get; set; }
        public Person Person { get; set; }
        public int Price { get; set; }
    }
}
