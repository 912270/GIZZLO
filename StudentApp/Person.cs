using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApp
{
    internal class Person
    {
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        private Gender gender;

        public Person(string secondName, string firstName, int age, Gender gender, string phoneNumber)
        {
            this.SecondName = secondName;
            this.FirstName = firstName;
            this.Age = age;
            this.gender = gender;
            this.PhoneNumber = phoneNumber;
        }

        public virtual void PrintInfo()
        {

            Console.WriteLine($"Фамилия: {SecondName}\n" +
                              $"Имя: {FirstName}\n" +
                              $"Возраст: {Age}\n" +
                              $"Пол: {gender.ToString()}\n" +
                              $"Телефон: {PhoneNumber}");

        }

        public enum Gender
        {
            Male,
            Female
        }
    }
}
