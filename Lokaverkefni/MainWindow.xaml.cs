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
            Ibud.Visibility = Visibility.Hidden;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (Ibud.Visibility == Visibility.Hidden)
            {
                Ibud.Visibility = Visibility.Visible;
                Notandi.Visibility = Visibility.Hidden;
            }

            else if (Ibud.Visibility == Visibility.Visible)
            {
                Ibud.Visibility = Visibility.Hidden;
                Notandi.Visibility = Visibility.Visible;
            }
            
        }
    }
}
