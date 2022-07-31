using System;
using System.Collections.Generic;
using System.Text;
using GenSpace;

namespace StudentApp
{
    internal class Teacher: Person
    {
        public Teacher(string secondName, string firstName, int age, Gender gender, string phoneNumber, string subject) : base(secondName, firstName, age, gender, phoneNumber)
        {
            Subject = subject;
        }

        public string Subject { get; set; }

        public override void PrintInfo()
        {
            base.PrintInfo();
        }

        public override string Header()
        {
            return "Преподаватель";
        }

        public override string Footer()
        {
            return $"Предмет: {Subject}";
        }

    }
}
