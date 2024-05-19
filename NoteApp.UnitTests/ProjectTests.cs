using NUnit.Framework.Legacy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.UnitTests
{
    internal class ProjectTests
    {
        Project _notesProject;

        [SetUp]
        public void CreateNote()
        {
            List<Note> notes = new List<Note>();
            _notesProject = new Project(notes);
        }
        [Test(Description = "Присвоение верного списка")]
        public void TestContactsSet_CorrectString()
        {
            Assert.DoesNotThrow(
            () => {
                List<Note> notes = new List<Note>();
                notes.Add(new Note("Рабочие задачи", EnumNoteCategory.Job, "1. Составить приказы на увольнение сотрудников; 2. Занести приказы в реестр;", DateTime.Now, DateTime.Now));
                _notesProject.Notes = notes;
            },
            "Не должно вохникать исключения");
        }
        [Test(Description = "Получение верного списка")]
        public void TestNotesGet_CorrectString()
        {
            List<Note> notes = new List<Note>();
            notes.Add(new Note("Рабочие задачи", EnumNoteCategory.Job, "1. Составить приказы на увольнение сотрудников; 2. Занести приказы в реестр;", DateTime.Now, DateTime.Now));
            var expected = notes;

            _notesProject.Notes = expected;
            var actual = _notesProject.Notes;
            ClassicAssert.AreEqual(expected, actual, "Геттер Contacts возвращает неправильный список");
        }
    }
}
