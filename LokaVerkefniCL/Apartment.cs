using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace LokaVerkefniCL
{
    
    public class Apartment : INotifyPropertyChanged
    {
        public int ID { get; set; }
        private double size;
        public double Size
        {
            get
            {
                return size;

            }

            set
            {
                size = value;
                OnPropertyChanged("PriceM2");
            }
        }
        public decimal price;
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                OnPropertyChanged("PriceM2");
            }
        }
        public decimal PriceM2
        {
            get
            {
                return Price / (decimal)Size;
            }

            set
            {
                Price = value * (decimal)Size;
                OnPropertyChanged("Price");
            }
        }
        public int NumberOfRooms { get; set; }
        public string Description { get; set; }        
        public int AddressID { get; set; }
        private Address address;
        public Address Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                OnPropertyChanged("Full");
            }
        }
        public ObservableCollection<Incident> Incidents { get; set; }
        public ObservableCollection<Contract> Contracts { get; set; }
        public string Full
        {
            get
            {
                try
                {
                    return Address.Full;
                }
                catch (Exception)
                {

                    return " ";
                }
                
            }
        }

        public Apartment() { }

        public Apartment(Apartment old)
        {
            this.ID = old.ID;
            this.Size = old.Size;
            this.Price = old.Price;
            this.NumberOfRooms = old.NumberOfRooms;
            this.Description = old.Description;
            this.AddressID = old.AddressID;
            this.Address = new Address(old.Address);
            this.Incidents = old.Incidents;
            this.Contracts = old.Contracts;
        }

        public Apartment(decimal Price ,double Size, int NumberOfRooms, string Description, int AdressID)
        {
            this.Price = Price;
            this.Size = Size;
            this.NumberOfRooms = NumberOfRooms;
            this.Description = Description;
            this.AddressID = AddressID;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
