using System;
using System.Collections.Generic;
using System.Text;
using GenSpace;

namespace PersonLibrary.Model
{
    public abstract class Person
    {
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public Gender gender { get; private set; }

        public Person(string secondName, string firstName, int age, Gender gender, string phoneNumber)
        {
            SecondName = secondName;
            FirstName = firstName;
            Age = age;
            this.gender = gender;
            PhoneNumber = phoneNumber;
        }

        public string MainInfo()
        {

            return $"Фамилия: {SecondName}\n" +
                    $"Имя: {FirstName}\n" +
                    $"Возраст: {Age}\n" +
                    $"Пол: {gender.ToString()}\n" +
                    $"Телефон: {PhoneNumber}";

        }

        public abstract string Header();

        public abstract string Footer();

        public virtual string PrintInfo()
        {
            return $"\n{Header()}" +
                    $"\n{MainInfo()}" +
                    $"\n{Footer()}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Person person)
            {
                if (this.FirstName == person.FirstName && this.SecondName == person.SecondName)
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.SecondName}";
        }
    }
}
