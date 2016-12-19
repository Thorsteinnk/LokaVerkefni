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
        public int ID { get; set; }
        public int ZipCode { get; set; }
        public string Location { get; set; }
        public ObservableCollection<Address> Addresss { get; set; }

        public string Full
        {
            get
            {
                try
                {
                    return ZipCode + " " + Location;
                }
                catch (Exception)
                {

                    return " ";
                }
                
            }
        }
        

        public Zip() { }
        public Zip(int zip, string Location)
        {
            this.ZipCode = zip;
            this.Location = Location;
        }
    }
}
