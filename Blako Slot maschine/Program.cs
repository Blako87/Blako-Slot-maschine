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
            const int BET = 3;
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
                // Center Line Winings
                bool gameWinnings = false;
                for (int r = 1; r <= 1; r++)
                {
                    bool winnings = true;
                    string firstSymbol = slotsGrid[r, 1];

                    for (int c = 0; c < COLS; c++)
                    {
                        if (slotsGrid[r, c] != firstSymbol)
                        {
                            winnings = false;
                            break;

                        }
                    }
                    if (winnings)
                    {
                        gameWinnings = true;
                        balance += BET;
                        Console.WriteLine($"you win on H-Line{r + 1}");
                    }

                }
                // All 3 Horizontal Lines Are Active

                for (int r = 0; r < ROWS; r++)
                {
                    bool winnings = true;
                    string firstSymbol = slotsGrid[r, 0];

                    for (int c = 1; c < COLS; c++)
                    {
                        if (slotsGrid[r, c] != firstSymbol)
                        {
                            winnings = false;
                            break;

                        }
                    }
                    if (winnings)
                    {
                        gameWinnings = true;
                        balance += BET;
                        Console.WriteLine($"you win on H-Line{r + 1}");
                    }

                }
                // All 3 Vertical Lines lines Winnings
                for (int c = 0; c < COLS; c++)
                {
                    bool winnings = true;
                    string firstSymbol = slotsGrid[0, c];
                    for (int r = 1; r < ROWS; r++)
                    {
                        if (slotsGrid[r, c] != firstSymbol)
                        {
                            winnings = false;
                            break;

                        }
                    }
                    if (winnings)
                    {
                        gameWinnings = true;
                        balance += BET;
                        Console.WriteLine($"you win on V| Line{c + 1}");
                    }
                }
                // left diagonal Line
                bool diagonalLeftWinnings = true;

                for (int r = 1; r < ROWS; r++)
                {
                    string firstSymbol = slotsGrid[0, 0];
                    if (slotsGrid[r, r] != firstSymbol)
                    {
                        diagonalLeftWinnings = false;
                        break;

                    }

                }
                if (diagonalLeftWinnings)
                {
                    gameWinnings = true;
                    balance += BET;
                    Console.WriteLine($"you win on Main diagonal Line");
                }
                // right diagonal Line
                bool rightDiagonalWinnings = true;
                for (int r = 1; r < ROWS; r++)
                {
                    string firstSymbol = slotsGrid[0, ROWS - 1];
                    if (slotsGrid[r, ROWS - 1 - r] != firstSymbol)
                    {
                        rightDiagonalWinnings = false;
                        break;

                    }
                }
                if (rightDiagonalWinnings)
                {
                    gameWinnings = true;
                    balance += BET;
                    Console.WriteLine($"you win on Sekond diagonal Line");
                }


                if (gameWinnings)
                {

                    Console.WriteLine($"Your balance {balance} ");

                }
                else
                {
                    Console.WriteLine("you lose");
                    balance -= BET;
                    Console.WriteLine($"your balance {balance}");
                }


            } while (balance > 1 && key.Key == ConsoleKey.Spacebar);



        }
    }
}
