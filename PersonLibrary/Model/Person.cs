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

        public virtual string SPrintInfo()
        {
            return $"\n{Header()}" +
                    $"\n{MainInfo()}" +
                    $"\n{Footer()}";
        }

        /*public virtual void PrintInfo()
        {
            Console.WriteLine($"\n{Header()}" +                                            
                              $"\n{MainInfo()}" +
                              $"\n{Footer()}");
        }*/
    }
}
