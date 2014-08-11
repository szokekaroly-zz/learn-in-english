using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Learn.View.Classic;
using Learn.Model;
using System.Windows.Data;

namespace Learn.View
{
    /// <summary>
    /// Interaction logic for ClassicView.xaml
    /// </summary>
    public partial class ClassicView : UserControl
    {
        private Course _course;
        private CourseView _courseView;

        public ClassicView()
        {
            InitializeComponent();
        }

        #region Fájl menü
        private void New_Click(object sender, ExecutedRoutedEventArgs e)
        {
            _courseView = new CourseView();
            _course = (DataContext as CourseRepository).CreateCourse();
            _courseView.DataContext = _course;
            dock.Children.Add(_courseView);
        }

        private void Open_Click(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Save_Click(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

        }

        private void Close_Click(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
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
            LessonView lesson = new LessonView();
            lesson.DataContext = _course.CreateLesson();
            TabItem tabItem = new TabItem();
            tabItem.Content = lesson;
            Binding headerBinding = new Binding("Name");
            headerBinding.Source = lesson.DataContext;
            tabItem.SetBinding(TabItem.HeaderProperty, headerBinding);
            _courseView.lessons.Items.Add(tabItem);
            tabItem.Focus();
        }

        private void NewLesson_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _course != null;
        }

        private void OpenLesson_Click(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void OpenLesson_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _course != null;
        }

        private void DeleteLesson_Click(object sender, ExecutedRoutedEventArgs e)
        {
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
