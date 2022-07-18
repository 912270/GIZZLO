using System;
using StudentClass;

namespace StudentApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Student kirill = new Student(1, "Selin", "Kirill", 23, true, "666-666");

            kirill.PrintInfo();

            kirill.Age = 24;

            kirill.PrintInfo();
            
        }
    }
}
