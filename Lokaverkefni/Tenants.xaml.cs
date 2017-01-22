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
    /// Interaction logic for Tenants.xaml
    /// </summary>
    public partial class Tenants : Window
    {

        CollectionViewSource TenantViewSource = new CollectionViewSource();
        CollectionViewSource ZipViewSource = new CollectionViewSource();
        LokaverkefniDataContext DContext = new LokaverkefniDataContext();
        LokaVerkefniCL.Tenant EditingTenant;
        LokaVerkefniCL.Tenant NewTenant;
        LokaVerkefniCL.Address NewAddress;
        LokaVerkefniCL.Zip Post;



        public Tenants()
        {
            InitializeComponent();
            TenantViewSource.Source = DContext.Tenants;
            ZipViewSource.Source = DContext.Zip;
            DataContext = TenantViewSource;
            TenantDisplay.Visibility = Visibility.Visible;
            TenantEdit.Visibility = Visibility.Collapsed;
            TenantNew.Visibility = Visibility.Collapsed;
        }

       
        private void TenBtnClkNew(object sender, RoutedEventArgs e)
        {
            NewTenant = new LokaVerkefniCL.Tenant();
            NewAddress = new LokaVerkefniCL.Address();
            NewTenant.Address = NewAddress;
            TenantNew.DataContext = NewTenant;
            TenNewComboZip.DataContext = ZipViewSource;
            TenantDisplay.Visibility = Visibility.Collapsed;
            TenantEdit.Visibility = Visibility.Collapsed;
            TenantNew.Visibility = Visibility.Visible;
        }

        

        private void ReferenceCheck(object sender, SelectionChangedEventArgs e)
        {
            if (TenantDisplayComboboxNameList.SelectedIndex != -1)
            {
                LokaVerkefniCL.Tenant test = (LokaVerkefniCL.Tenant)TenantDisplayComboboxNameList.SelectedItem;

                if (test.HasReference)
                {
                    TenantDisplayComboboxReference.Visibility = Visibility.Visible;
                    TenLblReference.Visibility = Visibility.Visible;
                    TenantDisplayComboboxReference.SelectedIndex = 0;
                }

                else
                {
                    TenLblReference.Visibility = Visibility.Collapsed;
                    TenantDisplayComboboxReference.Visibility = Visibility.Collapsed;
                }
            }
            
        }

        private void ReferenceCheck(object sender, RoutedEventArgs e)
        {
            if (TenantDisplayComboboxNameList.SelectedIndex != -1)
            {
                LokaVerkefniCL.Tenant test = (LokaVerkefniCL.Tenant)TenantDisplayComboboxNameList.SelectedItem;

                if (test.HasReference)
                {
                    TenantDisplayComboboxReference.Visibility = Visibility.Visible;
                    TenLblReference.Visibility = Visibility.Visible;
                    TenantDisplayComboboxReference.SelectedIndex = 0;
                }

                else
                {
                    TenLblReference.Visibility = Visibility.Collapsed;
                    TenantDisplayComboboxReference.Visibility = Visibility.Collapsed;
                }
            }
        }

        public void TenDeleteTenant(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Ertu Viss um að þú Viljir Eyða Leigjandanum?", "Staðfesting", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {

            }
            else if (result == MessageBoxResult.Yes)
            {
                LokaVerkefniCL.Tenant temp = (LokaVerkefniCL.Tenant)TenantDisplayComboboxNameList.SelectedItem;
                DContext.context.Tenants.Remove(temp);
            }

        }

        #region Editing

        private void TenBtnClkEdit(object sender, RoutedEventArgs e)
        {
            EditingTenant = new LokaVerkefniCL.Tenant((LokaVerkefniCL.Tenant)TenantDisplayComboboxNameList.SelectedItem);
            TenantEdit.DataContext = EditingTenant;
            TenEdComboZip.DataContext = ZipViewSource;
            TenEdComboZip.SelectedIndex = EditingTenant.Address.ZipID - 1;
            TenantDisplay.Visibility = Visibility.Collapsed;
            TenantEdit.Visibility = Visibility.Visible;
            TenantNew.Visibility = Visibility.Collapsed;

        }

        private void TenEdBtnClkSave(object sender, RoutedEventArgs e)
        {
            Post = (LokaVerkefniCL.Zip)TenEdComboZip.SelectedItem;
            EditingTenant.Address.ZipID = Post.ID;
            DContext.context.Adresses.AddOrUpdate(a => a.ID, EditingTenant.Address);
            DContext.context.Tenants.AddOrUpdate(t => t.AddressID, EditingTenant);
            TenantDisplay.Visibility = Visibility.Visible;
            TenantEdit.Visibility = Visibility.Collapsed;
            int sel = TenantDisplayComboboxNameList.SelectedIndex;
            TenantDisplayComboboxNameList.SelectedIndex = -1;
            TenantDisplayComboboxNameList.SelectedIndex = sel;
        }

        private void TenEdBtnClkCancel(object sender, RoutedEventArgs e)
        {
            TenantNew.Visibility = Visibility.Collapsed;
            TenantDisplay.Visibility = Visibility.Visible;
            TenantEdit.Visibility = Visibility.Collapsed;
        }
        private void TenEdBtnClkAddReference(object sender, RoutedEventArgs e)
        {
            LokaVerkefniCL.Reference refe = new LokaVerkefniCL.Reference(EditingTenant.ID);
            DContext.context.References.Add(refe);
            DContext.context.SaveChanges();
            DContext.context.Tenants.Load();
            DContext.context.References.Load();
            LokaVerkefniCL.Tenant Temp = (LokaVerkefniCL.Tenant)TenantDisplayComboboxNameList.SelectedItem;
            EditingTenant.References = Temp.References;
        }

        private void TenEdDeleteReference(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Ertu Viss um að þú Viljir Eyða Meðmælunum?", "Staðfesting", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {

            }
            else if (result == MessageBoxResult.Yes)
            {
                var curItem = ((ListBoxItem)TenEdListReference.ContainerFromElement((Button)sender)).Content;
                TenEdListReference.SelectedItem = (LokaVerkefniCL.Reference)curItem;
                LokaVerkefniCL.Reference inc = new LokaVerkefniCL.Reference();
                inc = (LokaVerkefniCL.Reference)TenEdListReference.SelectedItem;
                DContext.context.References.Remove(inc);
                DContext.context.SaveChanges();
            }
        }

        #endregion Editing



        private void TenNewReference(LokaVerkefniCL.Tenant ten)
        {
            
            foreach (LokaVerkefniCL.Reference refe in ten.References)
            {
                refe.PersonID = ten.ID;
                DContext.context.References.AddOrUpdate(r => new { r.Description, r.PersonID }, refe);
            }
            DContext.context.SaveChanges();
        }

        private void TenNewBtnClkAddReference(object sender, RoutedEventArgs e)
        {
            LokaVerkefniCL.Reference r = new LokaVerkefniCL.Reference();
            NewTenant.References.Add(r);
        }
        private void TenNewSave(object sender, RoutedEventArgs e)
        {
            // geting the selected zip code into a transitional variable to access its ID
            Post = (LokaVerkefniCL.Zip)TenNewComboZip.SelectedItem;
            // taking the zip id from transitional variable and setting it to NewAddress
            NewAddress.ZipID = Post.ID;
            // adding the new adress to database and checking if it exists to get its adress ID 
            DContext.context.Adresses.AddOrUpdate(a => a.AdressKey, NewAddress);
            DContext.context.SaveChanges();
            // taking the adress ID obtained from Database and giving it to NewApartment
            NewTenant.AddressID = NewAddress.ID;
            // adding the new Apartment to Database, if Current Adress already has an 
            // apartment registered updates that instead
            DContext.context.Tenants.AddOrUpdate(a => a.AddressID, NewTenant);
            DContext.context.SaveChanges();
            TenNewReference(NewTenant);
            // Hiding the New Apartment Grid and showing the Display Grid
            TenantNew.Visibility = Visibility.Collapsed;
            TenantDisplay.Visibility = Visibility.Visible;
            TenantEdit.Visibility = Visibility.Collapsed;
        }

        private void TenNewDeleteReference(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Ertu Viss um að þú Viljir Eyða Meðmælunum?", "Staðfesting", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {

            }
            else if (result == MessageBoxResult.Yes)
            {
                var curItem = ((ListBoxItem)TenNewListReference.ContainerFromElement((Button)sender)).Content;
                TenNewListReference.SelectedItem = (LokaVerkefniCL.Reference)curItem;
                LokaVerkefniCL.Reference inc = new LokaVerkefniCL.Reference();
                inc = (LokaVerkefniCL.Reference)TenNewListReference.SelectedItem;
                NewTenant.References.Remove(inc);                
            }
        }
    }

}
