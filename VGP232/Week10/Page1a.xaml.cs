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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Week10
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1a : Page
    {
        public Page1a()
        {
            InitializeComponent();
        }

        private void GoToPage1B(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1b());
        }

    }
}
