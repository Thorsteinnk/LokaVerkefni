using LokaVerkefniCL;
using System;
using System.Collections.Generic;
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
        CollectionViewSource ApartmentviewSource = new CollectionViewSource();
        /// <summary>
        /// View Source for Zip Codes Created
        /// </summary>
        CollectionViewSource ApartmentzipviewSource = new CollectionViewSource();
        /// <summary>
        /// Data Context Created
        /// </summary>
        LokaverkefniDataContext DContext = new LokaverkefniDataContext();
        /// <summary>
        /// Creating a Variable for editing Apartments, accessable to all Functions
        /// </summary>
        LokaVerkefniCL.Apartment EditingApartment;
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
        

        #region MainWindow
        public MainWindow()
        {
            InitializeComponent();
            // Connecting the main Viewsource to Data Context - Apartments
            ApartmentviewSource.Source = DContext.Apartments;
            // Conecting the zip Viewsource to Data Context - Zip so it can access all Zip codes
            ApartmentzipviewSource.Source = DContext.Zip;
            // Setting the main View Source as the Data Context for Apartments
            gridApartment.DataContext = ApartmentviewSource;

        }

        private void btnApartments_Click(object sender, RoutedEventArgs e)
        {
            HideGrids();
            gridApartment.Visibility = Visibility.Visible;      
            //Apartments aptwin = new Apartments();
            //aptwin.ShowDialog();
        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            Tenants custwin = new Tenants();
            custwin.ShowDialog();
        }

        private void btnContracts_Click(object sender, RoutedEventArgs e)
        {
            Contracts contrwin = new Contracts();
            contrwin.ShowDialog();
        }

        private void HideGrids()
        {
            gridHome.Visibility = Visibility.Collapsed;
            gridApartment.Visibility = Visibility.Collapsed;
            gridContracts.Visibility = Visibility.Collapsed;
            gridCustomers.Visibility = Visibility.Collapsed;
        }
        #endregion MainWindow
        #region Apartments

        public void AptDeleteApartment(object sender, RoutedEventArgs e)
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
            ApartmentEditComboBoxZip.DataContext = ApartmentzipviewSource;
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
            LokaVerkefniCL.Incident inci = new LokaVerkefniCL.Incident(EditingApartment.ID);
            DContext.context.Incidents.Add(inci);
            LokaVerkefniCL.Apartment temp = (LokaVerkefniCL.Apartment)ApartmentDisplayComboBoxApartment.SelectedItem;
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
            ApartmentNewApartmentComboBoxZip.DataContext = ApartmentzipviewSource;
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
    }
}
