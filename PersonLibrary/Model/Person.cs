using System;
using System.Collections.Generic;
using System.Text;
using GenSpace;

namespace PersonLibrary.Model
{
    public abstract class Person
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; private set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string SecondName { get; private set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Пол
        /// </summary>
        public Gender gender { get; private set; }

        /// <summary>
        /// Персона
        /// </summary>
        /// <param name="secondName"></param>
        /// <param name="firstName"></param>
        /// <param name="age"></param>
        /// <param name="gender"></param>
        /// <param name="phoneNumber"></param>
        public Person(string secondName, string firstName, int age, Gender gender, string phoneNumber)
        {
            SecondName = secondName;
            FirstName = firstName;
            Age = age;
            this.gender = gender;
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Вывод основной информации о персоне
        /// </summary>
        /// <returns></returns>
        public string MainInfo()
        {

            return $"Фамилия: {SecondName}\n" +
                    $"Имя: {FirstName}\n" +
                    $"Возраст: {Age}\n" +
                    $"Пол: {gender.ToString()}\n" +
                    $"Телефон: {PhoneNumber}";

        }

        /// <summary>
        /// Абстракт для вывода названия типа наследника
        /// </summary>
        /// <returns></returns>
        public abstract string Header();

        /// <summary>
        /// Абстракт дополнительной информации
        /// </summary>
        /// <returns></returns>
        public abstract string Footer();

        /// <summary>
        /// Вывод информации о персоне
        /// </summary>
        /// <returns></returns>
        public virtual string PrintInfo()
        {
            return $"\n{Header()}" +
                    $"\n{MainInfo()}" +
                    $"\n{Footer()}";
        }

        /// <summary>
        /// Сравнение персон по имени и фамилии
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Person person)
            {
                if (this.FirstName == person.FirstName && this.SecondName == person.SecondName)
                    return true;
            }
            return false;
        }

        public bool Equals(string name, string lastname)
        {
            return this.FirstName.ToLower() == name.ToLower() && this.SecondName == lastname;
        }

        /// <summary>
        /// Вывод имени и фамилии персоны
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.FirstName} {this.SecondName}";
        }
    }
}
