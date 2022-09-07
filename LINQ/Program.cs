using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task4();
        }

        #region Задание 1
        /*LINQ удобно использовать для чтения из файла и разбора простых текстовых форматов. Особенно удобно сочетать методы LINQ с методами класса File: File.ReadLines(filename), File.WriteLines(filename, lines).

            Пусть у вас есть файл, в котором каждая строка либо пустая, либо содержит одно целое число. Кто-то уже вызвал метод File.ReadAllLines(filename) и теперь у вас есть массив всех строк этого файла.

            Функция должна перебрать массив типа string[] или типа List<string> и отдать результат, массив типа int[]*/

        static void Task1()
        {
            foreach (var num in ParseNumbers(new[] { "-0", "+0000", "f" }))
                Console.WriteLine(num);
            foreach (var num in ParseNumbers(new List<string> { "1", "", "-03", "0" }))
                Console.WriteLine(num);
        }

        static int[] ParseNumbers(IEnumerable<string> lines)
        {
            return lines
                .Where(s => Int32.TryParse(s, out _))
                .Select(n => Int32.Parse(n)).ToArray();
        }
        #endregion

        #region Задание 2
        /*В файле в каждой строке написаны две координаты точки(X, Y), разделенные пробелом.Кто-то уже вызвал метод File.ReadLines(filename) и теперь у вас есть массив всех строк файла.
        Реализуйте метод ParsePoints в одно LINQ-выражение.
        Постарайтесь не использовать функцию преобразования строки в число более одного раза.*/

        static void Task2()
        {
            foreach (var point in ParsePoints(new[] { "1 -2", "-3 4", "0 2" }))
                Console.WriteLine(point.X + " " + point.Y);
            foreach (var point in ParsePoints(new List<string> { "+01 -0042" }))
                Console.WriteLine(point.X + " " + point.Y);
        }

        static List<Point> ParsePoints(IEnumerable<string> lines)
        {
            return lines
                .Select(s => s.Split(" "))
                .Select(s => new Point(Int32.Parse(s[0]), Int32.Parse(s[1])))
                .ToList<Point>();
        }

        public class Point
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
            public int X, Y;
        }
        #endregion

        #region Задание 3
        //Вам дан список всех классов в школе.Нужно получить список всех учащихся всех классов.

        static void Task3()
        {
            Classroom[] classes =
            {
                new Classroom {Students = {"Pavel", "Ivan", "Petr"},},
                new Classroom {Students = {"Anna", "Ilya", "Vladimir"},},
                new Classroom {Students = {"Bulat", "Alex", "Galina"},}
            };
            var allStudents = GetAllStudents(classes);
            Array.Sort(allStudents);
            Console.WriteLine(string.Join(Environment.NewLine, allStudents));
        }

        static string[] GetAllStudents(Classroom[] classes)
        {
            return classes
                .SelectMany(s => s.Students)
                .ToArray();
        }

        public class Classroom
        {
            public List<string> Students = new List<string>();
        }

        #endregion

        #region Задание 4
        /*Текст задан массивом строк. Вам нужно составить лексикографически упорядоченный список всех встречающихся в этом тексте слов.

        Слова нужно сравнивать регистронезависимо, а выводить в нижнем регистре.*/

        static void Task4()
        {
            var vocabulary = GetSortedWords(
                "Hello, hello, hello, how low",
                "",
                "With the lights out, it's less dangerous",
                "Here we are now; entertain us",
                "I feel stupid and contagious",
                "Here we are now; entertain us",
                "A mulatto, an albino, a mosquito, my libido...",
                "Yeah, hey" );

            foreach (var word in vocabulary)
                Console.WriteLine(word);
        }

        static string[] GetSortedWords(params string[] textLines)
        {
            return textLines
                .Where(s => !string.IsNullOrEmpty(s))
                .SelectMany(s => s.Split(" "))
                .Select(s => s.ToLower())
                .ToArray();
        }

        #endregion
    }

}

/*
 * Задание 1 Take, Skip, ToArray, ToList
LINQ удобно использовать для чтения из файла и разбора простых текстовых форматов. Особенно удобно сочетать методы LINQ с методами класса File: File.ReadLines(filename), File.WriteLines(filename, lines).

Пусть у вас есть файл, в котором каждая строка либо пустая, либо содержит одно целое число. Кто-то уже вызвал метод File.ReadAllLines(filename) и теперь у вас есть массив всех строк этого файла.

Функция должна перебрать массив типа string[] или типа List<string> и отдать результат, массив типа int[]

foreach (var num in ParseNumbers(new[] {"-0", "+0000"}))
	Console.WriteLine(num);
foreach (var num in ParseNumbers(new List<string> {"1", "", "-03", "0"}))
	Console.WriteLine(num);

static int[] ParseNumbers(IEnumerable<string> lines)
{
	return lines
		.Where(...)
		.Select(...)
		...
}


Задание 2

В файле в каждой строке написаны две координаты точки (X, Y), разделенные пробелом. Кто-то уже вызвал метод File.ReadLines(filename) и теперь у вас есть массив всех строк файла.
Реализуйте метод ParsePoints в одно LINQ-выражение.
Постарайтесь не использовать функцию преобразования строки в число более одного раза.

foreach (var point in ParsePoints(new[] { "1 -2", "-3 4", "0 2" }))
  Console.WriteLine(point.X + " " + point.Y);
foreach (var point in ParsePoints(new List<string> { "+01 -0042" }))
  Console.WriteLine(point.X + " " + point.Y);

static List<Point> ParsePoints(IEnumerable<string> lines)
{
  return lines
    .Select(...)...
}

public class Point
{
  public Point(int x, int y)
  {
    X = x;
    Y = y;
  }
  public int X, Y;
}

Задание 3 SelectMany

Вам дан список всех классов в школе. Нужно получить список всех учащихся всех классов.

Classroom[] classes =
	{
		new Classroom {Students = {"Pavel", "Ivan", "Petr"},},
		new Classroom {Students = {"Anna", "Ilya", "Vladimir"},},
		new Classroom {Students = {"Bulat", "Alex", "Galina"},}
	};
	var allStudents = GetAllStudents(classes);
	Array.Sort(allStudents);
	Console.WriteLine(string.Join(" ", allStudents));
	
	
static string[] GetAllStudents(Classroom[] classes)
{
return 
}	
	
public class Classroom
{
	public List<string> Students = new List<string>();
}

Задание 4 OrderBy и Distinct

Текст задан массивом строк. Вам нужно составить лексикографически упорядоченный список всех встречающихся в этом тексте слов.

Слова нужно сравнивать регистронезависимо, а выводить в нижнем регистре.

var vocabulary = GetSortedWords(
		"Hello, hello, hello, how low",
		"",
		"With the lights out, it's less dangerous",
		"Here we are now; entertain us",
		"I feel stupid and contagious",
		"Here we are now; entertain us",
		"A mulatto, an albino, a mosquito, my libido...",
		"Yeah, hey"
	);
	foreach (var word in vocabulary)
		Console.WriteLine(word);
		
		
static string[] GetSortedWords(params string[] textLines)
{
	// ваше решение
}		


Задание 5

Дан список слов, нужно найти самое длинное слово из этого списка, а из всех самых длинных — лексикографически первое слово.

Console.WriteLine(GetLongest(new[] { "azaz", "as", "sdsd" }));
Console.WriteLine(GetLongest(new[] { "zzzz", "as", "sdsd" }));
Console.WriteLine(GetLongest(new[] { "as", "12345", "as", "sds" }));

static string GetLongest(IEnumerable<string> words)
{
  return 
}
 */



