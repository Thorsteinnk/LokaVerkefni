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
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; } // is used to designate what apartment in the building it refers to (floor etc)
        public int ZipID { get; set; }
        public Zip Zip { get; set; }
        public ObservableCollection<Apartment> Apartments { get; set; }
        string adressKey;
        public string AdressKey {
            get { return adressKey; }
            set { adressKey = Street + HouseNumber + ApartmentNumber; }
        }
        public string Full
        {
            
            get
            {
                try
                {
                    if ((HouseNumber == null || HouseNumber == " ") && (ApartmentNumber == null || ApartmentNumber == " "))
                    {
                        return Street + " " + Zip.Full;
                    }

                    else if ((HouseNumber == null || HouseNumber == " "))
                    {
                        return Street + " " + ApartmentNumber + " " + Zip.Full;
                    }
                    else if (ApartmentNumber == null || ApartmentNumber == " ")
                    {
                        return Street + " " + HouseNumber + " " + Zip.Full;
                    }
                    else
                    {
                        return Street + " " + HouseNumber + " " + ApartmentNumber + " " + Zip.Full;
                    }
                }
                catch (Exception)
                {

                    return " ";
                }
                
                
            }
        }

        
        

        public Address() { }
        public Address(string Street, int Zip)
        {
            this.Street = Street;
            this.ZipID = Zip;
            this.HouseNumber = " ";
            this.ApartmentNumber = " ";
        }

        public Address(string Street, string HouseNumber, int Zip)
        {
            this.Street = Street;
            this.ZipID = Zip;
            this.HouseNumber = HouseNumber;
            this.ApartmentNumber = " ";
        }

        public Address(string Street, string HouseNumber, string ApartmentNumber,int Zip)
        {
            this.Street = Street;
            this.ZipID = Zip;
            this.HouseNumber = HouseNumber;
            this.ApartmentNumber = ApartmentNumber;
        }

        
    }
}
