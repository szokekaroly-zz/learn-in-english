using Learn.Model;
using System.Windows;
using System.Windows.Input;

namespace Learn.View.Classic
{
    /// <summary>
    /// Interaction logic for OpenCourse.xaml
    /// </summary>
    public partial class OpenCourse : Window
    {

        public Course Course { get; private set; }

        public OpenCourse()
        {
            InitializeComponent();
        }

        private void Open_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (courses != null)
                e.CanExecute = courses.SelectedIndex > -1;
        }

        private void Open_Click(object sender, ExecutedRoutedEventArgs e)
        {
            Course = courses.SelectedItem as Course;
            DialogResult = true;
        }
    }
}
