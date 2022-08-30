using System;
using System.Collections.Generic;
using System.Text;
using GenSpace;
using PersonLibrary.Model;

namespace StudentApp
{
    /// <summary>
    /// Взаимодействие с репозиторием
    /// </summary>
    internal class Service
    {
        Repo<Student> students = new Repo<Student>();
        Repo<Teacher> teachers = new Repo<Teacher>();

        List<Person> persons = new List<Person>();

        //
        //Переделать все методы под обобщенный репозиторий
        //

        public Service()
        {
            persons.AddRange(students.list);
            persons.AddRange(teachers.list);
        }

        private string name;

        public Person Find(Person person)
        {
            foreach (var student in students.list)
            {
                if (student.Equals(person))
                    return student;
            }
            foreach (var teacher in teachers.list)
            {
                if (teacher.Equals(person))
                    return teacher;
            }
            return null;
        }

        /// <summary>
        /// Отображение всех персон
        /// </summary>
        public void ShowAll()
        {
            foreach (var person in persons)
            {
                Console.WriteLine(person.PrintInfo());
            }
        }

        /// <summary>
        /// Отображение по имени и фамилии
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastname"></param>
        public void Show(string name, string lastname)
        {
            foreach (var person in persons)
            {
                if (person.FirstName == name && person.SecondName == lastname)
                {
                    Console.WriteLine(person.PrintInfo());
                    break;
                }
            }
        }

        /// <summary>
        /// Отображение по классу(типу)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void Show<T>()
        {
            foreach (var person in persons)
            {
                if (person is T)
                {
                    Console.WriteLine(person.PrintInfo());
                }
            }
        }

        /// <summary>
        /// Заголовок
        /// </summary>
        /// <returns></returns>
        private string header()
        {
            string result = "\n=====================================\n" +
                            $"{name}\n" +
                            $"=====================================\n";

            return result;
        }

        /// <summary>
        /// Главное меню
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void ShowMenu()
        {
            Console.Clear();

            name = "\t\tМеню";
            Console.WriteLine($"{header()}" +
                              $"1. Отобразить... \n" +
                              $"2. Добавить... \n" +
                              $"3. Удалить ");
            var menu = int.Parse(Console.ReadLine());

            switch (menu)
            {
                case 1:
                    PrintMenu();
                    break;
                case 2:
                    AddMenu();
                    break;
                case 3:
                    RemoveMenu();
                    break;
                default:
                    throw new Exception("Wrong direction");
            }
        }

        /// <summary>
        /// Меню "Кого отобразить?"
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void PrintMenu()
        {
            Console.Clear();

            name = "\tОтобразить информацию";
            Console.WriteLine($"{header()}" +
                              $"1. Всех\n" +
                              $"2. По типу...\n" +
                              $"3. Конкретного человека\n" +
                              $"4. Главное меню");
            var menu = int.Parse(Console.ReadLine());

            switch (menu)
            {
                case 1:
                    ShowAllMenu();
                    break;
                case 2:
                    PrintTypeMenu();
                    break;
                case 3:
                    PersonInfoMenu();
                    break;
                case 4:
                    ShowMenu();
                    break;
                default:
                    throw new Exception("Wrong direction");
            }
        }

        /// <summary>
        /// Меню "Отобразить всех"
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void ShowAllMenu()
        {
            Console.Clear();

            name = "\tСписок всех персон";

            Console.WriteLine($"{header()}");

            ShowAll();

            Console.WriteLine($"\n1. Добавить... \n" +
                              $"2. Удалить \n" +
                              $"3. Назад ");

            var menu = int.Parse(Console.ReadLine());

            switch (menu)
            {
                case 1:
                    AddMenu();
                    break;
                case 2:
                    RemoveMenu();
                    break;
                case 3:
                    PrintMenu();
                    break;
                default:
                    throw new Exception("Wrong direction");
            }
        }

        /// <summary>
        /// Меню "Выбрать тип для отображения"
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void PrintTypeMenu()
        {
            Console.Clear();

            name = "\tПерсоны по типам";
            Console.WriteLine($"{header()}");

            Console.WriteLine($"1. Преподаватели\n" +
                              $"2. Студенты \n" +
                              $"3. Назад ");

            var menu = int.Parse(Console.ReadLine());

            switch (menu)
            {
                case 1:
                    Show<Teacher>();
                    break;
                case 2:
                    Show<Student>();
                    break;
                case 3:
                    PrintMenu();
                    break;
                default:
                    throw new Exception("Wrong direction");
            }

            Console.WriteLine($"\n1. Назад ");

            if (int.Parse(Console.ReadLine()) == 1) { PrintMenu(); }

        }

