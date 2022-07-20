using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApp
{
    internal class Person
    {
        private int id;
        private string secondName;
        private string firstName;
        private int age;
        private bool gender;
        private string phoneNumber;

        public Person(int id, string secondName, string firstName, int age, bool gender, string phoneNumber)
        {
            this.id = id;
            this.secondName = secondName;
            this.firstName = firstName;
            this.age = age;
            this.gender = gender;
            this.phoneNumber = phoneNumber;
        }

        public virtual void PrintInfo()
        {

            Console.WriteLine($"Фамилия: {secondName}\n" +
                              $"Имя: {firstName}\n" +
                              $"Возраст: {age}\n" +
                              $"Пол: {Gen(gender)}\n" +
                              $"Телефон: {phoneNumber}");

        }

        private string Gen(bool x)
        {
            if (x)
                return "Мужской";
            else return "Женский";
        }
    }
}
