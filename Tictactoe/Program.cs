using System;
using Tictactoe2;

namespace Tictactoe
{
    internal class Program
    {
        static bool?[] ttt = { null, null, null, null, null, null, null, null, null };
        static bool win = false;
        static bool step = false;
        static int stepinc = 0;
        static void Main(string[] args)
        {
            Print(Change(ttt));

            Console.WriteLine("\'X\' ходит первым\n" +
                              "Введите номер ячейки");

            //TicRun.Run();

            Game();
        }

        public static void Print(string[] l)                                    //Отрисовка поля
        {
            Console.Clear();
            Console.WriteLine("+ - - - + - - - + - - - +\n" +
                              "|       |       |       |\n" +
                              $"|   {l[0]}   |   {l[1]}   |   {l[2]}   |\n" +
                              "|       |       |       |\n" +
                              "+ - - - + - - - + - - - +\n" +
                              "|       |       |       |\n" +
                              $"|   {l[3]}   |   {l[4]}   |   {l[5]}   |\n" +
                              "|       |       |       |\n" +
                              "+ - - - + - - - + - - - +\n" +
                              "|       |       |       |\n" +
                              $"|   {l[6]}   |   {l[7]}   |   {l[8]}   |\n" +
                              "|       |       |       |\n" +
                              "+ - - - + - - - + - - - +\n");
        }

        public static string[] Change(bool?[] l)                                //Изменения второго массива со стоками
        {
            string[] mass = new string[9];

            for (int i = 0; i < l.Length; i++)
            {
                if (l[i] == null)
                {
                    mass[i] = " ";
                }
                else if (l[i] == true)
                {
                    mass[i] = "X";
                }
                else if (l[i] == false)
                {
                    mass[i] = "O";
                }
            }

            return mass;
        }

        public static void Game()                                               //Процесс игры
        {
            while (!win && stepinc < 9)
            {
                step = !step;

                int pos = Int32.Parse(Console.ReadLine()) - 1;

                Step(pos);

                Print(Change(ttt));

                win = Check(pos, step);

            }

            if (stepinc == 9 && win == false)
            {
                Console.WriteLine("Ничья");
            }
            else
            {
                if (step == true)
                {
                    Console.WriteLine("Победил - X");
                }
                else
                {
                    Console.WriteLine("Победил - O");
                }
            }
        }

        public static bool Check(int x, bool y)                                 //Проверка выигрышных ситуаций
        {
            switch (x)
            {
                case 0:
                    if (y == ttt[1] && y == ttt[2])
                        return true;
                    else if (y == ttt[3] && y == ttt[6])
                        return true;
                    else if (y == ttt[4] && y == ttt[8])
                        return true;
                    else
                        return false;
                    break;
                case 1:
                    if (y == ttt[0] && y == ttt[2])
                        return true;
                    else if (y == ttt[4] && y == ttt[7])
                        return true;
                    else
                        return false;
                    break;
                case 2:
                    if (y == ttt[1] && y == ttt[0])
                        return true;
                    else if (y == ttt[4] && y == ttt[6])
                        return true;
                    else if (y == ttt[5] && y == ttt[8])
                        return true;
                    else
                        return false;
                    break;
                case 3:
                    if (y == ttt[0] && y == ttt[6])
                        return true;
                    else if (y == ttt[4] && y == ttt[5])
                        return true;
                    else
                        return false;
                    break;
                case 4:
                    if (y == ttt[1] && y == ttt[7])
                        return true;
                    else if (y == ttt[3] && y == ttt[5])
                        return true;
                    else if (y == ttt[0] && y == ttt[8])
                        return true;
                    else if (y == ttt[2] && y == ttt[6])
                        return true;
                    else
                        return false;
                    break;
                case 5:
                    if (y == ttt[2] && y == ttt[8])
                        return true;
                    else if (y == ttt[4] && y == ttt[3])
                        return true;
                    else
                        return false;
                    break;
                case 6:
                    if (y == ttt[3] && y == ttt[0])
                        return true;
                    else if (y == ttt[4] && y == ttt[2])
                        return true;
                    else if (y == ttt[7] && y == ttt[8])
                        return true;
                    else
                        return false;
                    break;
                case 7:
                    if (y == ttt[1] && y == ttt[4])
                        return true;
                    else if (y == ttt[6] && y == ttt[8])
                        return true;
                    else
                        return false;
                    break;
                case 8:
                    if (y == ttt[4] && y == ttt[0])
                        return true;
                    else if (y == ttt[7] && y == ttt[6])
                        return true;
                    else if (y == ttt[5] && y == ttt[2])
                        return true;
                    else
                        return false;
                    break;
                default:
                    return false;
            }
        }

        public static void Step(int x)                                          //Проверка и выполнения хода
        {
            if (ttt[x] == null)
            {
                ttt[x] = step;
                stepinc++;
            }
            else
            {
                Console.WriteLine("Клетка уже занята");
                int pos = Int32.Parse(Console.ReadLine()) - 1;
                Step(pos);
            }
        }
    }
}
