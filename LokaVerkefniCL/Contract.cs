using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LokaVerkefniCL
{
    public class Contract
    {
        public int ID { get; set; }
        public int ApartmentID { get; set; }
        public Apartment Apartment { get; set; }
        public int PersonID { get; set; }
        public Tenant Person { get; set; }
        public decimal Price { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public Contract() { }
        public Contract(int ApartmentID, int PersonID, int Price, DateTime RentDate, DateTime ReturnDate)
        {
            this.ApartmentID = ApartmentID;
            this.PersonID = PersonID;
            this.Price = Price;
            this.RentDate = RentDate;
            this.ReturnDate = ReturnDate;
        }
    }
}
