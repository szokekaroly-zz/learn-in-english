using Learn.Model;
using System;
using System.Windows;
using System.ComponentModel;

namespace Learn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Courses Courses { get; set; }

        private void OnModified(object sender, EventArgs e)
        {
            if (Courses.IsModified)
                Title = "Tanulj! Angolul*";
            else
                Title = "Tanulj! Angolul";
        }

        public MainWindow()
        {
            InitializeComponent();
            Courses = new Courses(new CourseRepository(AppDomain.CurrentDomain.BaseDirectory));
            Courses.LoadAll();
            DataContext = Courses;
            Courses.Modified += OnModified;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (Courses.IsModified)
            {
                switch (MessageBox.Show("Az aktuális tanfolyam megváltozott. Menti a változásokat?",
                    "Kilépés",MessageBoxButton.YesNoCancel,MessageBoxImage.Question,MessageBoxResult.Cancel))
                {
                    case MessageBoxResult.Cancel:
                        e.Cancel = true;
                        break;
                    case MessageBoxResult.No:
                        e.Cancel = false;
                        break;
                    case MessageBoxResult.Yes:
                        Courses.SaveAll();
                        e.Cancel = false;
                        break;
                }
            }
        }
    }
}
