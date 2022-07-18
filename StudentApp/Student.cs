using System;
using System.Collections.Generic;
using System.Text;

namespace StudentClass
{
    class Student
    {
        private int id;
        private string secondName;
        private string firstName;
        private int age;
        private bool gender;
        private string phoneNumber;

        public Student(int id, string secondName, string firstName, int age, bool gender, string phoneNumber)
        {
            this.id = id;
            this.secondName = secondName;
            this.firstName = firstName;
            this.age = age;
            this.gender = gender;
            this.phoneNumber = phoneNumber;
        }

        public void PrintInfo()
        {

            Console.WriteLine($"Фамилия: {SecondName}\n" +
                              $"Имя: {FirstName}\n" +
                              $"Возраст: {Age}\n" +
                              $"Пол: {Gen(Gender)}\n" +
                              $"Телефон: {PhoneNumber}\n");

        }

        public string SecondName
            { get { return secondName; }  set { secondName = value; } }

        public string FirstName
            { get { return firstName; } set { firstName = value; } }

        public int Age
            { get { return age; } set { age = value; } }

        public bool Gender
            { get { return gender; } set { gender = value; } }

        public string PhoneNumber
            { get { return phoneNumber; } set { phoneNumber = value; } }

        private string Gen(bool x)
        {
            if (x)
                return "Мужской";
            else return "Женский";
        }


    }
}
