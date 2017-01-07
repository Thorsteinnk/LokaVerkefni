using LokaVerkefniCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;

namespace Lokaverkefni
{
    class SizeToPrice : IValueConverter
    {
        LokaverkefniDataContext DContext = new LokaverkefniDataContext();
        decimal AvaragePricePerM2;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal recomendedPrice;
            try
            {
                string sizes = value.ToString();
                double size = Double.Parse(sizes);
                AvaragePricePerM2 = GetAvaragePrice();
                recomendedPrice = (decimal)size * AvaragePricePerM2;
                
            }
            catch (Exception)
            {

                recomendedPrice = 0;
            }                      
            string text = String.Format("{0:C}", recomendedPrice);
            return text;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private decimal GetAvaragePrice()
        {
            int counter = 0;
            decimal Total = 0;
            foreach (Apartment apt in DContext.Apartments)
            {
                counter++;
                Total = Total + (apt.Price / (decimal)apt.Size);
            }
            return (Total / counter);
        }
    }
}
