using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            throw new NotImplementedException();
        }

        private void New_Click(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Save_Click(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}
