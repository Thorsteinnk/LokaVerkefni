using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lokaverkefni
{
    /// <summary>
    /// Interaction logic for Contracts.xaml
    /// </summary>
    public partial class Contracts : Window
    {
        CollectionViewSource ContractViewSource = new CollectionViewSource();
        CollectionViewSource TenantViewSource = new CollectionViewSource();
        CollectionViewSource ApartmentViewSource = new CollectionViewSource();
        LokaverkefniDataContext DContext = new LokaverkefniDataContext();
        LokaVerkefniCL.Contract Contract;
        LokaVerkefniCL.Apartment ContractApartment;
        LokaVerkefniCL.Tenant ContractTenant;

        public Contracts()
        {
            InitializeComponent();
            ContractViewSource.Source = DContext.Contracts;
            TenantViewSource.Source = DContext.Tenants;
            ApartmentViewSource.Source = DContext.Apartments;
            DataContext = ContractViewSource;
        }
        #region Contracts

        #region NewContract
        private void ContractMainBtnNewContract_Click(object sender, RoutedEventArgs e)
        {
            Contract = new LokaVerkefniCL.Contract();
            ContractNew.DataContext = Contract;
            ContractNewComboBoxApartment.DataContext = ApartmentViewSource;
            ContractNewComboBoxTenant.DataContext = TenantViewSource;
            ContractNewTxtEstimatedPrice.DataContext = ApartmentViewSource;
            ContractMain.Visibility = Visibility.Collapsed;
            ContractNew.Visibility = Visibility.Visible;
        }

        private void ContractNewBtnSave_Click(object sender, RoutedEventArgs e)
        {
            ContractApartment = (LokaVerkefniCL.Apartment)ContractNewComboBoxApartment.SelectedItem;
            Contract.ApartmentID = ContractApartment.ID;
            ContractTenant = (LokaVerkefniCL.Tenant)ContractNewComboBoxTenant.SelectedItem;
            Contract.PersonID = ContractTenant.ID;
            DContext.context.Contracts.AddOrUpdate(c => new { c.PersonID, c.ApartmentID }, Contract);
            DContext.context.SaveChanges();
            ContractNew.Visibility = Visibility.Collapsed;
            ContractMain.Visibility = Visibility.Visible;
        }

        private void ContractNewBtnCancel_Click(object sender, RoutedEventArgs e)
        {
            ContractEdit.Visibility = Visibility.Collapsed;
            ContractNew.Visibility = Visibility.Collapsed;
            ContractMain.Visibility = Visibility.Visible;
        }
        #endregion NewContract

        #region EditContract
        private void ContractMainBtnEditContract_Click(object sender, RoutedEventArgs e)
        {
            Contract = new LokaVerkefniCL.Contract((LokaVerkefniCL.Contract)ContractMainComboBoxApartment.SelectedItem);
            ContractMain.Visibility = Visibility.Collapsed;
            ContractEdit.Visibility = Visibility.Visible;
        }

        private void ContractEditBtnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            DContext.context.SaveChanges();
            ContractEdit.Visibility = Visibility.Collapsed;
            ContractMain.Visibility = Visibility.Visible;
        }
        #endregion EditContract

        #region DeleteContract
        private void ContractMainBtnDeleteContract_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Ertu viss um að þú viljir eyða samningnum?", "Staðfesting", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {

            }
            else if (result == MessageBoxResult.Yes)
            {
                LokaVerkefniCL.Contract temp = (LokaVerkefniCL.Contract)ContractMainComboBoxApartment.SelectedItem;
                DContext.context.Contracts.Remove(temp);
                DContext.context.SaveChanges();
            }
        }
        #endregion DeleteContract

        #endregion Contracts
    }
}
