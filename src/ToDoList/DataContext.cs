using System.Data.Entity;
using ToDoList.Models;

namespace ToDoList
{
    ///<inheritdoc/>
    class DataContext :DbContext
    {

        const string connection = "DefaultConnection";
        
        public DataContext() : base(connection)
        {
        }

        /// <summary>
        /// Gets or sets activities set..
        /// </summary>
        public DbSet<Activity> Activities { get; set; }

        /// <summary>
        /// Gets or sets notes set.
        /// </summary>
        public DbSet<Note> Notes { get; set; }
    }
}
