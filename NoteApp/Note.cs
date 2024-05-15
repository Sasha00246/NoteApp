using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NoteApp
{
    /// <summary>
    /// Класс заметок, хранящий информацию о названии, содержании,
    /// категории, времени создании и последнего изменения.
    /// </summary>
    public class Note : ICloneable
    {
        string _title;
        EnumNoteCategory _category;
        string _noteText;
        DateTime _creationTime;
        DateTime _timeOfLastChange;

        public Note(string title, EnumNoteCategory category, string noteText)
        {
            Title = title;
            Category = category;
            NoteText = noteText;
        }

        /// <summary>
        /// Возвращает и задает название (не длиннее 50 символов)
        /// </summary>
        public string Title
        {
            get { return _title; }
            set
            {
                if (value == "")
                {
                    _title = "Без названия";
                }
                if (_title != value)
                {
                    if (value.Length < 50)
                    {
                        _title = value;
                    }
                    else
                    {
                        throw new ArgumentException("Название не может быть длинее 50 символов!");
                    }
                }
                _timeOfLastChange = DateTime.Now;
            }
        }
        /// <summary>
        /// Возвращает и задает категорию согласно списку категорий
        /// </summary>
        public EnumNoteCategory Category
        {
            get { return _category; }
            set
            {
                if (value == EnumNoteCategory.Job || value == EnumNoteCategory.Home
                || value == EnumNoteCategory.HealthAndSports || value == EnumNoteCategory.People
                || value == EnumNoteCategory.Documents || value == EnumNoteCategory.Finance
                || value == EnumNoteCategory.Others)
                {
                    _category = value;
                    _timeOfLastChange = DateTime.Now;
                }
                else
                {
                    throw new ArgumentException("Категория должна быть выбрана из списка");
                }
            }
        }
        /// <summary>
        /// Возвращает и задает текст заметки
        /// </summary>
        public string NoteText
        {
            get { return _noteText;  }
            set
            {
                if (_noteText != value)
                {
                    if (value != "")
                    {
                        _noteText = value;
                    }
                    else
                    {
                        throw new ArgumentException("Заметка не может быть пустой!");
                    }
                }
            }
        }
        /// <summary>
        /// Возвращает время создания
        /// </summary>
        public DateTime CreationTime
        {
            get { return _creationTime; }
        }
        /// <summary>
        /// Возвращает время последнего изменения
        /// </summary>
        public DateTime TimeOfLastChange 
        { 
            get { return _timeOfLastChange; } 
        }
        /// <summary>
        /// Метод клонирования заметки
        /// </summary>
        /// <returns> Возвращает новую, эдентичную старой заметку</returns>
        public object Clone()
        {
            return new Note(Title, Category, NoteText);
        }
    }
}
