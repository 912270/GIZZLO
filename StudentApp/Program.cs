using System;
using System.Collections.Generic;

namespace StudentApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Person> persons = new List<Person>(11)
            {
                new Teacher("Sergey", "Kamyshev", 38, Person.Gender.Male, "111-111", "Программирование на языке C#"),
                new Student("Selin", "Kirill", 23, Person.Gender.Male, "222-222", "ПС-3"),
                new Student("Lebedev", "Valeriy", 25, Person.Gender.Male, "333-333", "ПС-3"),
                new Student("Uchanova", "Marina", 27, Person.Gender.Female, "444-444", "ПС-3"),
                new Student("Ovchinnikov", "Aleksey", 21, Person.Gender.Male, "555-555", "ПС-3"),
                new Student("Kolesnikov", "Valeriy", 26, Person.Gender.Male, "666-666", "ПС-3"),
                new Student("Grigorev", "Ivan", 24, Person.Gender.Male, "777-777", "ПС-3"),
                new Student("Egorov", "Vitaliy", 20, Person.Gender.Male, "888-888", "ПС-3"),
                new Student("Portnov", "Evgeniy", 28, Person.Gender.Male, "999-999", "ПС-3"),
                new Student("Semenov", "Vladislav", 22, Person.Gender.Male, "101-101", "ПС-3"),
                new Student("Vasilyev", "Max", 29, Person.Gender.Male, "110-110", "ПС-3")

            };

            foreach (var person in persons)
            {
                person.PrintInfo();
            }

        }
    }
}
