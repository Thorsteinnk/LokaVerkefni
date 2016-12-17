using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace LokaVerkefniCL
{
    class Apartment
    {
        public int ID { get; set; }
        public float Size { get; set; }
        public int NumberOfRooms { get; set; }
        public string Description { get; set; }
        public int AddressID { get; set; }
        public Address Address { get; set; }
        public ObservableCollection<Incident> Incidents { get; set; }
    }
}
