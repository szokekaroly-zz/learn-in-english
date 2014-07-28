using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Learn.Model;

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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CoursesRepository repo = new CoursesRepository();
            repo.Directory = @".\";
            Course  course=repo.NewCourse();
            course.Name="Első tanfolyam";
            course.Remark="Megjegyzés";
            Lesson lesson = new Lesson();
            course.Add(lesson);
            lesson.Name = "Első lecke";
            lesson.Remark = "Megjegyzés";
            Word word = new Word();
            word.Hungarian = "magyar";
            word.Foreign = "hungarian";
            lesson.Add(word);
            repo.SaveAll();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CoursesRepository repo = new CoursesRepository();
            repo.Directory = @".\";
            repo.LoadAll();
        }
    }
}
