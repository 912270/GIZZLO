using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace StudentApp
{
    internal class Service
    {

        List<Person> persons = new List<Person>();

        //XmlSerializer savex = new XmlSerializer(typeof(List<Person>));

        //private JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

        public Service()
        {
            persons.Add(new Teacher("Sergey", "Kamyshev", 38, Person.Gender.Male, "111-111", "Программирование на языке C#"));
            persons.Add(new Student("Selin", "Kirill", 23, Person.Gender.Male, "222-222", "ПС-3"));
            persons.Add(new Student("Lebedev", "Valeriy", 25, Person.Gender.Male, "333-333", "ПС-3"));
            persons.Add(new Student("Uchanova", "Marina", 27, Person.Gender.Female, "444-444", "ПС-3"));
            persons.Add(new Student("Ovchinnikov", "Aleksey", 21, Person.Gender.Male, "555-555", "ПС-3"));
            persons.Add(new Student("Kolesnikov", "Valeriy", 26, Person.Gender.Male, "666-666", "ПС-3"));
            persons.Add(new Student("Grigorev", "Ivan", 24, Person.Gender.Male, "777-777", "ПС-3"));
            persons.Add(new Student("Egorov", "Vitaliy", 20, Person.Gender.Male, "888-888", "ПС-3"));
            persons.Add(new Student("Portnov", "Evgeniy", 28, Person.Gender.Male, "999-999", "ПС-3"));
            persons.Add(new Student("Semenov", "Vladislav", 22, Person.Gender.Male, "101-101", "ПС-3"));
            persons.Add(new Student("Vasilyev", "Max", 29, Person.Gender.Male, "110-110", "ПС-3"));

        }

        public void Add(Person person) //Добавление
        {
            persons.Add(person);
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

        public void ShowAll() //Отображение всех персон
        {
            foreach (var person in persons)
            {
                person.PrintInfo();
            }
        }

        public void Show(string name, string lastname) //Отображение по имени и фамилии
        {
            foreach (var person in persons)
            {
                if (person.FirstName == name && person.SecondName == lastname)
                {
                    person.PrintInfo();
                    break;
                }
            }
        }

        public void Show<T>() //Отображение по классу(типу)
        {
            foreach (var person in persons)
            {
                if (person is T)
                {
                    person.PrintInfo();
                }
            }
        }

        /*public async void Save()
        {
            using (FileStream fs = new FileStream("person.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(fs, persons, options);
            }
        }*/

        /*public async void Load()
        {
            using (FileStream fs = new FileStream("person.json", FileMode.Open))
            {
                persons.AddRange(await JsonSerializer.DeserializeAsync<List<Student>>(fs));
            }
        }*/

        /*public async void Read()
        {
            using (StreamReader r = new StreamReader("person.json"))
            {
                persons = JsonConvert.DeserializeObject<List<Person>>(r.ReadToEnd());
            }
        }*/


        /*public void Save()
        {
            using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
            {
                savex.Serialize(fs, persons);
            }
        }

        public void Load()
        {
            using (FileStream fs = new FileStream("persons.xml", FileMode.Open))
            {
                persons = savex.Deserialize(fs) as List<Person>;
            }
        }*/

    }
}
