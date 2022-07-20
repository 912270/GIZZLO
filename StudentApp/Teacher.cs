using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApp
{
    internal class Teacher: Person
    {
        public Teacher(int id, string secondName, string firstName, int age, bool gender, string phoneNumber, string subject) : base(id, secondName, firstName, age, gender, phoneNumber)
        {
            Subject = subject;
        }

        public string Subject { get; set; }

        public override void PrintInfo()
        {

            Console.WriteLine("\nПреподаватель");
            base.PrintInfo();
            Console.WriteLine($"Предмет: {Subject}");

        }

    }
}
