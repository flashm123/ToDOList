using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace ToDoList.Models
{
    /// <summary>
    /// This class defines Note model.
    /// </summary>
    [Table("Notes")]
    public class Note : INotifyPropertyChanged
    {
        private string phrase;

        /// <summary>
        /// Gets or sets note phrase.
        /// </summary>
        public string Phrase
        {
            get
            {
                return phrase;
            }
            set
            {
                phrase = value;
                OnPropertyChanged("Phrase");
            }
        }

        /// <summary>
        /// Gets or sets note id.
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets note activity id.
        /// </summary>
        public int ActivityId
        {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        public void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
