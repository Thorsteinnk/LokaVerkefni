using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LokaVerkefniCL
{
    class Reference
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public Tenant Person { get; set; }
        public string Description { get; set; }

        public Reference() { }
        public Reference(int PersonID, string Description)
        {
            this.PersonID = PersonID;
            this.Description = Description;
        }
    }
}
