using System;
using System.Collections.Generic;
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
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Lokaverkefni
{
    /// <summary>
    /// Interaction logic for Apartments.xaml
    /// </summary>
    public partial class Apartments : Window
    {
        CollectionViewSource viewSource = new CollectionViewSource();
        CollectionViewSource zipviewSource = new CollectionViewSource();
        LokaverkefniDataContext DContext = new LokaverkefniDataContext();
        LokaVerkefniCL.Apartment Editing;
        public Apartments()
        {
            InitializeComponent();
            viewSource.Source = DContext.Apartments;
            zipviewSource.Source = DContext.Zip;
            DataContext = viewSource;
            
            
        }

        private void EnableEdit(object sender, RoutedEventArgs e)
        {
            cBoxeZip.DataContext = zipviewSource;
            Editing = (LokaVerkefniCL.Apartment)cBoxApartment.SelectedItem;
            Display.Visibility = Visibility.Collapsed;
            Edit.Visibility = Visibility.Visible;
            Edit.DataContext = Editing;
            cBoxeZip.SelectedIndex = Editing.Address.ZipID -1;
        }

        private void Newaptm(object sender, RoutedEventArgs e)
        {
            LokaVerkefniCL.Apartment newap = new LokaVerkefniCL.Apartment();
            Display.Visibility = Visibility.Collapsed;
            Newapt.Visibility = Visibility.Visible;
            Newapt.DataContext = newap;
            cBoxnZip.DataContext = zipviewSource;
        }

        private void AddAptment(object sender, RoutedEventArgs e)
        {
            LokaVerkefniCL.Apartment newap = (LokaVerkefniCL.Apartment)Newapt.DataContext;
            LokaVerkefniCL.Zip Post = (LokaVerkefniCL.Zip)cBoxnZip.SelectedItem;
            LokaVerkefniCL.Address adr = new LokaVerkefniCL.Address();
            adr.Street = txtnStreet.Text;
            adr.HouseNumber = txtnHouseNumber.Text;
            adr.ApartmentNumber = txtnApartmentNumber.Text;
            newap.Address = adr;
            adr.ZipID = Post.ID;
            DContext.context.Adresses.Add(adr);
            DContext.context.SaveChanges();
            newap.AddressID = adr.ID;            
            DContext.context.Apartments.Add(newap);
            DContext.context.SaveChanges();
            Display.Visibility = Visibility.Visible;
            Newapt.Visibility = Visibility.Collapsed;
        }

        private void SaveChanges(object sender, RoutedEventArgs e)
        {
            LokaVerkefniCL.Zip post = (LokaVerkefniCL.Zip)cBoxeZip.SelectedItem;
            Editing.Address.ZipID = post.ID;
            DContext.context.SaveChanges();
            Edit.Visibility = Visibility.Collapsed;
            Display.Visibility = Visibility.Visible;
        }
    }
}
