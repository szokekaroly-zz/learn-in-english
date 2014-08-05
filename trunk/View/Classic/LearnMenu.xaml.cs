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

namespace Learn.View.Classic
{
    /// <summary>
    /// Interaction logic for LearnMenu.xaml
    /// </summary>
    public partial class LearnMenu : UserControl
    {
        public LearnMenu()
        {
            InitializeComponent();
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        private void Open_Click(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("open");
        }

        private void New_Click(object sender, ExecutedRoutedEventArgs e)
        {

        }

    }
}
