using GenSpace;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PersonLibrary.Model
{
    public class Repo
    {

        /// <summary>
        /// Список персон
        /// </summary>
        List<Person> persons = new List<Person>();
        /// <summary>
        /// Список учителей
        /// </summary>
        List<Teacher> teachers = new List<Teacher>();
        /// <summary>
        /// Список студентов
        /// </summary>
        List<Student> students = new List<Student>();

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

            persons.AddRange(teachers);
            persons.AddRange(students);

            //Save();
        }

        /// <summary>
        /// Вывод списка персон
        /// </summary>
        /// <returns></returns>
        public List<Person> list()
        {
            return persons;
        }

        /// <summary>
        /// Чтение персоны из списка
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastname"></param>
        /// <returns></returns>
        public object Read(string name, string lastname)
        {
            foreach (var person in persons)
            {
                if (person.FirstName == name && person.SecondName == lastname)
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
        /// <exception cref="Exception"></exception>
        public void Add(Person person)
        {
            foreach (var pers in persons)
            {
                if (person.FirstName == pers.FirstName && person.SecondName == pers.SecondName)
                {
                    throw new ExistingPersonException("Пользователь с таким именем уже существует");
                }
                else persons.Add(person);
                break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastname"></param>
        /// <exception cref="Exception"></exception>
        public void Remove(string name, string lastname)
        {
            foreach (var person in persons)
            {
                if (person.FirstName == name && person.SecondName == lastname)
                {
                    persons.Remove(person);
                    break;
                }
                else throw new NotFoundPersonException("Пользователя с таким именем не существует");
            }
        }

        /// <summary>
        /// Обновление персоны
        /// </summary>
        /// <param name="person"></param>
        public void Update(Person person)
        {
            var oldPerson =  Read(person.FirstName, person.SecondName);
            (oldPerson as Person).Age = person.Age;
            (oldPerson as Person).PhoneNumber = person.PhoneNumber;
            if (person is Teacher)
                (oldPerson as Teacher).Subject = (person as Teacher).Subject;
            else if (person is Student)
                (oldPerson as Student).Group = (person as Student).Group;
        }

        /// <summary>
        /// Сохранение в JSON
        /// </summary>
        public void Save()
        {
            var jsonPerson = JsonConvert.SerializeObject(persons, Formatting.Indented);
            File.WriteAllText(@"person.json", jsonPerson);

            var jsonStudent = JsonConvert.SerializeObject(students, Formatting.Indented);
            File.WriteAllText(@"student.json", jsonStudent);

            var jsonTeacher = JsonConvert.SerializeObject(teachers, Formatting.Indented);
            File.WriteAllText(@"teacher.json", jsonTeacher);
        }

        /// <summary>
        /// Загрузка из JSON
        /// </summary>
        public void Load()
        {
            students = JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText(@"student.json"));

            teachers = JsonConvert.DeserializeObject<List<Teacher>>(File.ReadAllText(@"teacher.json"));
        }
    }
}
