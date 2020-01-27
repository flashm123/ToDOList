using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using ToDoList.Models;
using ToDoList.ViewModel;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ActivityWindow : Window
    {
        BaseViewModel<Activity> activityViewModel;

        public ActivityWindow()
        {
            InitializeComponent();
            activityViewModel = new ActivityViewModel();
            base.DataContext = activityViewModel;
        }

        public void Button_Click_RemoveActivity(object sender, RoutedEventArgs e)
        {
            activityViewModel.RemoveItem();
        }

        public void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            activityViewModel.AddItem();
        }

        public void Button_Click_NoteList(object sender, RoutedEventArgs e)
        {
            var noteListWindow = new NoteListWindow(activityViewModel.SelectedValue.Id);
            noteListWindow.Show();
        }

        public void Button_Click_Up(object sender, RoutedEventArgs e)
        {
            activityViewModel.ToUp();
        }

        public void Button_Click_Down(object sender, RoutedEventArgs e)
        {
            activityViewModel.ToDown();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            activityViewModel.SaveChanges();

            base.OnClosing(e);
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            activityViewModel.SaveChanges();
            base.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            base.Close();
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            var dataGrid = (DataGrid)sender;

            if (dataGrid.SelectedItem == null)
            {
                btnUp.IsEnabled = false;
                btnDown.IsEnabled = false;
                btnRemove.IsEnabled = false;
            }
            else
            {
                btnRemove.IsEnabled = true;

                if (dataGrid.SelectedIndex == 0)
                {
                    btnUp.IsEnabled = false;
                    btnDown.IsEnabled = true;
                }
                else
                {
                    if (dataGrid.SelectedIndex == dataGrid.Items.Count - 1)
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
