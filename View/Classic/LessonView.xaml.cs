using System.Windows.Controls;
using System.Windows.Input;
using Learn.Model;
using System;

namespace Learn.View.Classic
{
    /// <summary>
    /// Interaction logic for LessonView.xaml
    /// </summary>
    public partial class LessonView : UserControl
    {
        public LessonView()
        {
            InitializeComponent();
        }

        public Lesson Lesson
        {
            get { return DataContext as Lesson; }
        }

        private void NewWord_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (wordEditor != null)
                e.CanExecute = wordEditor.DataContext == null;
        }

        private void NewWord_Click(object sender, ExecutedRoutedEventArgs e)
        {
            wordEditor.DataContext = Lesson.CreateWord();
            hungarian.IsReadOnly = false;
            foreign.IsReadOnly = false;
            wordEditor.Focus();
        }

        private void DeleteWord_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (wordEditor != null && wordsGrid != null)
                e.CanExecute = wordEditor.DataContext == null && wordsGrid.SelectedIndex > -1;
        }

        private void DeleteWord_Click(object sender, ExecutedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void EditWord_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

        }

        private void EditWord_Click(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void SaveWord_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (wordEditor != null)
                e.CanExecute = wordEditor.DataContext != null;
        }

        private void SaveWord_Click(object sender, ExecutedRoutedEventArgs e)
        {
            wordEditor.DataContext = null;
            hungarian.IsReadOnly = false;
            foreign.IsReadOnly = false;
            hungarian.Text = "";
            foreign.Text = "";
        }

        private void CancelWord_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

        }

        private void CancelWord_Click(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void LessonView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //alaphelyzetben üres, gombbal lehet szerkeszteni
            wordEditor.DataContext = null;
        }
    }
}
