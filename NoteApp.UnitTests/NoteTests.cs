using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NoteApp.UnitTests
{
    internal class NoteTests
    {
        private Note _note = null;
        [SetUp]
        public void CreateNote()
        {
            _note = new Note("Без названия", EnumNoteCategory.Job, "Пусто", DateTime.Now, DateTime.Now);
        }
        // тестирование названия
        [Test(Description = "Присвоение верного заголовка")]
        public void TestTitleSet_CorrectString()
        {
            var expected = "Title";
            Assert.DoesNotThrow(
            () => { _note.Title = expected; },
            "Не должно вохникать исключения");
        }
        [Test(Description = "Получение верного заголовка")]
        public void TestTitleGet_CorrectString()
        {
            var expected = "Title";
            _note.Title = expected;
            var actual = _note.Title;
            ClassicAssert.AreEqual(expected, actual, "Геттер Title возвращает неправильный заголовок");
        }
        [Test(Description = "Присвоение строки длиннее 50 символов в качестве фамилии")]
        public void TestTitleSet_LongString()
        {
            var wrongTitle = "TitleTitleTitleTitleTitleTitleTitleTitleTitleTitleTitle";
            Assert.Throws<ArgumentException>(
            () => { _note.Title = wrongTitle; },
            "Должно возникать исключение, если заголовок длиннее 50");
        }
        // тестирование категории
        [Test(Description = "Присвоение верной категории")]
        public void TestCategorySet_CorrectValue()
        {
            var expected = EnumNoteCategory.Home;
            Assert.DoesNotThrow(
            () => { _note.Category = expected; },
            "Не должно вохникать исключения");
        }
        [Test(Description = "Получение верной категории")]
        public void TestCategoryGet_CorrectString()
        {
            var expected = EnumNoteCategory.Home;
            _note.Category = expected;
            var actual = _note.Category;
            ClassicAssert.AreEqual(expected, actual, "Геттер Category возвращает неправильную категорию");
        }
        // тестирование текста
        [Test(Description = "Присвоение верного текста")]
        public void TestTextSet_CorrectValue()
        {
            var expected = "Какой-то текст";
            Assert.DoesNotThrow(
            () => { _note.NoteText = expected; },
            "Не должно вохникать исключения");
        }
        [Test(Description = "Получение верного текста")]
        public void TestTextGet_CorrectString()
        {
            var expected = "Какой-то текст";
            _note.NoteText = expected;
            var actual = _note.NoteText;
            ClassicAssert.AreEqual(expected, actual, "Геттер NoteText возвращает неправильный текст");
        }
        // тестирование даты создания
        [Test(Description = "Присвоение верной даты создания")]
        public void TestCreationTimeSet_CorrectValue()
        {
            var expected = DateTime.Now;
            Assert.DoesNotThrow(
            () => { _note.CreationTime = expected; },
            "Не должно вохникать исключения");
        }
        [Test(Description = "Получение верной даты создания")]
        public void TestCreationTimeGet_CorrectString()
        {
            var expected = DateTime.Now;
            _note.CreationTime = expected;
            var actual = _note.CreationTime;
            ClassicAssert.AreEqual(expected, actual, "Геттер CreationTime возвращает неправильную дату");
        }
        // тестирование даты изменения
        [Test(Description = "Присвоение верной даты изменеия")]
        public void TestTimeOfLastChangeSet_CorrectValue()
        {
            var expected = DateTime.Now;
            Assert.DoesNotThrow(
            () => { _note.TimeOfLastChange = expected; },
            "Не должно вохникать исключения");
        }
        [Test(Description = "Получение верной даты изменеия")]
        public void TestTimeOfLastChangeGet_CorrectString()
        {
            var expected = DateTime.Now;
            _note.TimeOfLastChange = expected;
            var actual = _note.TimeOfLastChange;
            ClassicAssert.AreEqual(expected, actual, "Геттер TimeOfLastChange возвращает неправильную дату");
        }
    }
}