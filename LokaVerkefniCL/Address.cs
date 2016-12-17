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
        public string ApartmentNumber { get; set; }
        public int ZipID { get; set; }
        public Zip Zip { get; set; }

        public Address() { }
        public Address(string Street, int Zip)
        {
            this.Street = Street;
            this.ZipID = Zip;
        }
        public Address(string Street, int Zip, int HouseNumber)
        {
            this.Street = Street;
            this.ZipID = Zip;
            this.HouseNumber = HouseNumber;
        }
        public Address(string Street, int Zip, int HouseNumber, string ApartmentNumber)
        {
            this.Street = Street;
            this.ZipID = Zip;
            this.HouseNumber = HouseNumber;
            this.ApartmentNumber = ApartmentNumber;
        }
    }
}
