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
            const int CREDIT = 1000;
            const int BET_PER_LINE = 1;
            const int FRAMING_GRID_COLS = 5;
            const int DIAGONAL_LINES = 2;
            const int GAME_MODE_MAIN_LINE_SUBSTRACTION = 2;
            const int USER_GAME_CHOISE_CENTER = 1;
            const int USER_GAME_CHOICE_HORIZONTAL = 2;
            const int USER_GAME_CHOICE_VERTICAL = 3;
            const int USER_GAME_CHOICE_DIAGONAL = 4;
            const int USER_GAME_CHOICE_ALL_LINES = 5;
            const string GAME_CENTER = "Center Line = 1";
            const string GAME_HORIZONTAL_LINES = "Horizontal Lines = 2";
            const string GAME_VERTICL_LINES = "Vertical Lines = 3";
            const string GAME_DIAGONAL_LINES = "Diagonal Lines = 4";
            const string GAME_ALL_LINES = "All Lines = 5";
            const string FRAMING_GRID_SYMBOLS = "+--";
            const string FRAMING_GRID_CORNERS = "+";
            const string FRAMING_GRID_VERTICAL_LINES = "|";
            const string RED_APPLE = "\U0001F34E";
            const string RED_CHERYS = "\U0001F352";
            const string MANGO = "\U0001F96D";
            const string ORANGE = "\U0001F34A";
            const string GRAPES = "\U0001F347";
            // Encoding to be able to show symbols
            Console.OutputEncoding = Encoding.UTF8;
            // Welcome message and user Gridgame choice size
            Console.WriteLine("Welcome to Fruits Wars!!\n");
            Console.Write("3x5 Grid Are Standard Game\n");
            Console.WriteLine("Enter your Grid Size starting from 3 to 5,7 ,9.. just odd Size");
            string userGridChoice = Console.ReadLine();
            int gridSize;
            bool userInputGridChoice = int.TryParse(userGridChoice, out gridSize);
            // User Game Choise Playlines
            Console.WriteLine($"Take Game option: {GAME_CENTER}, {GAME_HORIZONTAL_LINES}, {GAME_VERTICL_LINES}, {GAME_DIAGONAL_LINES}, {GAME_ALL_LINES} !");
            string userPlayGames = Console.ReadLine();
            int playerChoiseGames;
            bool userInputPlayGames = int.TryParse(userPlayGames, out playerChoiseGames);
            // Grid Variables´Size for user Choice 
            int rows = gridSize;
            int cols = FRAMING_GRID_COLS;

            ConsoleKeyInfo key;
            string[,] slotsGrid = new string[rows, cols];
            List<string> fruits = new List<string>();
            fruits.Add(RED_APPLE);
            fruits.Add(RED_CHERYS);
            fruits.Add(MANGO);
            fruits.Add(ORANGE);
            fruits.Add(GRAPES);
            int indexList = fruits.Count;
            Random randomList = new Random();
            // Validating User Imputs                         
            if (Math.Abs(gridSize % 2) == 1 && userInputGridChoice && userInputPlayGames)
            {
                bool winingIncrease = false;
                if (playerChoiseGames > STANDARD_GRID)
                {
                    Console.WriteLine("They are on Some Lines Bonuses");
                    winingIncrease = true;
                }
                else
                {

                    Console.WriteLine(" Bonus just by playing all Lines !!");
                }
                Console.WriteLine("To Play press Spacebar Key");
                int totalLines = 0;
                if (USER_GAME_CHOICE_ALL_LINES == playerChoiseGames)
                {

                    totalLines = gridSize + FRAMING_GRID_COLS + DIAGONAL_LINES;

                }
                else
                {
                    totalLines = gridSize;
                }
                int balance = CREDIT;
                //Main Game to play
                do
                {
                    key = Console.ReadKey();
                    Console.WriteLine();
                    Console.Clear();

                    for (int r = 0; r < cols; r++)
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
                        for (int r = 0; r < cols; r++)
                        {
                            Console.Write(FRAMING_GRID_SYMBOLS);
                        }
                        Console.WriteLine(FRAMING_GRID_CORNERS);

                    }
                    Console.WriteLine();
                    // Center Line Winings
                    bool gameWinnings = false;
                    int betTotalLines = totalLines * BET_PER_LINE;

                    if (playerChoiseGames == USER_GAME_CHOISE_CENTER)
                    {
                        int centerLineGrid = gridSize / GAME_MODE_MAIN_LINE_SUBSTRACTION;

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
                    if (playerChoiseGames != USER_GAME_CHOISE_CENTER)
                    {


                        if (playerChoiseGames == USER_GAME_CHOICE_HORIZONTAL || playerChoiseGames == USER_GAME_CHOICE_ALL_LINES)
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
                    if (playerChoiseGames != USER_GAME_CHOISE_CENTER)
                    {

                        if (playerChoiseGames == USER_GAME_CHOICE_VERTICAL || playerChoiseGames == USER_GAME_CHOICE_ALL_LINES)
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
                    if (playerChoiseGames == USER_GAME_CHOICE_DIAGONAL || playerChoiseGames == USER_GAME_CHOICE_ALL_LINES)
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


                } while (Math.Abs(balance) >= totalLines && key.Key == ConsoleKey.Spacebar);
            }
            else
            {
                Console.WriteLine("Please Enter an ODD Number Like 1,3,5....");
            }


        }
    }
}
