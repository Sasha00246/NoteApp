using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    public class Project
    {
        private List<Note> _notes;
        public List<Note> Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }
        public Project(List<Note> notes)
        {
            Notes = notes;
        }
        public class NoteComparer : IComparer<Note>
        {
            public int Compare(Note x, Note y)
            {
                return y.TimeOfLastChange.CompareTo(x.TimeOfLastChange);
            }
        }

        public List<Note> GetSortedNotes(int selectedCategory)
        {
            List<Note> notes = new List<Note>();
            var noteCategorys = this.Notes.ToArray();
            for (int i = 0; i < noteCategorys.Length; i++)
            {
                int x = (int)noteCategorys[i].Category;
                if (x == selectedCategory - 1)
                    notes.Add(noteCategorys[i]);
            }
            notes.Sort(new NoteComparer());
            return notes;
        }

        private Note _currentNote;
        public Note CurrentNote
        {
            get { return _currentNote; }
            set { _currentNote = value; }
        }
    }
}
