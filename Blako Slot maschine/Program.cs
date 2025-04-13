using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Blako_Slot_maschine
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Welcome to Fruits Wars!!\n");
            Console.Write("[3x3=3] [5x5=5] [7x7=7] Grid");
            Console.WriteLine("\tTake a option :");
            int userGridInput = int.Parse(Console.ReadLine());
            Console.Write("[1Line=1],[3Lines=3],[6Lines=6],[8Lines=8]");
            Console.WriteLine("\t How many Lines want you to play?:");
            string userPlayLines = Console.ReadLine();
            ConsoleKeyInfo key;

            int playerChoiseLine1 = Convert.ToInt32(userPlayLines);
            int playerChoiseLine3 = Convert.ToInt32(userPlayLines);
            int playerChoiseLine6 = Convert.ToInt32(userPlayLines);
            int playerChoiseLine8 = Convert.ToInt32(userPlayLines);
            int gameLines1 = 1;
            int gameLines3 = 3;
            int gameLines6 = 6;
            int gameLines8 = 8;
            int rows = userGridInput;
            int cols = userGridInput;
            const int CREDIT = 100;
            const int BET_PER_LINE = 1;
            int balance = CREDIT;
            int totalLines;
            int totalGameLines;
            int centerLineGrid = 1;
            int gridLinesChoices = userGridInput;
            // Musst adapting the game based on user grid choise!!! this is in work and not Availible at Now! just the 3x3 grid is corect!(winning and Losses)

            string framingGridSymbols = "+--";
            string framingGridCorners = "+";
            string framingGridVerticalLines = "|";

            Console.OutputEncoding = Encoding.UTF8;

            string[,] slotsGrid = new string[rows, cols];

            List<string> fruits = new List<string>();
            fruits.Add("\U0001F34E"); //red Aplle
            fruits.Add("\U0001F352"); // red cherys
            fruits.Add("\U0001F96D");// mango
            fruits.Add("\U0001F34A");//Orange
            fruits.Add("\U0001F347");// Wein Trauben
            int indexList = fruits.Count;
            Random randomList = new Random();
            // For the game option how many Lines the user Wants to play
            switch (userPlayLines)
            {
                case "1":
                    gameLines1 = playerChoiseLine1;
                    totalLines = 1;
                    totalGameLines = 1;
                    break;
                case "3":
                    gameLines3 = playerChoiseLine3;
                    totalLines = 3;
                    totalGameLines = gameLines3;
                    break;
                case "6":
                    gameLines6 = playerChoiseLine6;
                    totalLines = 6;
                    totalGameLines = gameLines6;
                    break;
                case "8":
                    gameLines8 = playerChoiseLine8;
                    totalLines = 8;
                    totalGameLines = gameLines8;
                    break;
                default:
                    Console.WriteLine("Next Time enter a valid Number! you play now on main line");
                    gameLines1 = playerChoiseLine1;
                    totalLines = 1;
                    totalGameLines = gameLines1;
                    break;


            }
            if (userGridInput == 5)
            {
                centerLineGrid = userGridInput - 2;
            }
            if (userGridInput == 7)
            {
                centerLineGrid = userGridInput - 3;
            }
            Console.WriteLine("To Play press Spacebar Key");


            //Main Game to play
            do
            {
                key = Console.ReadKey();
                Console.WriteLine();
                Console.Clear();

                for (int r = 0; r < rows; r++)
                {
                    Console.Write(framingGridSymbols);
                }
                Console.WriteLine(framingGridCorners);

                for (int i = 0; i < rows; i++)
                {

                    Console.Write(framingGridVerticalLines);

                    for (int j = 0; j < cols; j++)
                    {

                        slotsGrid[i, j] = fruits[randomList.Next(indexList)];
                        Console.Write(slotsGrid[i, j]);
                        Console.Write(framingGridVerticalLines);

                    }
                    Console.WriteLine();
                    for (int r = 0; r < rows; r++)
                    {
                        Console.Write(framingGridSymbols);
                    }
                    Console.WriteLine(framingGridCorners);

                }
                Console.WriteLine();
                // Center Line Winings
                bool gameWinnings = false;
                int betTotalLines = totalLines * BET_PER_LINE;

                if (playerChoiseLine1 == gameLines1)
                {

                    for (int r = centerLineGrid; r <= centerLineGrid; r++)
                    {
                        bool winnings = true;
                        string firstSymbol = slotsGrid[r, centerLineGrid];

                        for (int c = 0; c < cols; c++)
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
                            balance += betTotalLines;
                            Console.WriteLine($"you win on H-Line{r + 1}");
                        }

                    }
                }
                // All  Horizontal Lines Are Active
                if (playerChoiseLine1 != gameLines1)
                {


                    if (playerChoiseLine3 == gameLines3 || playerChoiseLine6 != gameLines3 || playerChoiseLine8 != gameLines3)
                    {


                        for (int r = 0; r < rows; r++)
                        {
                            bool winnings = true;
                            string firstSymbol = slotsGrid[r, 0];

                            for (int c = 1; c < cols; c++)
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
                                balance += betTotalLines;
                                Console.WriteLine($"you win on H-Line{r + 1}");
                            }

                        }
                    }
                }
                // All  Vertical Lines lines Winnings
                if (playerChoiseLine6 == gameLines6 || playerChoiseLine8 != gameLines6 && playerChoiseLine3 == gameLines6 ||playerChoiseLine8 != gameLines6)
                {


                    for (int c = 0; c < cols; c++)
                    {
                        bool winnings = true;
                        string firstSymbol = slotsGrid[0, c];
                        for (int r = 1; r < rows; r++)
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
                            balance += betTotalLines;
                            Console.WriteLine($"you win on V| Line{c + 1}");
                        }
                    }
                }
                // left diagonal Line
                bool diagonalLeftWinnings = true;
                if (playerChoiseLine8 == gameLines8)
                {


                    for (int r = 1; r < rows; r++)
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
                        balance += betTotalLines;
                        Console.WriteLine($"you win on Main diagonal Line");
                    }
                    // right diagonal Line
                    bool rightDiagonalWinnings = true;
                    for (int r = 1; r < rows; r++)
                    {
                        string firstSymbol = slotsGrid[0, rows - 1];
                        if (slotsGrid[r, rows - 1 - r] != firstSymbol)
                        {
                            rightDiagonalWinnings = false;
                            break;

                        }
                    }
                    if (rightDiagonalWinnings)
                    {
                        gameWinnings = true;
                        balance += betTotalLines;
                        Console.WriteLine($"you win on Sekond diagonal Line");
                    }
                }


                if (gameWinnings)
                {

                    Console.WriteLine($"Your balance ==>{balance}<== ");

                }
                else
                {
                    Console.WriteLine("you lose");
                    balance -= betTotalLines;
                    Console.WriteLine($"your balance ==>{balance}<==");
                }


            } while (balance > totalGameLines && key.Key == ConsoleKey.Spacebar);



        }
    }
}
