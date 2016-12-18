using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LokaVerkefniCL
{

    public class Address
    {
        public int ID { get; set; }
        public string Street { get; set; }
        public int? HouseNumber { get; set; }
        public int ZipID { get; set; }
        public Zip Zip { get; set; }
        public ObservableCollection<Apartment> Apartments { get; set; }

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
    }
}
