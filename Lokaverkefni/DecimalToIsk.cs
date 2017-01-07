using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Lokaverkefni
{
    class DecimalToIsk : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal amount = (decimal)value;
            string text = String.Format("{0:C}", amount);
            return text;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            NumberStyles style;
            CultureInfo cult;
            style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            cult = CultureInfo.CreateSpecificCulture("is-IS");
            string text = value.ToString();
            decimal amount;
            if (Decimal.TryParse(text, style, cult, out amount))
            {
                return amount;
            }
            else
            {
                amount = 0;
                return amount;
            }
            
        }
    }
}
