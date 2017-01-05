﻿using System;
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
        CollectionViewSource viewSource = new CollectionViewSource();
        LokaverkefniDataContext DContext = new LokaverkefniDataContext();

        public Contracts()
        {
            InitializeComponent();
            viewSource.Source = DContext.Contracts;
            DataContext = viewSource;
        }
    }
}
