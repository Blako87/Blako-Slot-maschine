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
            const int STANDARD_GRID = 3;
            const int DEAFAULT_MODE = 1;
            const int CREDIT = 1000;
            const int BET_PER_LINE = 1;
            const int GAME_MODE_MAIN_LINE_SUBSTRACTION = 2;
            const string FRAMING_GRID_SYMBOLS = "+--";
            const string FRAMING_GRID_CORNERS = "+";
            const string FRAMING_GRID_VERTICAL_LINES = "|";
            const string RED_APPLE = "\U0001F34E";
            const string RED_CHERYS = "\U0001F352";
            const string MANGO = "\U0001F96D";
            const string ORANGE = "\U0001F34A";
            const string GRAPES = "\U0001F347";

            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Welcome to Fruits Wars!!\n");
            Console.Write("[3x3=3] [5x5=5] Grid");
            Console.WriteLine("\tTake a option :");

            int userGridInput = int.Parse(Console.ReadLine());
            bool winingIncrease = false;
            if (STANDARD_GRID != userGridInput)
            {
                Console.Write("[1Line=1],[5Lines=5],[10Lines=10],[12Lines=12]");
                winingIncrease = true;
            }
            else
            {

                Console.Write("[1Line=1],[3Lines=3],[6Lines=6],[8Lines=8]");
            }

            Console.WriteLine("\t How many Lines want you to play?:");

            string userPlayLines = Console.ReadLine();
            int playerChoiseLines = Convert.ToInt32(userPlayLines);
            int rows = userGridInput;
            int cols = userGridInput;

            ConsoleKeyInfo key;

            // list for the game standard or another one
            List<int> standardGrid = new List<int> { 1, 3, 6, 8 };
            List<int> extendedGrid = new List<int> { 1, 5, 10, 12 };
            List<int> listGridSwitch = standardGrid;

            string[,] slotsGrid = new string[rows, cols];
            List<string> fruits = new List<string>();
            fruits.Add(RED_APPLE);
            fruits.Add(RED_CHERYS);
            fruits.Add(MANGO);
            fruits.Add(ORANGE);
            fruits.Add(GRAPES);
            int indexList = fruits.Count;
            Random randomList = new Random();
            int totalLines;
            int totalGameLines;
            int gameCenter = listGridSwitch[0];
            int gameHorizontalLines = listGridSwitch[1];
            int gameVerticalLines = listGridSwitch[2];
            int gameDiagonalLines = listGridSwitch[3];
            int balance = CREDIT;
            // For the game option how many Lines the user Wants to play
            switch (userPlayLines)
            {
                case "1":
                    listGridSwitch = standardGrid;
                    totalLines = listGridSwitch[0];
                    totalGameLines = listGridSwitch[0];
                    break;
                case "3":
                    listGridSwitch = standardGrid;
                    totalLines = listGridSwitch[1];
                    totalGameLines = listGridSwitch[1];
                    break;
                case "6":
                    listGridSwitch = standardGrid;
                    totalLines = listGridSwitch[2];
                    totalGameLines = listGridSwitch[2];
                    break;
                case "8":
                    listGridSwitch = standardGrid;
                    totalLines = listGridSwitch[3];
                    totalGameLines = listGridSwitch[3];
                    break;
                case "5":
                    listGridSwitch = extendedGrid;
                    totalLines = listGridSwitch[1];
                    totalGameLines = listGridSwitch[1];
                    break;
                case "10":
                    listGridSwitch = extendedGrid;
                    totalLines = listGridSwitch[2];
                    totalGameLines = listGridSwitch[2];
                    break;
                case "12":
                    listGridSwitch = extendedGrid;
                    totalLines = listGridSwitch[3];
                    totalGameLines = listGridSwitch[3];
                    break;
                default:
                    Console.WriteLine("Next Time enter a valid Number! you play now on main line");
                    gameCenter = playerChoiseLines;
                    totalLines = DEAFAULT_MODE;
                    totalGameLines = DEAFAULT_MODE;
                    break;


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
                    Console.Write(FRAMING_GRID_SYMBOLS);
                }
                Console.WriteLine(FRAMING_GRID_CORNERS);

                for (int i = 0; i < rows; i++)
                {

                    Console.Write(FRAMING_GRID_VERTICAL_LINES);

                    for (int j = 0; j < cols; j++)
                    {

                        slotsGrid[i, j] = fruits[randomList.Next(indexList)];
                        Console.Write(slotsGrid[i, j]);
                        Console.Write(FRAMING_GRID_VERTICAL_LINES);

                    }
                    Console.WriteLine();
                    for (int r = 0; r < rows; r++)
                    {
                        Console.Write(FRAMING_GRID_SYMBOLS);
                    }
                    Console.WriteLine(FRAMING_GRID_CORNERS);

                }
                Console.WriteLine();
                // Center Line Winings
                bool gameWinnings = false;
                int betTotalLines = totalLines * BET_PER_LINE;

                if (playerChoiseLines == gameCenter)
                {
                    int centerLineGrid = userGridInput / GAME_MODE_MAIN_LINE_SUBSTRACTION;

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
                if (playerChoiseLines != gameCenter)
                {


                    if (playerChoiseLines == gameHorizontalLines || playerChoiseLines != gameHorizontalLines || playerChoiseLines != gameVerticalLines)
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
                // All  Vertical Lines lines are Active
                if (playerChoiseLines != gameCenter)
                {

                    if (playerChoiseLines == gameVerticalLines || playerChoiseLines != gameDiagonalLines && playerChoiseLines == gameVerticalLines || playerChoiseLines != gameHorizontalLines)
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
                            if (winingIncrease && winnings)
                            {
                                gameWinnings = true;
                                balance += betTotalLines * 12;
                                Console.WriteLine($"you  win  X12 Bonus on Vertical-Line {c + 1}");
                            }
                        }
                    }
                }
                // left diagonal Line
                bool diagonalLeftWinnings = true;
                if (playerChoiseLines == gameDiagonalLines)
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
                    if (winingIncrease && rightDiagonalWinnings)
                    {
                        gameWinnings = true;
                        balance += betTotalLines * 12;
                        Console.WriteLine($"you win on Sekond diagonal Line X12 Bonus");
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
