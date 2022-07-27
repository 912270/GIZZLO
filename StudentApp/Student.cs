﻿using System;
using System.Collections.Generic;
using System.Text;
using GenSpace;

namespace StudentApp
{
    class Student: Person
    {

        public Student(string secondName, string firstName, int age, Gender gender, string phoneNumber, string group) : base(secondName, firstName, age, gender, phoneNumber)
        {
            Group = group;
        }

        public string Group { get; set; }

        public override void PrintInfo()
        {

            Console.WriteLine("\nСтудент" +
                                $"\n{MainInfo()}" +
                                $"\nГруппа: {Group}");

        }

    }
}
