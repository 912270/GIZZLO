using System;
using System.Collections.Generic;
using System.Text;
using GenSpace;

namespace PersonLibrary.Model
{
    public class Teacher : Person
    {
        /// <summary>
        /// Учитель
        /// </summary>
        /// <param name="secondName"></param>
        /// <param name="firstName"></param>
        /// <param name="age"></param>
        /// <param name="gender"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="subject"></param>
        public Teacher(string secondName, string firstName, int age, Gender gender, string phoneNumber, string subject) : base(secondName, firstName, age, gender, phoneNumber)
        {
            Subject = subject;
        }

        /// <summary>
        /// Предмет
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Вывод информации об учителе
        /// </summary>
        /// <returns></returns>
        public override string PrintInfo()
        {
            return base.PrintInfo();
        }

        /// <summary>
        /// Тип персоны
        /// </summary>
        /// <returns></returns>
        public override string Header()
        {
            return "Преподаватель";
        }

        /// <summary>
        /// Дополнительная информация
        /// </summary>
        /// <returns></returns>
        public override string Footer()
        {
            return $"Предмет: {Subject}";
        }

    }
}
