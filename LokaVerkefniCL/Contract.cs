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
        
        public Contract()
        {
            RentDate = DateTime.Now;
            ReturnDate = DateTime.Now.AddYears(1);
        }
        public Contract(Contract old)
        {
            this.ID = old.ID;
            this.ApartmentID = old.ApartmentID;
            this.PersonID = old.PersonID;
            this.Price = old.Price;
            this.RentDate = old.RentDate;
            this.ReturnDate = old.ReturnDate;
        }
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
