using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blako_Slot_maschine
{

    internal class GameLogic
    {
        private static List<string> fruits = new List<string>();
        private static Random randomList = new Random();
        private const string RED_APPLE = "\U0001F34E";
        private const string RED_CHERYS = "\U0001F352";
        private const string MANGO = "\U0001F96D";
        private const string ORANGE = "\U0001F34A";
        private const string GRAPES = "\U0001F347";
        public const int STANDARD_GRID = 3;
        public const int CREDIT = 1000;
        public const int BET_PER_LINE = 1;
        public const int FRAMING_GRID_COLS = 5;
        public const int DIAGONAL_LINES = 2;
        public const int GAME_MODE_MAIN_LINE_SUBSTRACTION = 2;
        public const int USER_GAME_CHOISE_CENTER = 1;
        public const int USER_GAME_CHOICE_HORIZONTAL = 2;
        public const int USER_GAME_CHOICE_VERTICAL = 3;
        public const int USER_GAME_CHOICE_DIAGONAL = 4;
        public const int USER_GAME_CHOICE_ALL_LINES = 5;
        static GameLogic()
        {
            fruits.Add(RED_APPLE);
            fruits.Add(RED_CHERYS);
            fruits.Add(MANGO);
            fruits.Add(ORANGE);
            fruits.Add(GRAPES);

        }
        static string GetRandomFruits()
        {
            int indexList = randomList.Next(fruits.Count);
            return fruits[indexList];

        }
        public static string[,] GetSlotGridRandom(int rows, int cols)
        {
            string[,] slotsGrid = new string[rows, cols];


            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    slotsGrid[r, c] = GetRandomFruits();

                }

            }
            return slotsGrid;

        }

        public static int UserBetLines(int gridSize, int playerChoiseGames)
        {
            int totalLines;
            if (USER_GAME_CHOICE_ALL_LINES == playerChoiseGames)
            {

                totalLines = gridSize + FRAMING_GRID_COLS + DIAGONAL_LINES;

            }
            else if (USER_GAME_CHOISE_CENTER == playerChoiseGames)
            {
                totalLines = BET_PER_LINE;
            }
            else
            {
                totalLines = gridSize;
            }
            return totalLines;
        }
        public static bool CenterLinesWinnings(string[,] slotsGrid, int playerChoiseGames, int gridSize)
        {

            
            bool gameWinnings = false;
            
            int cols = FRAMING_GRID_COLS;
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
                    }

                }

            }
            return gameWinnings;
        }
        public static bool HorizontalLinesWinnings(string[,] slotsGrid, int playerChoiseGames, int rows)
        {

            bool gameWinnings = false;

            int cols = FRAMING_GRID_COLS;
            if (playerChoiseGames == USER_GAME_CHOICE_HORIZONTAL || USER_GAME_CHOICE_ALL_LINES == playerChoiseGames)
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
                    }

                }

            }
            return gameWinnings;
        }
        public static bool VerticalLinesWinnings(string[,] slotsGrid, int playerChoiseGames, int rows)
        {

            bool gameWinnings = false;
            int cols = FRAMING_GRID_COLS;
            if (playerChoiseGames == USER_GAME_CHOICE_VERTICAL || USER_GAME_CHOICE_ALL_LINES == playerChoiseGames)
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

                    }

                }
            }
            return gameWinnings;
        }
        public static bool DiagonalLineWinnings(string[,] slotsGrid, int playerChoiseGames, int rows)
        {
            bool gameWinnings = false;
            bool diagonalLeftWinnings = true;
            if (playerChoiseGames == USER_GAME_CHOICE_DIAGONAL || USER_GAME_CHOICE_ALL_LINES == playerChoiseGames)
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

                }

            }
            return gameWinnings;
        }
        public static int UserGameBalance(bool winnings, int gridSize, int playerChoiseGames, int balance)
        {
            int totalLines = UserBetLines(gridSize, playerChoiseGames);

            int betTotalLines = totalLines * BET_PER_LINE;
            if (!winnings)
            {
                balance -= betTotalLines;

            }
            else
            {
                balance += betTotalLines;
            }
            return balance;
        }
       
    }
}
