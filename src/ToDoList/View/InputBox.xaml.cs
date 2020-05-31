using System.Windows;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for InputBox.xaml
    /// </summary>
    public partial class InputBox : Window
    {
        /// <summary>
        /// A phrase for output.
        /// </summary>
        public string Phrase
        {
            get;
            private set;
        }

        /// <summary>
        /// This constructor initializes an input box input. 
        /// </summary>
        public InputBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This constructor initializes an input box input. 
        /// </summary>
        /// <param name="phrase">
        /// A phrase to output.
        /// </param>
        public InputBox(string phrase)
        {
            InitializeComponent();
            Phrase = phrase;
            tbInput.Text = phrase;
        }

        /// <summary>
        /// Handles on click event.
        /// </summary>
        private void OnClickOk(object sender, RoutedEventArgs e)
        {
            Phrase = tbInput.Text;
            Close();
        }
    }
}