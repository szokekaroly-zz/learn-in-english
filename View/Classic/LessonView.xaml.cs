using System.Windows;
using System.Windows.Controls;
using Learn.Model;

namespace Learn.View.Classic
{
    /// <summary>
    /// Interaction logic for LessonView.xaml
    /// </summary>
    public partial class LessonView : UserControl
    {
        public LessonView()
        {
            InitializeComponent();
        }

        private void LessonLoaded(object sender, RoutedEventArgs e)
        {
            if (DataContext!=null && DataContext is Course)
            {
                DataContext = (DataContext as Course).Items[0];
            }
        }
    }
}
