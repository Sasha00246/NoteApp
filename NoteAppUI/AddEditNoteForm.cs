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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace NoteAppUI
{
    public partial class AddEditNoteForm : Form
    {
        Note _currentNote;
        /// <summary>
        /// Редактируемый/добавляемый контакт
        /// </summary>
        public Note CurrentNote
        {
            get { return _currentNote; }
            set { _currentNote = value; }
        }
        public AddEditNoteForm()
        {
            InitializeComponent();
        }

        private void AddEditNoteForm_Shown(object sender, EventArgs e)
        {
            if (CurrentNote != null)
            {
                Title.Text = CurrentNote.Title;
                CategoryBox.Text = Convert.ToString(CurrentNote.Category);
                NoteText.Text = CurrentNote.NoteText;
                CreationTime.Value = CurrentNote.CreationTime;
                TimeOfLastChange.Value = CurrentNote.TimeOfLastChange;
            }
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            try
            {
                string title = Title.Text;
                var category = (EnumNoteCategory)CategoryBox.SelectedItem;
                string noteText = NoteText.Text;
                DateTime creationTime = CreationTime.Value;
                DateTime timeOfLastChange = TimeOfLastChange.Value;

                if (CurrentNote == null)
                {
                    CurrentNote = new Note(title, (EnumNoteCategory)CategoryBox.SelectedItem, noteText, creationTime, timeOfLastChange);
                }
                else
                {
                    CurrentNote.Title = title;
                    CurrentNote.Category = category;
                    CurrentNote.NoteText = noteText;
                    CurrentNote.CreationTime = creationTime;
                    CurrentNote.TimeOfLastChange = timeOfLastChange;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку "Отмена"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
