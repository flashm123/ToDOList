using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace ToDoList.Models
{
    /// <summary>
    /// This class defines Activity model.
    /// </summary>
    public class Activity : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string name;

        /// <summary>
        /// Gets or sets activity name.
        /// </summary>
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

        /// <summary>
        /// Gets or sets activity type.
        /// </summary>
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

        /// <summary>
        /// Identifies whether activity has note list
        /// </summary>
        [NotMapped]
        public bool HasNoteList
        {
            get
            {
                return ((Type == Types.ActivityCollection) || (Type == Types.DetailedPlan)) ? true : false;
            }
            set { hasNoteList = value; }
        }

        /// <summary>
        /// Gets or sets a collection of notes.
        /// </summary>
        public ICollection<Note> Notes
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
