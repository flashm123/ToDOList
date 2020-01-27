using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace ToDoList.Models
{
    [Table("Notes")]
    public class Note : INotifyPropertyChanged
    {
        private string phrase;
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

        public int Id
        {
            get;
            set;
        }

        public int ActivityId
        {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
