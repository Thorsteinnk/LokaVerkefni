using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LokaVerkefniCL
{
    public class Zip
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Location { get; set; }
        public ObservableCollection<Address> Addresss { get; set; }

        public string Full
        {
            get
            {
                return ID.ToString() + " " + Location;
            }
        }
        

        public Zip() { }
        public Zip(int zip, string Location)
        {
            this.ID = zip;
            this.Location = Location;
        }
    }
}
