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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lokaverkefni
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        
        
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void btnApartments_Click(object sender, RoutedEventArgs e)
        {            
            Apartments aptwin = new Apartments();
            aptwin.ShowDialog();
        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            Persons custwin = new Persons();
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
    }
}
