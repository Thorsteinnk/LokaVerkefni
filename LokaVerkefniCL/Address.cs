using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LokaVerkefniCL
{

    public class Address : INotifyPropertyChanged
    {
        private string street, houseNumber, apartmentNumber;
        public int ID { get; set; }
        public string Street
        {
            get
            {
                return street;
            }
            set
            {
                street = value;
                OnPropertyChanged("AdressKey");
                OnPropertyChanged("Full");
            }
        }
        public string HouseNumber
        {
            get
            {
                return houseNumber;
            }
            set
            {
                houseNumber = value;
                OnPropertyChanged("AdressKey");
                OnPropertyChanged("Full");
            }
        }
        public string ApartmentNumber
        {
            get
            {
                return apartmentNumber;
            }
            set
            {
                apartmentNumber = value;
                OnPropertyChanged("AdressKey");
                OnPropertyChanged("Full");
            }
        } // is used to designate what apartment in the building it refers to (floor etc)
        public int ZipID { get; set; }
        public Zip Zip { get; set; }
        public ObservableCollection<Apartment> Apartments { get; set; }
        string adressKey;

       

        public string AdressKey {
            get
            {
                adressKey = Street + HouseNumber + ApartmentNumber;
                return adressKey;
            }
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

        public Address(Address old)
        {
            this.ID = old.ID;
            this.Street = old.Street;
            this.HouseNumber = old.HouseNumber;
            this.ApartmentNumber = old.ApartmentNumber;
            this.ZipID = old.ZipID;
            this.Zip = old.Zip;
            this.adressKey = old.adressKey;
    }

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

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
