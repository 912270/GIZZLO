using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApp
{
    class Student: Person
    {

        public Student(int id, string secondName, string firstName, int age, bool gender, string phoneNumber, string course) : base(id, secondName, firstName, age, gender, phoneNumber)
        {
            Course = course;
        }

        public string Course { get; set; }

        public override void PrintInfo()
        {

            Console.WriteLine("\nСтудент");
            base.PrintInfo();
            Console.WriteLine($"Курс: {Course}");

        }



    }
}
