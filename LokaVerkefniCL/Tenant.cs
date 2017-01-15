using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.ComponentModel;

namespace LokaVerkefniCL
{
    public class Tenant : INotifyPropertyChanged, IDataErrorInfo
    {
        public int ID { get; set; }        
        public string SocialSecurity { get; set; }
        public string Name { get; set; }
        public int AddressID { get; set; }
        public Address Address { get; set; }
        public bool hasReference;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool HasReference {
            get
            {
                if (this.References == null)
                {
                    hasReference = false;
                    return hasReference;
                }

                else
                {
                    hasReference = true;
                    return hasReference;
                }
            }
            set
            {
                if (this.References == null)
                {
                    hasReference = false;                    
                }

                else
                {
                    hasReference = true;                    
                }
            }
        }
        public ObservableCollection<Reference> References { get; set; }
        public ObservableCollection<Contract> Contracts { get; set; }

        public string Error
        {
            get { return "...."; }
        }

        public string this[string columnName]
        {
            get
            {
                return Validate(columnName);
            }
        }

        private string Validate(string propertyName)
        {
            string validationMessage = string.Empty;
            if (propertyName == "SocialSecurity")
            {
                if (ValidateSSN(SocialSecurity))
                {
                    return validationMessage;
                }

                else
                {
                    return "Error";
                }
            }

            return validationMessage;
        }

        public Tenant() { }
        public Tenant(string Name, int AddressID)
        {
            this.Name = Name;
            this.AddressID = AddressID;
        }

        public bool ValidateSSN(string kt)
        {
            if (kt == null)
            {
                return false;
            }
            else if (kt.Length == 10)
            {
                int sum = 0;
                sum = sum + (3 * int.Parse(kt.Substring (0, 1)));
                sum = sum + (2 * int.Parse(kt.Substring(1, 1)));
                sum = sum + (7 * int.Parse(kt.Substring(2, 1)));
                sum = sum + (6 * int.Parse(kt.Substring(3, 1)));
                sum = sum + (5 * int.Parse(kt.Substring(4, 1)));
                sum = sum + (4 * int.Parse(kt.Substring(5, 1)));
                sum = sum + (3 * int.Parse(kt.Substring(6, 1)));
                sum = sum + (2 * int.Parse(kt.Substring(7, 1)));
                

                int sumTemp = 0;

                if (sum % 11 > 0)
                    sumTemp = (sum / 11) + 1;
                else
                    sumTemp = sum / 11;

                sumTemp = (sumTemp * 11) - sum;

                if (sumTemp == int.Parse(kt.Substring(8, 1)))
                    return true;
            }
            return false;
        }
    }
}
