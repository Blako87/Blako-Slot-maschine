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
            Console.WriteLine("To Play press Spacebar Key");
            ConsoleKeyInfo key;
            const int ROWS = 3;
            const int COLS = 3;
            const int CREDIT = 100;
            const int BET=3;
            int balance = CREDIT;
                       
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
                // All 3 Horizontal Lines Are Active
                bool horizontalWinnings = false;
                for (int r = 0; r < ROWS; r++)
                {
                    
                    if (slotsGrid[r, 0] ==  slotsGrid[r, 1] && slotsGrid[r, 2] == slotsGrid[r, 1])
                    {
                        horizontalWinnings = true;
                        balance += BET;
                        Console.WriteLine($"You win on line {r+1}");
                        Console.WriteLine(balance);
                    }
                }
                Console.WriteLine(horizontalWinnings);
                
                if (!horizontalWinnings)
                {
                   
                    Console.WriteLine("You Lose ");
                    balance -= BET;
                    Console.WriteLine(balance);
                    
                }
                

            } while (CREDIT > 0 && key.Key == ConsoleKey.Spacebar);



        }
    }
}
