using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LokaVerkefniCL
{
    class Zip
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Location { get; set; }

        public Zip() { }
        public Zip(int zip, string Location)
        {
            this.ID = zip;
            this.Location = Location;
        }
    }
}
