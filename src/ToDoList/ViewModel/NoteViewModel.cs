using System.Data.Entity;
using System.Linq;
using ToDoList.Models;
using ToDoList.ViewModel;

namespace ToDoList
{
    class NoteViewModel : BaseViewModel<Note>
    {
        private int activityId;

        public NoteViewModel(int id) : base()
        {
            activityId = id;

            db.Notes.Where(p => p.ActivityId == id).Load();

            DirectoryCollection = db.Notes.Local;
        }

        public override void AddItem(string phrase)
        {
            DirectoryCollection.Add(new Note { ActivityId = activityId, Phrase = phrase });
        }

        public override void RemoveItem()
        {
            DirectoryCollection.Remove(SelectedValue);
        }

        public override void ToUp()
        {
            var index = base.GetIndex();
            var previousActivity = new Note { Phrase = DirectoryCollection[index - 1].Phrase, ActivityId = DirectoryCollection[index - 1].ActivityId };
            ShuffleNotes(index, index - 1, previousActivity);
        }

        public override void ToDown()
        {
            var index = base.GetIndex();
            var nextParameter = new Note { Phrase = DirectoryCollection[index + 1].Phrase, ActivityId = DirectoryCollection[index + 1].ActivityId };
            ShuffleNotes(index, index + 1, nextParameter);
        }

        private void ShuffleNotes(int selectedIndex, int changedIndex, Note note)
        {
            DirectoryCollection[changedIndex].Phrase = DirectoryCollection[selectedIndex].Phrase;
            DirectoryCollection[changedIndex].ActivityId = DirectoryCollection[selectedIndex].ActivityId;

            DirectoryCollection[selectedIndex].Phrase = note.Phrase;
            DirectoryCollection[selectedIndex].ActivityId = note.ActivityId;
        }

    }
}
