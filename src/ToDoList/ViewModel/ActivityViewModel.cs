﻿using System.Data.Entity;
using ToDoList.Models;
using ToDoList.ViewModel;

namespace ToDoList
{
    /// <summary>
    /// This class defines Activity view model.
    /// </summary>
    class ActivityViewModel : BaseViewModel<Activity>
    {
        public ActivityViewModel() : base()
        {
            db.Activities.Load();

            DirectoryCollection = db.Activities.Local;
        }

        public int GetSelectedActivityId()
        {
            return SelectedValue.Id;
        }

        ///<inheritdoc/>
        public override void RemoveItem()
        {
            DirectoryCollection.Remove(SelectedValue);
        }

        ///<inheritdoc/>
        public override void AddItem(string item)
        {
            DirectoryCollection.Add(new Activity { Name = item, Type = item });
        }

        ///<inheritdoc/>
        public override void ToUp()
        {
            var index = base.GetIndex();
            var previousParameter = new Activity { Name = DirectoryCollection[index - 1].Name, HasNoteList = DirectoryCollection[index - 1].HasNoteList, Type = DirectoryCollection[index - 1].Type };
            ShuffleActivities(index, index - 1, previousParameter);
        }

        ///<inheritdoc/>
        public override void ToDown()
        {
            var index = base.GetIndex();
            var nextParameter = new Activity { Name = DirectoryCollection[index + 1].Name, HasNoteList = DirectoryCollection[index + 1].HasNoteList, Type = DirectoryCollection[index + 1].Type };
            ShuffleActivities(index, index + 1, nextParameter);
        }

        /// <summary>
        /// Replaces one record with another
        /// </summary>
        private void ShuffleActivities(int selectedIndex, int changedIndex, Activity parameter)
        {
            DirectoryCollection[changedIndex].Name = DirectoryCollection[selectedIndex].Name;
            DirectoryCollection[changedIndex].HasNoteList = DirectoryCollection[selectedIndex].HasNoteList;
            DirectoryCollection[changedIndex].Type = DirectoryCollection[selectedIndex].Type;

            DirectoryCollection[selectedIndex].HasNoteList = parameter.HasNoteList;
            DirectoryCollection[selectedIndex].Type = parameter.Type;
            DirectoryCollection[selectedIndex].Name = parameter.Name;
        }
    }
}
