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

namespace TwitterViewer
{
    /// <summary>
    /// Interaction logic for categoriesEditWindow.xaml
    /// </summary>
    public partial class categoriesEditWindow : Window
    {
        public categoriesEditWindow()
        {
            InitializeComponent();
        }

        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }
}
