using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LokaVerkefniCL
{
    public class Incident
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Action { get; set; }
        public bool Solved { get; set; }
        public int ApartmentID { get; set; }

        public Incident() { }
        public Incident(int Apartmentid)
        {
            this.ApartmentID = Apartmentid;
            this.Solved = false;
        }
        public Incident(string Description)
        {
            this.Description = Description;
            this.Solved = false;
        }
        public Incident(string Description, string Action, bool Solved)
        {
            this.Description = Description;
            this.Action = Action;
            this.Solved = Solved;
        }
    }
}
