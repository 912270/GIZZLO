using System;

namespace Rainbow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string n = lengh(50);

            var red = ConsoleColor.DarkRed;
            var orange = ConsoleColor.DarkYellow;
            var yellow = ConsoleColor.Yellow;
            var green = ConsoleColor.Green;
            var blue = ConsoleColor.Blue;
            var navy = ConsoleColor.DarkBlue;
            var violet = ConsoleColor.DarkMagenta;

            print_pat("КАЖДЫЙ", red, n);
            print_pat("ОХОТНИК", orange, n);
            print_pat("ЖЕЛАЕТ", yellow, n);
            print_pat("ЗНАТЬ", green, n);
            print_pat("ГДЕ", blue, n);
            print_pat("СИДИТ", navy, n);
            print_pat("ФАЗАН", violet, n);

            Console.ReadLine();
        }

        public static string lengh(int n)
        {
            string s = "";

            for (int i = 0; i <= n; i++)
            {
                s = s + " ";
            }

            return s;
        }

        public static void print_pat(string colstr, ConsoleColor c, string leng)
        {
            Console.BackgroundColor = c;
            Console.WriteLine(leng);
            Console.Write(leng);
            Console.ResetColor();
            Console.ForegroundColor = c;
            Console.WriteLine($" -- {colstr}");
            Console.BackgroundColor = c;
            Console.WriteLine(leng);
            Console.ResetColor();
        }
    }
}
