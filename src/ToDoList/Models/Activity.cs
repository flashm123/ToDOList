using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace ToDoList.Models
{
    public class Activity : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string name;
        public string Name
        {
            get { return name; }

            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string type;

        public string Type
        {
            get { return type; }

            set
            {
                type = value;
                OnPropertyChanged("Type");
                OnPropertyChanged("HasNoteList");
            }
        }

        private bool hasNoteList;

        [NotMapped]
        public bool HasNoteList
        {
            get
            {
                return ((Type == Types.ActivityCollection) || (Type == Types.DetailedPlan)) ? true : false;
            }
            set { hasNoteList = value; }
        }

        public ICollection<Note> Notes
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
