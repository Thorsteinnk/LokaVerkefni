using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace LokaVerkefniCL
{
    
    public class Apartment
    {
        public int ID { get; set; }
        public double Size { get; set; }
        public decimal Price { get; set; }
        public int NumberOfRooms { get; set; }
        public string Description { get; set; }        
        public int AddressID { get; set; }
        public Address Address { get; set; }
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
        public Apartment(decimal Price ,double Size, int NumberOfRooms, string Description, int AdressID)
        {
            this.Price = Price;
            this.Size = Size;
            this.NumberOfRooms = NumberOfRooms;
            this.Description = Description;
            this.AddressID = AddressID;
        }
        
    }
}
