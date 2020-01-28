using System.Collections.ObjectModel;

namespace ToDoList.ViewModel
{
    abstract class BaseViewModel<T>
    {

        protected DataContext db;

        public ObservableCollection<T> DirectoryCollection
        { get; set; }

        public BaseViewModel()
        {
            db = DataContext.GetDataContext();
            DirectoryCollection = new ObservableCollection<T>();
        }

        public T SelectedValue
        {
            get;
            set;
        }

        public abstract void AddItem(string item="");

        public abstract void RemoveItem();

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public abstract void ToUp();

        public abstract void ToDown();
      
        protected int GetIndex()
        {
            return DirectoryCollection.IndexOf(SelectedValue);
        }

    }
}
