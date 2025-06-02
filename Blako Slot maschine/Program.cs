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

            Console.OutputEncoding = Encoding.UTF8;
            ConsoleKeyInfo key;

            GameUi.WelcomeMessage();

            int rows = GameUi.GetPlayerGridSizeInput();
            GameUi.AskUserForPlayLines();
            int playerChoiseGames = GameUi.GetPlayerGameLines();
            int cols = GameLogic.FRAMING_GRID_COLS;
            GameUi.GamestatusMessage("Please Press Spacebar key on your keyboard for play or ESC to quit!");
            int totalLines = GameLogic.UserBetLines(rows, playerChoiseGames);

            int balance = GameLogic.CREDIT;
            bool winnings = false;
            //Main Game to play
            do
            {

                key = Console.ReadKey();
                Console.WriteLine();
                Console.Clear();
                string[,] slotsGrid = GameLogic.GetSlotGridRandom(rows, cols);
                GameUi.DisplayGrid(slotsGrid);
                GameUi.ShowBalance(balance);
                GameUi.GamestatusMessage($"Aktual totallines:{totalLines}");
                bool gameCenterWinnings = GameLogic.CenterLinesWinnings(slotsGrid, rows, playerChoiseGames);
                bool gameHorizontalWinnings = GameLogic.HorizontalLinesWinnings(slotsGrid, rows, playerChoiseGames);
                bool gameVerticalWinnings = GameLogic.VerticalLinesWinnings(slotsGrid, rows, playerChoiseGames);
                bool gameDiagonalWinnings = GameLogic.DiagonalLineWinnings(slotsGrid, rows, playerChoiseGames);
                balance = GameLogic.UserGameBalance(winnings, rows, playerChoiseGames, balance);

                if (playerChoiseGames == GameLogic.USER_GAME_CHOISE_CENTER && gameCenterWinnings)
                {
                    winnings = true;
                    GameUi.GamestatusMessage($"Winn on Centerline{gameCenterWinnings}");

                }
                if (playerChoiseGames == GameLogic.USER_GAME_CHOICE_HORIZONTAL && gameHorizontalWinnings)
                {
                    GameUi.GamestatusMessage($"Congratulation you win!!");
                    winnings = true;
                }
                if (playerChoiseGames == GameLogic.USER_GAME_CHOICE_VERTICAL && gameVerticalWinnings)
                {
                    GameUi.GamestatusMessage($"Congratulation you win!!");
                    winnings = true;
                }
                if (playerChoiseGames == GameLogic.USER_GAME_CHOICE_DIAGONAL && gameDiagonalWinnings)
                {
                    GameUi.GamestatusMessage($"Congratulation you win!!");
                    winnings = true;
                }
                if (playerChoiseGames == GameLogic.USER_GAME_CHOICE_ALL_LINES && gameDiagonalWinnings && gameHorizontalWinnings && gameVerticalWinnings)
                {
                    GameUi.GamestatusMessage($"Congratulation you win!!");
                    winnings = true;
                }
                if(!gameCenterWinnings&&!gameDiagonalWinnings&&!gameHorizontalWinnings&&!gameVerticalWinnings)
                {
                    GameUi.GamestatusMessage($"You Lose try again!{winnings}");
                    winnings = false;
                  
                }
                

            } while (Math.Abs(balance) >= totalLines && key.Key == ConsoleKey.Spacebar);




        }
    }
}
