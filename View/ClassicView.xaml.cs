using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Learn.View
{
    /// <summary>
    /// Interaction logic for ClassicView.xaml
    /// </summary>
    public partial class ClassicView : UserControl
    {
        public ClassicView()
        {
            InitializeComponent();
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

        private void Close_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Close_Click(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
