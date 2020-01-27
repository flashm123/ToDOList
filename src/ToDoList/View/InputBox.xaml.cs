using System.Windows;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for InputBox.xaml
    /// </summary>
    public partial class InputBox : Window
    {
        public string Phrase
        {
            get;
            private set;
        }

        public InputBox()
        {
            InitializeComponent();
        }

        public InputBox(string phrase)
        {
            InitializeComponent();
            Phrase = phrase;
            tbInput.Text = phrase;
        }

        private void OnClickOk(object sender, RoutedEventArgs e)
        {
            Phrase = tbInput.Text;
            Close();
        }
    }
}