using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Blako_Slot_maschine
{
    internal class GameUi
    {
        public const string FRAMING_GRID_SYMBOLS = "+--";
        public const string FRAMING_GRID_CORNERS = "+";
        public const string FRAMING_GRID_VERTICAL_LINES = "|";
        public const string GAME_CENTER = "Center Line = 1";
        public const string GAME_HORIZONTAL_LINES = "Horizontal Lines = 2";
        public const string GAME_VERTICL_LINES = "Vertical Lines = 3";
        public const string GAME_DIAGONAL_LINES = "Diagonal Lines = 4";
        public const string GAME_ALL_LINES = "All Lines = 5";
        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Fruits Wars!!\n");
            Console.Write("3x5 Grid Are Standard Game\n");
        }
        public static void GamestatusMessage(string message)
        {
            Console.WriteLine(message);
        }
        static void AskUserForGridSize()
        {
            Console.WriteLine("Enter your Grid Size starting from 3 to 5,7 ,9.. just odd Size");
        }
        public static void AskUserForPlayLines()
        {
            Console.WriteLine($"Take Game option: {GAME_CENTER}, {GAME_HORIZONTAL_LINES}, {GAME_VERTICL_LINES}, {GAME_DIAGONAL_LINES}, {GAME_ALL_LINES} !");
        }
        public static void DisplayGrid(string[,] slotsGrid)
        {
            int rows = slotsGrid.GetLength(0);
            int cols = slotsGrid.GetLength(1);

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
        }
        public static int GetPlayerGridSizeInput()
        {
            int gridSize = 0;
            bool userInputGridChoice = false;

            while (!userInputGridChoice)
            {
                AskUserForGridSize();
                string userGridChoice = Console.ReadLine();
                if (int.TryParse(userGridChoice, out gridSize) && gridSize >= 3 && Math.Abs(gridSize % 2) == 1)
                {
                    userInputGridChoice = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter an odd number like 3, 5, 7, 9...");
                    continue;
                }

            }
            return gridSize;
        }
        public static int GetPlayerGameLines()
        {
            int playerChoiseGames = 0;
            bool userInputPlayGames = false;
            while (!userInputPlayGames)
            {
                string userPlayGames = Console.ReadLine();
                if (int.TryParse(userPlayGames, out playerChoiseGames))
                {
                    userInputPlayGames = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number for game option.");
                }
            }
            return playerChoiseGames;
        }
        public static bool WinningIncrease(int standardGrid, int playerChoiceGames)
        {
            bool winingIncrease = false;
            if (playerChoiceGames > standardGrid)
            {
                Console.WriteLine("They are on Some Lines Bonuses");
                winingIncrease = true;
            }
            else
            {

                Console.WriteLine(" Bonus just by playing all Lines !!");
            }
            return winingIncrease;
        }
        public static void ShowBalance(int balance)
        {
            Console.WriteLine($"your balance:{balance}");
        }
        public static void ShowPayLines(int payLines)
        {
            Console.WriteLine($"Credits pays:{payLines}");
        }
    }
}
