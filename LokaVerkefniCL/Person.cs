using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace LokaVerkefniCL
{
    class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int AddressID { get; set; }
        public Address Address { get; set; }
        public ObservableCollection<Reference> References { get; set; }

        public Person() { }
        public Person(string Name, int AddressID)
        {
            this.Name = Name;
            this.AddressID = AddressID;
        }
    }
}
