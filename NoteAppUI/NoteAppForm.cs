using NoteApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NoteAppUI
{
    /// <summary>
    /// Основная форма приложения
    /// </summary>
    public partial class NoteAppForm : Form
    {
        Project _notesProject;
        /// <summary>
        /// Список всех контактов
        /// </summary>
        public Project NotesProject
        {
            get
            { return _notesProject; }
            set
            { _notesProject = value; }
        }
        public NoteAppForm()
        {
            InitializeComponent();
            NotesProject = ProjectManager.LoadFromFile();
            if (NotesProject == null)
            {
                NotesProject = new Project(new List<Note>() { { new Note("Без названия", EnumNoteCategory.Job, "Текст отсутсвует", DateTime.Now, DateTime.Now)} });
            }
            RecreateNoteList();
        }
        /// <summary>
        /// Пересоздаёт лист со всеми заметками
        /// </summary>
        /// <param name="defaultSelectedIndex">номер контакта, который будет выделен после пересоздания</param>
        void RecreateNoteList(int defaultSelectedIndex = 0)
        {
            var notesNames = NotesProject.Notes.ToArray();
            NotesListBox.Items.Clear();
            for (int i = 0; i < notesNames.Length; i++)
            {
                NotesListBox.Items.Add(notesNames[i].Title);
            }
            NotesListBox.SelectedIndex = defaultSelectedIndex;
        }

        private void NotesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NotesListBox.SelectedItem != null)
            {
                var note = NotesProject.Notes[NotesListBox.SelectedIndex];

                Title.Text = note.Title;
                Category.Text = Convert.ToString(note.Category);
                NoteText.Text = note.NoteText;
                CreationTime.Text = note.CreationTime.ToString();
                TimeOfLastChange.Text = note.TimeOfLastChange.ToString();
            }
        }

        private void NoteAppForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProjectManager.SaveToFile(NotesProject);
        }

        private void AddNoteButton_Click(object sender, EventArgs e)
        {
            AddEditNoteForm addEditNoteForm = new AddEditNoteForm();
            var dialogResult = addEditNoteForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                Note note = addEditNoteForm.CurrentNote;
                NotesProject.Notes.Add(note);
                RecreateNoteList(NotesProject.Notes.ToArray().Length - 1);
                ProjectManager.SaveToFile(NotesProject);
            }
        }

        private void EditNoteButton_Click(object sender, EventArgs e)
        {
            AddEditNoteForm addEditNoteForm = new AddEditNoteForm();
            Note note = NotesProject.Notes[NotesListBox.SelectedIndex];
            addEditNoteForm.CurrentNote = note;
            var dialogResult = addEditNoteForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                RecreateNoteList(NotesListBox.SelectedIndex);
            }
        }

        private void RemoveNoteButton_Click(object sender, EventArgs e)
        {
            NotesProject.Notes.Remove(NotesProject.Notes[NotesListBox.SelectedIndex]);
            RecreateNoteList();
            ProjectManager.SaveToFile(NotesProject);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutFormProgram();
            aboutForm.ShowDialog();
        }
    }
}
