using LokaVerkefniCL;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lokaverkefni
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Main View Source for Apartments Created
        /// </summary>
        CollectionViewSource ApartmentViewSource = new CollectionViewSource();
        /// <summary>
        /// View Source for Zip Codes Created
        /// </summary>
        CollectionViewSource ZipViewSource = new CollectionViewSource();

        CollectionViewSource ContractViewSource = new CollectionViewSource();
        CollectionViewSource TenantViewSource = new CollectionViewSource();

        /// <summary>
        /// Data Context Created
        /// </summary>
        LokaverkefniDataContext DContext = new LokaverkefniDataContext();
        /// <summary>
        /// Creating a Variable for editing Apartments, accessable to all Functions
        /// </summary>
        Apartment EditingApartment;
        /// <summary>
        /// Creating a Variable for a new Appartment, accesable to all Functions
        /// </summary>
        LokaVerkefniCL.Apartment NewApartment;
        /// <summary>
        /// Creating a Adress variable to link to a new apartment, Accesable to all functions
        /// </summary>
        LokaVerkefniCL.Address NewAddress;
        /// <summary>
        /// Creating a Variable to link Zip Code from Combobox to Apartment, Accesable to all functions
        /// </summary>
        LokaVerkefniCL.Zip Post;
        LokaVerkefniCL.Tenant EditingTenant;
        LokaVerkefniCL.Tenant NewTenant;
        LokaVerkefniCL.Contract Contract;
        LokaVerkefniCL.Apartment ContractApartment;
        LokaVerkefniCL.Tenant ContractTenant;

        #region MainWindow
        public MainWindow()
        {
            InitializeComponent();
            // Connecting the main Viewsource to Data Context - Apartments
            ApartmentViewSource.Source = DContext.Apartments;
            // Conecting the zip Viewsource to Data Context - Zip so it can access all Zip codes
            ZipViewSource.Source = DContext.Zip;

            ContractViewSource.Source = DContext.Contracts;
            TenantViewSource.Source = DContext.Tenants;

            // Setting the main View Source as the Data Context for Apartments
            gridApartment.DataContext = ApartmentViewSource;
            gridTenants.DataContext = TenantViewSource;
            gridContracts.DataContext = ContractViewSource;
        }

        private void BtnApartments_Click(object sender, RoutedEventArgs e)
        {
            HideGrids();
            gridApartment.Visibility = Visibility.Visible;      
            //Apartments aptwin = new Apartments();
            //aptwin.ShowDialog();
        }

        private void BtnCustomers_Click(object sender, RoutedEventArgs e)
        {
            HideGrids();
            gridTenants.Visibility = Visibility.Visible;
            //Tenants custwin = new Tenants();
            //custwin.ShowDialog();
        }

        private void BtnContracts_Click(object sender, RoutedEventArgs e)
        {
            HideGrids();
            gridContracts.Visibility = Visibility.Visible;
            //Contracts contrwin = new Contracts();
            //contrwin.ShowDialog();
        }

        private void HideGrids()
        {
            gridHome.Visibility = Visibility.Collapsed;
            gridApartment.Visibility = Visibility.Collapsed;
            gridContracts.Visibility = Visibility.Collapsed;
            gridTenants.Visibility = Visibility.Collapsed;
        }
        #endregion MainWindow
        #region Apartments

        public void AptDeleteApartment(object sender, RoutedEventArgs e)
        {
            EditingApartment = (LokaVerkefniCL.Apartment)ApartmentDisplayComboBoxApartment.SelectedItem;
            bool ApartmentInRent = false;
            foreach (Contract a in DContext.Contracts)
            {
                if (a.ApartmentID == EditingApartment.ID)
                {
                    ApartmentInRent = true;
                }
            }

            if (ApartmentInRent)
            {
                MessageBox.Show("Íbúðin er í leigu og ekki hægt að Eyða");
            }

            else
            {
                MessageBoxResult result = MessageBox.Show("Ertu Viss um að þú Viljir Eyða íbúðini?", "Staðfesting", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.No)
                {

                }
                else if (result == MessageBoxResult.Yes)
                {
                    LokaVerkefniCL.Apartment temp = (LokaVerkefniCL.Apartment)ApartmentDisplayComboBoxApartment.SelectedItem;
                    DContext.context.Apartments.Remove(temp);
                }
            }
            

        }
        

        #region Editing
        /// <summary>
        /// Changing active grid to Editing
        /// </summary>        
        private void AptEnableEdit(object sender, RoutedEventArgs e)
        {

            // linking the selected Apartment to the EditingApartment Variable
            EditingApartment = new LokaVerkefniCL.Apartment((LokaVerkefniCL.Apartment)ApartmentDisplayComboBoxApartment.SelectedItem);
            // setting the EditingApartment as the Data Context of the Edit Grid
            ApartmentEdit.DataContext = EditingApartment;
            // Linking the Zip Combobox to the zip VievSource
            ApartmentEditComboBoxZip.DataContext = ZipViewSource;
            // Making the zip combo box select the correct zip, 
            // Combobox starts counting at 0 while database starts at 1 so a correction is needed
            ApartmentEditComboBoxZip.SelectedIndex = EditingApartment.Address.ZipID - 1;
            // Hiding the Display Grid and showing the Edit Grid
            ApartmentDisplay.Visibility = Visibility.Collapsed;
            ApartmentEdit.Visibility = Visibility.Visible;

        }

        private void AptSaveChanges(object sender, RoutedEventArgs e)
        {
            // geting the selected zip code into a transitional variable to access its ID
            Post = (LokaVerkefniCL.Zip)ApartmentEditComboBoxZip.SelectedItem;
            // taking the zip id from transitional variable and setting it to the edited Address
            EditingApartment.Address.ZipID = Post.ID;
            // updating the adress in the database
            DContext.context.Adresses.AddOrUpdate(a => a.ID, EditingApartment.Address);
            // updating the apartment in the database
            DContext.context.Apartments.AddOrUpdate(a => a.AddressID, EditingApartment);
            DContext.context.SaveChanges();
            // Hiding the Edit Grid and showing the Display Grid
            ApartmentEdit.Visibility = Visibility.Collapsed;
            ApartmentDisplay.Visibility = Visibility.Visible;
            // seting the combobox to select default value and then return to
            // selected value in order to force update on the display grid            
            int sel = ApartmentDisplayComboBoxApartment.SelectedIndex;
            ApartmentDisplayComboBoxApartment.SelectedIndex = -1;
            ApartmentDisplayComboBoxApartment.SelectedIndex = sel;



        }
        /// <summary>
        /// Hides the Edit/new apartment grid and shows the display grid discarding changes
        /// </summary>        
        private void AptEditCancel(object sender, RoutedEventArgs e)
        {
            ApartmentNewApartment.Visibility = Visibility.Collapsed;
            ApartmentEdit.Visibility = Visibility.Collapsed;
            ApartmentDisplay.Visibility = Visibility.Visible;
        }

        private void AptAddIncident(object sender, RoutedEventArgs e)
        {
            Incident inci = new Incident(EditingApartment.ID);
            DContext.context.Incidents.Add(inci);
            Apartment temp = (Apartment)ApartmentDisplayComboBoxApartment.SelectedItem;
            EditingApartment.Incidents = temp.Incidents;
        }

        private void AptDeleteIncident(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Ertu Viss um að þú Viljir Eyða Atvikinu?", "Staðfesting", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {

            }
            else if (result == MessageBoxResult.Yes)
            {
                var curItem = ((ListBoxItem)ApartmentEditListboxIncidents.ContainerFromElement((Button)sender)).Content;
                ApartmentEditListboxIncidents.SelectedItem = (LokaVerkefniCL.Incident)curItem;
                LokaVerkefniCL.Incident inc = new LokaVerkefniCL.Incident();
                inc = (LokaVerkefniCL.Incident)ApartmentEditListboxIncidents.SelectedItem;
                DContext.context.Incidents.Remove(inc);
                DContext.context.SaveChanges();
            }


        }
        #endregion Editing

        #region NewApartment
        /// <summary>
        /// Changing Active Grid to New Apartment
        /// </summary>        
        private void AptNewaptm(object sender, RoutedEventArgs e)
        {
            // Creating a Blank Apartment Variable and asigning it to NewApartment
            NewApartment = new LokaVerkefniCL.Apartment();
            // Creating a Blank Adress and asigning it to NewAdress
            NewAddress = new LokaVerkefniCL.Address();
            // Connecting the blank Adress to the Blank Apartment
            NewApartment.Address = NewAddress;
            // Seting NewApartment as the Data context for the New Apartment Grid
            ApartmentNewApartment.DataContext = NewApartment;
            // Linking the Zip Combobox to the zip VievSource
            ApartmentNewApartmentComboBoxZip.DataContext = ZipViewSource;
            // Hiding the Display Grid and showing the New Apartment Grid
            ApartmentDisplay.Visibility = Visibility.Collapsed;
            ApartmentNewApartment.Visibility = Visibility.Visible;            
        }

        
        /// <summary>
        /// Saving the New Apartment and Adress to Database
        /// </summary>        
        private void AptAddAptment(object sender, RoutedEventArgs e)
        {
            // geting the selected zip code into a transitional variable to access its ID
            Post = (LokaVerkefniCL.Zip)ApartmentNewApartmentComboBoxZip.SelectedItem;
            // taking the zip id from transitional variable and setting it to NewAddress
            NewAddress.ZipID = Post.ID;
            // adding the new adress to database and checking if it exists to get its adress ID 
            DContext.context.Adresses.AddOrUpdate(a => a.AdressKey, NewAddress);
            DContext.context.SaveChanges();
            // taking the adress ID obtained from Database and giving it to NewApartment
            NewApartment.AddressID = NewAddress.ID;
            // adding the new Apartment to Database, if Current Adress already has an 
            // apartment registered updates that instead
            DContext.context.Apartments.AddOrUpdate(a => a.AddressID, NewApartment);
            DContext.context.SaveChanges();
            // Hiding the New Apartment Grid and showing the Display Grid
            ApartmentDisplay.Visibility = Visibility.Visible;
            ApartmentNewApartment.Visibility = Visibility.Collapsed;
        }
        #endregion NewApartment

        #endregion Apartments

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

        #region Tenants

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
            EditingTenant = (LokaVerkefniCL.Tenant)TenantDisplayComboboxNameList.SelectedItem;
            bool ApartmentInRent = false;
            foreach (Contract a in DContext.Contracts)
            {
                if (a.ApartmentID == EditingTenant.ID)
                {
                    ApartmentInRent = true;
                }
            }

            if (ApartmentInRent)
            {
                MessageBox.Show("Leigjandin er með Íbúð í leigu og ekki hægt að Eyða");
            }
            else
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
#endregion Tenants
    }
}
