using System.Data.Entity;
using ToDoList.Models;

namespace ToDoList
{
    class DataContext :DbContext
    {

        const string connection = "DefaultConnection";
        public DataContext() : base(connection)
        {
        }
        public DbSet<Activity> Activities { get; set; }

        public DbSet<Note> Notes { get; set; }
    }
}
