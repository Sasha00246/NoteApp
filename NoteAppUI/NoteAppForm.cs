using NoteApp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NoteApp.Project;
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
            CategoryBox.SelectedIndex = 0;
            if (NotesProject == null)
            {
                NotesProject = new Project(new List<Note>() { { new Note("Без названия", EnumNoteCategory.Job, "Текст отсутсвует", DateTime.Now, DateTime.Now)} });
            }
            else
            {
                var note = NotesProject.CurrentNote;

                Title.Text = note.Title;
                Category.Text = Convert.ToString(note.Category);
                NoteText.Text = note.NoteText;
                CreationTime.Text = note.CreationTime.ToString();
                TimeOfLastChange.Text = note.TimeOfLastChange.ToString();
            }
            CreateNoteList();
        }
        /// <summary>
        /// Пересоздаёт лист со всеми заметками
        /// </summary>
        /// <param name="defaultSelectedIndex">номер контакта, который будет выделен после пересоздания</param>
        void RecreateNoteList(int selectedCategory)
        {
            List<Note> notes = new List<Note>();
            notes = NotesProject.GetSortedNotes(selectedCategory);
            NotesListBox.Items.Clear();
            foreach (var note in notes)
            {
                NotesListBox.Items.Add(note.Title);
            }
        }
        void CreateNoteList()
        {
            List<Note> notes = NotesProject.Notes;
            notes.Sort(new NoteComparer());
            NotesListBox.Items.Clear();
            foreach (var note in notes)
            {
                NotesListBox.Items.Add(note.Title);
            }
        }

        private void NotesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NotesListBox.SelectedItem != null)
            {
                string titleListBox = (string)NotesListBox.SelectedItem;
                List<Note> notes = new List<Note>();
                notes = NotesProject.Notes;
                foreach (var note in notes)
                {
                    if (titleListBox == note.Title)
                    {
                        Title.Text = note.Title;
                        Category.Text = Convert.ToString(note.Category);
                        NoteText.Text = note.NoteText;
                        CreationTime.Text = note.CreationTime.ToString();
                        TimeOfLastChange.Text = note.TimeOfLastChange.ToString();

                        NotesProject.CurrentNote = note;
                        ProjectManager.SaveToFile(NotesProject);
                    }
                }
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
                CreateNoteList();
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
                CreateNoteList();
            }
        }

        private void RemoveNoteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить заметку?", "Удаление заметки", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                NotesProject.Notes.Remove(NotesProject.Notes[NotesListBox.SelectedIndex]);
                CreateNoteList();
                ProjectManager.SaveToFile(NotesProject);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutForm = new AboutFormProgram();
            aboutForm.ShowDialog();
        }

        private void CategoryBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CategoryBox.SelectedItem == "All")
            {
                CreateNoteList();
            }
            else
            {
                RecreateNoteList(CategoryBox.SelectedIndex);
            }
            if (NotesListBox.Items.Count == 0)
            {
                Title.Text = "Без названия";
                Category.Text = "-";
            }
        }
        private void NoteAppForm_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyValue == (char)Keys.Delete)
                {
                    RemoveNoteButton_Click(RemoveNoteButton, null);
                }
        }

    }
}
