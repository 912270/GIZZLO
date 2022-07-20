using System;

namespace StudentApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Student kirill = new Student(1, "Selin", "Kirill", 23, true, "666-666", "08.08 Прикладная информатика");

            Teacher andrey = new Teacher(1, "Smirnov", "Andrey", 38, true, "777-777", "Математика");

            kirill.PrintInfo();
            andrey.PrintInfo();

            kirill.Course = "09.03.02 Информатика";
            kirill.PrintInfo();

        }
    }
}
