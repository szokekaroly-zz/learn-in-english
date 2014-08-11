using Learn.Model;
using System.Windows;

namespace Learn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CourseRepository CoursesRepository { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            CoursesRepository = new CourseRepository();
            DataContext = CoursesRepository;
        }
    }
}
