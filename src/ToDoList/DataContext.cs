using System.Data.Entity;
using ToDoList.Models;

namespace ToDoList
{
    class DataContext : DbContext
    {
        const string connection = "DefaultConnection";

        private static DataContext dataContext;

        private DataContext() : base(connection)
        {
        }

        public static DataContext GetDataContext()
        {
            if (dataContext == null)
            {
                dataContext = new DataContext();
            }
            return dataContext;
        }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Note> Notes { get; set; }
    }
}
