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

namespace Lokaverkefni
{
    /// <summary>
    /// Interaction logic for Tenants.xaml
    /// </summary>
    public partial class Tenants : Window
    {

        CollectionViewSource viewSource = new CollectionViewSource();
        CollectionViewSource zipviewSource = new CollectionViewSource();
        LokaverkefniDataContext DContext = new LokaverkefniDataContext();


        public Tenants()
        {
            InitializeComponent();
            viewSource.Source = DContext.Tenants;
            zipviewSource.Source = DContext.Zip;
            DataContext = viewSource;
        }

       
        private void TenBtnClkNew(object sender, RoutedEventArgs e)
        {

        }

        private void TenBtnClkEdit(object sender, RoutedEventArgs e)
        {


        }
    }
}
