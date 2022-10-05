using System;
using System.Collections.Generic;
using System.Text;
using GenSpace;

namespace PersonLibrary.Model
{
    public class Student : Person
    {

        /// <summary>
        /// Студент
        /// </summary>
        /// <param name="secondName"></param>
        /// <param name="firstName"></param>
        /// <param name="age"></param>
        /// <param name="gender"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="group"></param>
        public Student(string secondName, string firstName, int age, Gender gender, string phoneNumber, string group) : base(secondName, firstName, age, gender, phoneNumber)
        {
            Group = group;
        }

        /// <summary>
        /// Группа
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Вывод информации о студенте
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
            return "Студент";
        }

        /// <summary>
        /// Дополнительная информация
        /// </summary>
        /// <returns></returns>
        public override string Footer()
        {
            return $"Группа: {Group}";
        }

    }
}
