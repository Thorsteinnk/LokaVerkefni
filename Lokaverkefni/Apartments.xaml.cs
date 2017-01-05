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
        LokaVerkefniCL.Apartment EditingApartment;
        LokaVerkefniCL.Apartment NewApartment;
        LokaVerkefniCL.Address NewAddress;
        LokaVerkefniCL.Zip Post;
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
            EditingApartment = (LokaVerkefniCL.Apartment)cBoxApartment.SelectedItem;
            Display.Visibility = Visibility.Collapsed;
            Edit.Visibility = Visibility.Visible;
            Edit.DataContext = EditingApartment;
            cBoxeZip.SelectedIndex = EditingApartment.Address.ZipID -1;
        }

        private void Newaptm(object sender, RoutedEventArgs e)
        {
            NewApartment = new LokaVerkefniCL.Apartment();
            NewAddress = new LokaVerkefniCL.Address();
            NewApartment.Address = NewAddress;
            Display.Visibility = Visibility.Collapsed;
            Newapt.Visibility = Visibility.Visible;
            Newapt.DataContext = NewApartment;
            cBoxnZip.DataContext = zipviewSource;
        }

        private void AddAptment(object sender, RoutedEventArgs e)
        {
            NewApartment = (LokaVerkefniCL.Apartment)Newapt.DataContext;
            Post = (LokaVerkefniCL.Zip)cBoxnZip.SelectedItem;
            NewAddress = NewApartment.Address;            
            NewAddress.ZipID = Post.ID;
            DContext.context.Adresses.Add(NewAddress);
            DContext.context.SaveChanges();
            NewApartment.AddressID = NewAddress.ID;            
            DContext.context.Apartments.Add(NewApartment);
            DContext.context.SaveChanges();
            Display.Visibility = Visibility.Visible;
            Newapt.Visibility = Visibility.Collapsed;
        }

        private void SaveChanges(object sender, RoutedEventArgs e)
        {
            Post = (LokaVerkefniCL.Zip)cBoxeZip.SelectedItem;
            EditingApartment.Address.ZipID = Post.ID;
            DContext.context.SaveChanges();
            Edit.Visibility = Visibility.Collapsed;
            Display.Visibility = Visibility.Visible;
        }

        private void aptEditCancel(object sender, RoutedEventArgs e)
        {


        }

        private void cBoxApartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
