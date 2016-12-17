using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LokaVerkefniCL
{

    class Address
    {
        public int ID { get; set; }
        public string Street { get; set; }
        public int? HouseNumber { get; set; }
        public int? ApartmentNumber { get; set; }
        public int ZipId { get; set; }
        public Zip Zip { get; set; }
    }
}
