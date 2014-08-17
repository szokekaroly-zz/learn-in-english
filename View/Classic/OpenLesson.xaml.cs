using Learn.Model;
using System.Windows;
using System.Windows.Input;

namespace Learn.View.Classic
{
    /// <summary>
    /// Interaction logic for OpenLesson.xaml
    /// </summary>
    public partial class OpenLesson : Window
    {
        public Lesson Lesson { get; private set; }

        public OpenLesson()
        {
            InitializeComponent();
        }

        private void Open_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (lessons != null)
                e.CanExecute = lessons.SelectedItem != null;
        }

        private void Open_Click(object sender, ExecutedRoutedEventArgs e)
        {
            Lesson = lessons.SelectedItem as Lesson;
            DialogResult = true;
        }
    }
}
