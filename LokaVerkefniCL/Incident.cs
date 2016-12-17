using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LokaVerkefniCL
{
    class Incident
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Action { get; set; }
        public bool Solved { get; set; }
    }
}
