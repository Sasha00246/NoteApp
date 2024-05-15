using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NoteApp
{
    /// <summary>
    /// Класс, реализующий сериализацию проекта с контактами
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// Путь к файлу сохранения проекта с контактами
        /// </summary>
        private const string SaveFilePath = @".\Save.json";
        /// <summary>
        /// Метод, сохраняющий в файл проект с контактами
        /// </summary>
        /// <param name="project"></param>
        public static void SaveToFile(Project project)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(SaveFilePath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, project);
            }
        }
        /// <summary>
        /// Метод, возвращающий проект с контактами из файла
        /// </summary>
        /// <returns>Эксземпляр класса Project из файла</returns>
        public static Project LoadFromFile()
        {
            Project project = null;
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader sr = new StreamReader(SaveFilePath))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                project = serializer.Deserialize<Project>(reader);
            }
            return project;
        }
    }
}
