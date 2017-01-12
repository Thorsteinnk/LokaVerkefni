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
        public bool hasReference;
        public bool HasReference {
            get
            {
                if (this.References == null)
                {
                    hasReference = false;
                    return hasReference;
                }

                else
                {
                    hasReference = true;
                    return hasReference;
                }
            }
            set
            {
                if (this.References == null)
                {
                    hasReference = false;                    
                }

                else
                {
                    hasReference = true;                    
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
