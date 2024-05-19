using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.UnitTests
{
    internal class ProjectManagerTests
    {
        Project _notesProject;

        [SetUp]
        public void CreateNote()
        {
            List<Note> notes = new List<Note>();
            _notesProject = new Project(notes);
            notes.Add(new Note("Рабочие задачи", EnumNoteCategory.Job, "1. Составить приказы на увольнение сотрудников; 2. Занести приказы в реестр;", DateTime.Now, DateTime.Now));
            notes.Add(new Note("Обязательные платежи", EnumNoteCategory.Finance, "В этом месяце необходимо заплатить за интернет и по кредиту", DateTime.Now, DateTime.Now));
            _notesProject.Notes = notes;
        }
        [Test(Description = "Сохранение проекта заметок")]
        public void TestSave_CorrectString()
        {
            Assert.DoesNotThrow(
            () => {
                ProjectManager.SaveToFile(_notesProject);
            },
            "Не должно вохникать исключения");
        }
        [Test(Description = "Загрузка проекта заметок")]
        public void TestLoad_CorrectString()
        {
            Assert.DoesNotThrow(
            () => {
                _notesProject = ProjectManager.LoadFromFile();
            },
            "Не должно вохникать исключения");
        }
    }
}
