using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blako_Slot_maschine
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Welcome to Fruits Wars!!\n");
            Console.WriteLine("To Play press tab Key");
            ConsoleKeyInfo key;
            int ROWS = 3;
            int COLS = 3;
            int CREDIT = 20;
            int balance;
            int WININGS = 1;

            string framingGridSymbols = "+--";
            string framingGridCorners = "+";
            string framingGridVerticalLines = "|";

            Console.OutputEncoding = Encoding.UTF8;

            string[,] slotsGrid = new string[ROWS, COLS];

            List<string> fruits = new List<string>();
            fruits.Add("\U0001F34E"); //red Aplle
            fruits.Add("\U0001F352"); // red cherys
            fruits.Add("\U0001F96D");// mango
            fruits.Add("\U0001F34A");//Orange
            fruits.Add("\U0001F347");// Wein Trauben
            int indexList = fruits.Count;
            Random randomList = new Random();
           

            do
            {
                key = Console.ReadKey();
                Console.WriteLine();
                Console.Clear();

                for (int r = 0; r < ROWS; r++)
                {
                    Console.Write(framingGridSymbols);
                }
                Console.WriteLine(framingGridCorners);

                for (int i = 0; i < ROWS; i++)
                {

                    Console.Write(framingGridVerticalLines);

                    for (int j = 0; j < COLS; j++)
                    {
                        slotsGrid[i, j] = fruits[randomList.Next(indexList)];
                        Console.Write(slotsGrid[i, j]);
                        Console.Write(framingGridVerticalLines);
                    }
                    Console.WriteLine();
                    for (int r = 0; r < ROWS; r++)
                    {
                        Console.Write(framingGridSymbols);
                    }
                    Console.WriteLine(framingGridCorners);

                }
                Console.WriteLine();

                if (slotsGrid[2, 0] == slotsGrid[2, 1] && slotsGrid[2, 2] == slotsGrid[2, 0])
                {
                    Console.WriteLine("Winner 3rd line : 1$");
                    balance = CREDIT + WININGS;
                    Console.WriteLine($"your balance is:{balance}$");
                }
                else
                {
                    CREDIT--;
                    Console.WriteLine($"your Balance is:{CREDIT}$");
                }


            } while (CREDIT > 0 && key.Key == ConsoleKey.Tab);



        }
    }
}
