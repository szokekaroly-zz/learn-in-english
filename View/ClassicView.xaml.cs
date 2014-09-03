using Learn.Model;
using Learn.View.Classic;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Learn.View
{
    /// <summary>
    /// Interaction logic for ClassicView.xaml
    /// </summary>
    public partial class ClassicView : UserControl
    {
        private Course _course;
        private CourseView _courseView;
        public Courses Courses
        {
            get { return DataContext as Courses; }
        }

        public ClassicView()
        {
            InitializeComponent();
        }

        private void CreateCourse(Course course)
        {
            _courseView = new CourseView();
            _course = course;
            _courseView.DataContext = _course;
            dock.Children.Add(_courseView);
        }

        private void CreateLesson(Lesson lesson)
        {
            LessonView lessonView = new LessonView();
            lessonView.DataContext = lesson;

            TabItem tabItem = new TabItem();
            tabItem.Content = lessonView;
            Binding headerBinding = new Binding("Name");
            headerBinding.Source = lessonView.DataContext;
            tabItem.SetBinding(TabItem.HeaderProperty, headerBinding);
            _courseView.lessons.Items.Add(tabItem);
            tabItem.Focus();
        }
        #region Fájl menü

        private void New_Click(object sender, ExecutedRoutedEventArgs e)
        {
            CreateCourse(Courses.CreateCourse());
        }

        private void Open_Click(object sender, ExecutedRoutedEventArgs e)
        {
            OpenCourse open = new OpenCourse();
            open.DataContext = Courses;
            if (open.ShowDialog()==true)
            {
                CreateCourse(open.Course);
            }
        }

        private void Save_Click(object sender, ExecutedRoutedEventArgs e)
        {
            Courses.SaveAll();
        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Courses.IsModified;
        }

        private void Close_Click(object sender, ExecutedRoutedEventArgs e)
        {
            if (_course.IsModified)
            {
                switch (MessageBox.Show("Az aktuális tanfolyam megváltozott. Menti a változásokat?",
                    "Kilépés", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.Cancel))
                {
                    case MessageBoxResult.Cancel:
                        return;
                    case MessageBoxResult.No:
                        Courses.Reload(_course);
                        break;
                    case MessageBoxResult.Yes:
                        Courses.SaveAll();
                        break;
                }
                _course = null;
                _courseView = null;
                dock.Children.Clear();
            }
        }

        private void Close_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _course != null;
        }

        private void Exit_Click(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
        #endregion

        #region Lecke menü
        private void NewLesson_Click(object sender, ExecutedRoutedEventArgs e)
        {
            CreateLesson(_course.CreateLesson());
        }

        private void NewLesson_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _course != null;
        }

        private void OpenLesson_Click(object sender, ExecutedRoutedEventArgs e)
        {
            OpenLesson open = new OpenLesson();
            open.DataContext = _course;
            if (open.ShowDialog() == true)
            {
                CreateLesson(open.Lesson);
            }
        }

        private void OpenLesson_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _course != null;
        }

        private void DeleteLesson_Click(object sender, ExecutedRoutedEventArgs e)
        {
            if (MessageBox.Show("Valóban törölni szeretné a leckét?",
                "Törlés megerősítése",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                LessonView view = _courseView.lessons.SelectedContent as LessonView;
                Lesson lesson = view.Lesson;
                _course.Remove(lesson);
                _courseView.lessons.Items.RemoveAt(_courseView.lessons.SelectedIndex);
            }
        }

        private void DeleteLesson_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _course != null && _courseView.lessons.SelectedIndex > -1;
        }

        private void CloseLesson_Click(object sender, ExecutedRoutedEventArgs e)
        {
            _courseView.lessons.Items.RemoveAt(_courseView.lessons.SelectedIndex);
        }

        private void CloseLesson_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _course != null && _courseView.lessons.SelectedIndex > -1;
        }

        #endregion

    }
}
