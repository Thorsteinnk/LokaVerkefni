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
    /// Interaction logic for Contracts.xaml
    /// </summary>
    public partial class Contracts : Window
    {
        CollectionViewSource ContractViewSource = new CollectionViewSource();
        LokaverkefniDataContext DContext = new LokaverkefniDataContext();

        public Contracts()
        {
            InitializeComponent();
            ContractViewSource.Source = DContext.Contracts;
            DataContext = ContractViewSource;
        }

        private void ContractMainBtnNewContract_Click(object sender, RoutedEventArgs e)
        {
            ContractMain.Visibility = Visibility.Collapsed;
            ContractNew.Visibility = Visibility.Visible;
        }

        private void ContractNewBtnSave_Click(object sender, RoutedEventArgs e)
        {
            ContractNew.Visibility = Visibility.Collapsed;
            ContractMain.Visibility = Visibility.Visible;
        }

        private void ContractMainBtnEditContract_Click(object sender, RoutedEventArgs e)
        {
            ContractMain.Visibility = Visibility.Collapsed;
            ContractEdit.Visibility = Visibility.Visible;
        }

        private void ContractEditBtnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            ContractEdit.Visibility = Visibility.Collapsed;
            ContractMain.Visibility = Visibility.Visible;
        }
    }
}
