using GenSpace;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonLibrary.Model
{
    public class Repo
    {

        List<Person> persons = new List<Person>();
        List<Teacher> teachers = new List<Teacher>();
        List<Student> students = new List<Student>();

        //XmlSerializer savex = new XmlSerializer(typeof(List<Person>));

        //private JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

        public Repo()
        {
            teachers.Add(new Teacher("Kamyshev", "Sergey", 38, Gender.Male, "111-111", "Программирование на языке C#"));
            students.Add(new Student("Selin", "Kirill", 23, Gender.Male, "222-222", "ПС-3"));
            students.Add(new Student("Lebedev", "Valeriy", 25, Gender.Male, "333-333", "ПС-3"));
            students.Add(new Student("Uchanova", "Marina", 27, Gender.Female, "444-444", "ПС-3"));
            students.Add(new Student("Ovchinnikov", "Aleksey", 21, Gender.Male, "555-555", "ПС-3"));
            students.Add(new Student("Kolesnikov", "Valeriy", 26, Gender.Male, "666-666", "ПС-3"));
            students.Add(new Student("Grigorev", "Ivan", 24, Gender.Male, "777-777", "ПС-3"));
            students.Add(new Student("Egorov", "Vitaliy", 20, Gender.Male, "888-888", "ПС-3"));
            students.Add(new Student("Portnov", "Evgeniy", 28, Gender.Male, "999-999", "ПС-3"));
            students.Add(new Student("Semenov", "Vladislav", 22, Gender.Male, "101-101", "ПС-3"));
            students.Add(new Student("Vasilyev", "Max", 29, Gender.Male, "110-110", "ПС-3"));

            persons.AddRange(teachers);
            persons.AddRange(students);

        }

        public List<Person> list()
        {
            return persons;
        }

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

        public void Add(Person person) //Добавление
        {
            foreach (var pers in persons)
            {
                if (person.FirstName == pers.FirstName && person.SecondName == pers.SecondName)
                {
                    throw new Exception("Пользователь с таким именем уже существует");
                }
                else persons.Add(person);
                break;
            }
        }

        public void Remove(string name, string lastname)  //Удаление
        {
            foreach (var person in persons)
            {
                if (person.FirstName == name && person.SecondName == lastname)
                {
                    persons.Remove(person);
                    break;
                }
            }
        }

        public void Update<T>(string name, string lastname, int age, string phone, string optInfo)
        {
            if (typeof(T).Equals(typeof(Teacher)))
            {
                foreach (var person in teachers)
                {
                    if (person.FirstName == name && person.SecondName == lastname)
                    {
                        person.Age = age;
                        person.PhoneNumber = phone;
                        person.Subject = optInfo;
                        break;
                    }
                }
            }
            else if (typeof(T).Equals(typeof(Student)))
            {
                foreach (var person in students)
                {
                    if (person.FirstName == name && person.SecondName == lastname)
                    {
                        person.Age = age;
                        person.PhoneNumber = phone;
                        person.Group = optInfo;
                        break;
                    }
                }
            }
        }
    }
}
