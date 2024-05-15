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
    }
}
