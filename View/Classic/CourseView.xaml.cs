using Learn.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Learn.View.Classic
{
    /// <summary>
    /// Interaction logic for CourseView.xaml
    /// </summary>
    public partial class CourseView : UserControl
    {
        public CourseView()
        {
            InitializeComponent();
        }

        private void CourseLoaded(object sender, RoutedEventArgs e)
        {
            if (DataContext!=null && DataContext is Course)
            {
                TabItem tabItem = new TabItem();
                tabItem.DataContext = (DataContext as Course).Items[0];
                tabItem.Content = new LessonView();
                Binding binding = new Binding("Name");
                binding.Source = tabItem.DataContext;
                tabItem.SetBinding(TabItem.HeaderProperty, binding);
                lessons.Items.Add(tabItem);
                tabItem.Focus();
            }
        }
    }
}
