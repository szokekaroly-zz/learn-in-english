using Learn.Model;
using System;
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
            CoursesRepository.Directory = AppDomain.CurrentDomain.BaseDirectory;
            CoursesRepository.LoadAll();
            DataContext = CoursesRepository;
        }
    }
}
