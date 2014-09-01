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
        public enum WordEditor { NONE, NEW, EDIT };
        public WordEditor WordEditorState = WordEditor.NONE;
        private Word _wordEditor;
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
            e.CanExecute = WordEditorState == WordEditor.NONE;
        }

        private void NewWord_Click(object sender, ExecutedRoutedEventArgs e)
        {
            _wordEditor = new Word();
            wordsGrid.IsEnabled = false;
            WordEditorState = WordEditor.NEW;
            wordEditor.DataContext = _wordEditor;
            hungarian.IsReadOnly = false;
            foreign.IsReadOnly = false;
            wordEditor.Focus();
        }

        private void DeleteWord_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (wordsGrid != null)
                e.CanExecute = WordEditorState==WordEditor.NONE && wordsGrid.SelectedItem != null;
            else
                e.CanExecute = false;
        }

        private void DeleteWord_Click(object sender, ExecutedRoutedEventArgs e)
        {
            Lesson.Remove(wordsGrid.SelectedItem as Word);
        }

        private void EditWord_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (wordsGrid != null)
                e.CanExecute = WordEditorState==WordEditor.NONE && wordsGrid.SelectedItem != null;
            else
                e.CanExecute = false;
        }

        private void EditWord_Click(object sender, ExecutedRoutedEventArgs e)
        {
            _wordEditor = new Word(wordsGrid.SelectedItem as Word);
            wordsGrid.IsEnabled = false;
            WordEditorState = WordEditor.EDIT;
            wordEditor.DataContext = _wordEditor;
            hungarian.IsReadOnly = false;
            foreign.IsReadOnly = false;
            wordEditor.Focus();
        }

        private void SaveWord_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = WordEditorState != WordEditor.NONE;
        }

        private void SaveWord_Click(object sender, ExecutedRoutedEventArgs e)
        {
            switch (WordEditorState)
            {
                case WordEditor.NONE:
                    break;
                case WordEditor.NEW:
                    Word word = Lesson.CreateWord();
                    word.Hungarian=_wordEditor.Hungarian;
                    word.Foreign=_wordEditor.Foreign;
                    break;
                case WordEditor.EDIT:
                    (wordsGrid.SelectedItem as Word).Hungarian = _wordEditor.Hungarian;
                    (wordsGrid.SelectedItem as Word).Foreign = _wordEditor.Foreign;
                    break;
            }
            WordEditorState = WordEditor.NONE;
            wordEditor.DataContext = null;
            hungarian.IsReadOnly = false;
            foreign.IsReadOnly = false;
            hungarian.Text = "";
            foreign.Text = "";
            wordsGrid.IsEnabled = true;
        }

        private void CancelWord_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = WordEditorState != WordEditor.NONE;
        }

        private void CancelWord_Click(object sender, ExecutedRoutedEventArgs e)
        {
            wordEditor.DataContext = null;
            hungarian.IsReadOnly = false;
            foreign.IsReadOnly = false;
            hungarian.Text = "";
            foreign.Text = "";
            wordsGrid.IsEnabled = true;
        }

        private void LessonView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //alaphelyzetben üres, gombbal lehet szerkeszteni
            wordEditor.DataContext = null;
        }
    }
}
