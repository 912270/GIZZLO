using GenSpace;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PersonLibrary.Model
{
    public class Repo<T> where T: Person
    {

        /// <summary>
        /// Список персон
        /// </summary>
        List<T> persons = new List<T>();

        /// <summary>
        /// Список учителей
        /// </summary>
        //List<Teacher> teachers = new List<Teacher>();
        /// <summary>
        /// Список студентов
        /// </summary>
        //List<Student> students = new List<Student>();

        public Repo()
        {
            /*teachers.Add(new Teacher("Kamyshev", "Sergey", 38, Gender.Male, "111-111", "Программирование на языке C#"));
            students.Add(new Student("Selin", "Kirill", 23, Gender.Male, "222-222", "ПС-3"));
            students.Add(new Student("Lebedev", "Valeriy", 25, Gender.Male, "333-333", "ПС-3"));
            students.Add(new Student("Uchanova", "Marina", 27, Gender.Female, "444-444", "ПС-3"));
            students.Add(new Student("Ovchinnikov", "Aleksey", 21, Gender.Male, "555-555", "ПС-3"));
            students.Add(new Student("Kolesnikov", "Valeriy", 26, Gender.Male, "666-666", "ПС-3"));
            students.Add(new Student("Grigorev", "Ivan", 24, Gender.Male, "777-777", "ПС-3"));
            students.Add(new Student("Egorov", "Vitaliy", 20, Gender.Male, "888-888", "ПС-3"));
            students.Add(new Student("Portnov", "Evgeniy", 28, Gender.Male, "999-999", "ПС-3"));
            students.Add(new Student("Semenov", "Vladislav", 22, Gender.Male, "101-101", "ПС-3"));
            students.Add(new Student("Vasilyev", "Max", 29, Gender.Male, "110-110", "ПС-3"));*/

            Load();
        }

        /// <summary>
        /// Список персон
        /// </summary>
        public List<T> list { get; set; }

        /// <summary>
        /// Чтение персоны из списка
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastname"></param>
        /// <returns></returns>
        public T Read(string name, string lastname)
        {
            foreach (var person in list)
            {
                if (person.Equals(name, lastname))
                {
                    return person;
                }
            }
            return null;
        }

        /// <summary>
        /// Добавление персоны
        /// </summary>
        /// <param name="person"></param>
        /// <exception cref="ExistingPersonException"></exception>
        public void Add(T person)
        {
            foreach (var pers in list)
            {
                if (person.Equals(pers))
                {
                    throw new ExistingPersonException("Пользователь с таким именем уже существует");
                }
                else list.Add(person);
                this.Save();
                break;
            }
        }

        /// <summary>
        /// Удаление персоны
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastname"></param>
        /// <exception cref="NotFoundPersonException"></exception>
        public void Remove(string name, string lastname)
        {
            foreach (var person in list)
            {
                if (person.FirstName == name && person.SecondName == lastname)
                {
                    list.Remove(person);
                    this.Save();
                    break;
                }
                else throw new NotFoundPersonException("Пользователя с таким именем не существует");
            }
        }

        /// <summary>
        /// Обновление персоны
        /// </summary>
        /// <param name="oldPerson"></param>
        /// <param name="newPerson"></param>
        public void Update(T oldPerson, T newPerson)
        {
            list.Remove(oldPerson);
            list.Add(newPerson);
        }

        /// <summary>
        /// Формирование имени файла
        /// </summary>
        /// <returns></returns>
        private string FileNameSet() => string.Format("{0}.json", typeof(T).Name);

        /// <summary>
        /// Сохранение в JSON
        /// </summary>
        public void Save()
        {
            var json = JsonConvert.SerializeObject(persons, Formatting.Indented);
            File.WriteAllText(FileNameSet(), json);

            /*var jsonStudent = JsonConvert.SerializeObject(students, Formatting.Indented);
            File.WriteAllText(@"student.json", jsonStudent);

            var jsonTeacher = JsonConvert.SerializeObject(teachers, Formatting.Indented);
            File.WriteAllText(@"teacher.json", jsonTeacher);*/
        }

        /// <summary>
        /// Загрузка из JSON
        /// </summary>
        public void Load()
        {
            persons = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(FileNameSet()));

            /*students = JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(@"student.json"));

            teachers = JsonConvert.DeserializeObject<List<Teacher>>(File.ReadAllText(@"teacher.json"));*/
        }
    }
}
