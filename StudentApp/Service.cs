using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;
using GenSpace;
using PersonLibrary.Model;

namespace StudentApp
{
    internal class Service
    {

        Repo rep = new Repo();

        public void ShowAll() //Отображение всех персон
        {
            foreach (var person in rep.list())
            {
                Console.WriteLine(person.SPrintInfo());
            }
        }

        public void Show(string name, string lastname) //Отображение по имени и фамилии
        {
            foreach (var person in rep.list())
            {
                if (person.FirstName == name && person.SecondName == lastname)
                {
                    Console.WriteLine(person.SPrintInfo());
                    break;
                }
            }
        }

        public void Show<T>() //Отображение по классу(типу)
        {
            foreach (var person in rep.list())
            {
                if (person is T)
                {
                    Console.WriteLine(person.SPrintInfo());
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
