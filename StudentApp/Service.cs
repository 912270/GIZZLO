﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;
using GenSpace;

namespace StudentApp
{
    internal class Service
    {

        List<Person> persons = new List<Person>();

        //XmlSerializer savex = new XmlSerializer(typeof(List<Person>));

        //private JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

        public Service()
        {
            persons.Add(new Teacher("Kamyshev", "Sergey", 38, Gender.Male, "111-111", "Программирование на языке C#"));
            persons.Add(new Student("Selin", "Kirill", 23, Gender.Male, "222-222", "ПС-3"));
            persons.Add(new Student("Lebedev", "Valeriy", 25, Gender.Male, "333-333", "ПС-3"));
            persons.Add(new Student("Uchanova", "Marina", 27, Gender.Female, "444-444", "ПС-3"));
            persons.Add(new Student("Ovchinnikov", "Aleksey", 21, Gender.Male, "555-555", "ПС-3"));
            persons.Add(new Student("Kolesnikov", "Valeriy", 26, Gender.Male, "666-666", "ПС-3"));
            persons.Add(new Student("Grigorev", "Ivan", 24, Gender.Male, "777-777", "ПС-3"));
            persons.Add(new Student("Egorov", "Vitaliy", 20, Gender.Male, "888-888", "ПС-3"));
            persons.Add(new Student("Portnov", "Evgeniy", 28, Gender.Male, "999-999", "ПС-3"));
            persons.Add(new Student("Semenov", "Vladislav", 22, Gender.Male, "101-101", "ПС-3"));
            persons.Add(new Student("Vasilyev", "Max", 29, Gender.Male, "110-110", "ПС-3"));

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

        /*public void Start()
        {
            ShowMenu();
        }*/

        /*public void ShowMenu()
        {
            Console.WriteLine("\n=====================================\n" +
                              $"\t\tМеню\n" +
                              $"=====================================\n" +
                              $"1. Отобразить... \n" +
                              $"2. Добавить \n" +
                              $"3. Удалить ");
            var menu = int.Parse(Console.ReadLine());
        }*/

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
