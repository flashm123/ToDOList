using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using ToDoList.Models;
using ToDoList.ViewModel;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for NoteList.xaml
    /// </summary>
    public partial class NoteListWindow : Window
    {
        BaseViewModel<Note> noteViewModel;

        /// <summary>
        /// Initializes note window components.
        /// </summary>
        public NoteListWindow(int valueId)
        {
            InitializeComponent();
            noteViewModel = new NoteViewModel(valueId);
            base.DataContext = noteViewModel;
        }

        /// <summary>
        /// Add new note.
        /// </summary>
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var inputBox = new InputBox();
            inputBox.ShowDialog();

            if (inputBox.Phrase != null)
            {
                noteViewModel.AddItem(inputBox.Phrase);
            }
        }

        ///<inheritdoc/>
        protected override void OnClosing(CancelEventArgs e)
        {
            noteViewModel.SaveChanges();
            base.OnClosing(e);
        }

        /// <summary>
        /// Remove note.
        /// </summary>
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            noteViewModel.RemoveItem();
        }

        /// <summary>
        /// Change note.
        /// </summary>
        private void btnChnge_Click(object sender, RoutedEventArgs e)
        {
            var inputBox = new InputBox(noteViewModel.SelectedValue.Phrase);

            inputBox.ShowDialog();

            noteViewModel.SelectedValue.Phrase = inputBox.Phrase;
        }

        /// <summary>
        /// Move note up.
        /// </summary>
        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            noteViewModel.ToUp();
        }

        /// <summary>
        /// Move note down.
        /// </summary>
        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            noteViewModel.ToDown();
        }

        /// <summary>
        /// Save changes.
        /// </summary>
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            noteViewModel.SaveChanges();
            Close();
        }

        /// <summary>
        /// Close window.
        /// </summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handle changes in list view.
        /// </summary>
        private void lstViewRow_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            var listView = (ListView)sender;

            if (listView.SelectedItem == null)
            {
                btnUp.IsEnabled = false;
                btnDown.IsEnabled = false;
                btnRemove.IsEnabled = false;
            }
            else
            {
                btnRemove.IsEnabled = true;

                if (listView.SelectedIndex == 0)
                {
                    btnUp.IsEnabled = false;
                    btnDown.IsEnabled = true;
                }
                else
                {
                    if (listView.SelectedIndex == listView.Items.Count - 1)
                    {
                        btnDown.IsEnabled = false;
                        btnUp.IsEnabled = true;
                    }
                    else
                    {
                        btnUp.IsEnabled = true;
                        btnDown.IsEnabled = true;
                    }
                }
            }
        }
    }
}
