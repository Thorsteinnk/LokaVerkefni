using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace LokaVerkefniCL
{
    public class Tenant
    {
        public int ID { get; set; }
        public string SocialSecurity { get; set; }
        public string Name { get; set; }
        public int AddressID { get; set; }
        public Address Address { get; set; }
        public bool HasReference {
            get
            {
                if (this.References == null)
                {
                    return false;
                }

                else
                {
                    return true;
                }
            }
        }
        public ObservableCollection<Reference> References { get; set; }
        public ObservableCollection<Contract> Contracts { get; set; }

        public Tenant() { }
        public Tenant(string Name, int AddressID)
        {
            this.Name = Name;
            this.AddressID = AddressID;
        }
    }
}