        /// <summary>
        /// Меню "Введите информацию о персоне для отображения"
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void PersonInfoMenu()
        {
            Console.Clear();

            name = "\tИнформация о человеке";
            Console.WriteLine($"{header()}");

            Console.WriteLine($"Введите фамилию:");
            string PLName = Convert.ToString(Console.ReadLine());

            Console.WriteLine($"Введите имя:");
            string PFName = Convert.ToString(Console.ReadLine());

            Show(PFName, PLName);

            Console.WriteLine($"\n1. Назад ");

            var menu = int.Parse(Console.ReadLine());

            switch (menu)
            {
                case 1:
                    PrintMenu();
                    break;
                default:
                    throw new Exception("Wrong direction");
            }
        }

        /// <summary>
        /// Меню "Кого добавить?"
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void AddMenu()
        {
            Console.Clear();

            name = "\t\tДобавить";

            Console.WriteLine($"{header()}" +
                              $"1. Преподавателя\n" +
                              $"2. Студента\n" +
                              $"3. Главное меню");
            var menu = int.Parse(Console.ReadLine());

            switch (menu)
            {
                case 1:
                    TeacherAddMenu();
                    break;
                case 2:
                    StudentAddMenu();
                    break;
                case 3:
                    ShowMenu();
                    break;
                default:
                    throw new Exception("Wrong direction");
            }

        }

        /// <summary>
        /// Меню "Ввода информации об учителе и отображение добавленной персоны"
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void TeacherAddMenu()
        {
            Gender gen;

            Console.Clear();

            name = "\tДобавить учителя";

            Console.WriteLine($"{header()}");

            Console.WriteLine($"Введите фамилию:");
            string PLName = Convert.ToString(Console.ReadLine());

            Console.WriteLine($"Введите имя:");
            string PFName = Convert.ToString(Console.ReadLine());

            Console.WriteLine($"Введите возраст:");
            int PAge = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Введите пол:\n" +
                                "1 - Мужской\n" +
                                "2 - Женский");
            int PGen = Convert.ToInt32(Console.ReadLine());

            switch (PGen)
            {
                case 1:
                    gen = Gender.Male;
                    break;
                case 2:
                    gen = Gender.Female;
                    break;
                default:
                    throw new Exception("Wrong direction");
            }

            Console.WriteLine($"Введите телефон:");
            string PPhone = Convert.ToString(Console.ReadLine());

            Console.WriteLine($"Введите предмет:");
            string PSub = Convert.ToString(Console.ReadLine());

            teachers.Add(new Teacher(PLName, PFName, PAge, gen, PPhone, PSub));

            Show(PFName, PLName);

            Console.WriteLine($"\n1. Главное меню ");

            var menu = int.Parse(Console.ReadLine());

            switch (menu)
            {
                case 1:
                    ShowMenu();
                    break;
                default:
                    throw new Exception("Wrong direction");
            }

        }

        /// <summary>
        /// Меню "Ввода информации о студенте и отображение добавленной персоны"
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void StudentAddMenu()
        {
            Gender gen;

            Console.Clear();

            name = "\tДобавить Студента";

            Console.WriteLine($"{header()}");

            Console.WriteLine($"Введите фамилию:");
            string PLName = Convert.ToString(Console.ReadLine());

            Console.WriteLine($"Введите имя:");
            string PFName = Convert.ToString(Console.ReadLine());

            Console.WriteLine($"Введите возраст:");
            int PAge = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Введите пол\n" +
                                "1 - Мужской\n" +
                                "2 - Женский");
            int PGen = Convert.ToInt32(Console.ReadLine());

            switch (PGen)
            {
                case 1:
                    gen = Gender.Male;
                    break;
                case 2:
                    gen = Gender.Female;
                    break;
                default:
                    throw new Exception("Wrong direction");
            }

            Console.WriteLine($"Введите телефон:");
            string PPhone = Convert.ToString(Console.ReadLine());

            Console.WriteLine($"Введите группу:");
            string PGroup = Convert.ToString(Console.ReadLine());

            students.Add(new Student(PLName, PFName, PAge, gen, PPhone, PGroup));

            Show(PFName, PLName);

            Console.WriteLine($"\n1. Главное меню ");

            var menu = int.Parse(Console.ReadLine());

            switch (menu)
            {
                case 1:
                    ShowMenu();
                    break;
                default:
                    throw new Exception("Wrong direction");
            }

        }

        /// <summary>
        /// Меню "Удалить персону"
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void RemoveMenu()
        {
            Console.Clear();

            name = "Удалить информацию о человеке";
            Console.WriteLine($"{header()}");

            Console.WriteLine($"Введите фамилию:");
            string PLName = Convert.ToString(Console.ReadLine());

            Console.WriteLine($"Введите имя:");
            string PFName = Convert.ToString(Console.ReadLine());

            //students.Remove(PFName, PLName);

            Console.WriteLine($"\n1. Главное меню ");

            var menu = int.Parse(Console.ReadLine());

            switch (menu)
            {
                case 1:
                    ShowMenu();
                    break;
                default:
                    throw new Exception("Wrong direction");
            }
        }


    }
}
