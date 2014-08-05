using Learn.Model;
using System.Windows;

namespace Learn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CoursesRepository courses= new CoursesRepository();
            courses.Directory="./";
            courses.LoadAll();
            DataContext = courses[0];
        }
    }
}
