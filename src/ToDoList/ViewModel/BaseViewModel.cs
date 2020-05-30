using System.Collections.ObjectModel;

namespace ToDoList.ViewModel
{
    /// <summary>
    /// This class defines base view model.
    /// </summary>
    abstract class BaseViewModel<T>
    {

        protected DataContext db;

        /// <summary>
        /// Gets or sets directory collection.
        /// </summary>
        public ObservableCollection<T> DirectoryCollection
        { get; set; }

        /// <summary>
        /// This constructor initializes the new BaseViewModel 
        /// </summary>
        public BaseViewModel()
        {
            db = new DataContext();
            DirectoryCollection = new ObservableCollection<T>();
        }

        /// <summary>
        /// Gets or sets SelectedValue.
        /// </summary>
        public T SelectedValue
        {
            get;
            set;
        }

        /// <summary>
        /// Add record to directory collection.
        /// </summary>
        public abstract void AddItem(string item="");

        /// <summary>
        /// Remove record from directory collection.
        /// </summary>
        public abstract void RemoveItem();

        /// <summary>
        /// Save changes in database.
        /// </summary>
        public void SaveChanges()
        {
            db.SaveChanges();
        }

        /// <summary>
        /// Move record to up in databse.
        /// </summary>
        public abstract void ToUp();

        /// <summary>
        /// Move record to down in databse.
        /// </summary>
        public abstract void ToDown();
      
        /// <summary>
        /// Get index of the selected record.
        /// </summary>
        protected int GetIndex()
        {
            return DirectoryCollection.IndexOf(SelectedValue);
        }

    }
}
