using System;
using System.Collections.Generic;

namespace StudentApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Service serv = new Service();

            //serv.Add(new Student("Фамилия", "Имя", 29, Person.Gender.Male, "Телефон", "Группа"));

            //serv.Remove("Kirill", "Selin");

            //serv.ShowAll();

            serv.Show("Kirill", "Selin");

            serv.Show<Teacher>();

        }
    }
}
