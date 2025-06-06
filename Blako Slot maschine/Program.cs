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
                bool gameCenterWinnings = false, gameHorizontalWinnings = false, gameVerticalWinnings = false, gameDiagonalWinnings = false;
                bool winnings = false;
                if (playerChoiseGames == GameLogic.USER_GAME_CHOISE_CENTER)
                {
                     gameCenterWinnings = GameLogic.CenterLinesWinnings(slotsGrid, rows, playerChoiseGames);
                   
                }
                if (playerChoiseGames == GameLogic.USER_GAME_CHOICE_HORIZONTAL)
                {
                    gameHorizontalWinnings = GameLogic.HorizontalLinesWinnings(slotsGrid, rows, playerChoiseGames);
                }
                if (playerChoiseGames == GameLogic.USER_GAME_CHOICE_VERTICAL)
                {
                    gameVerticalWinnings = GameLogic.VerticalLinesWinnings(slotsGrid, rows, playerChoiseGames);
                }
                if (playerChoiseGames == GameLogic.USER_GAME_CHOICE_DIAGONAL)
                {
                    gameDiagonalWinnings = GameLogic.DiagonalLineWinnings(slotsGrid, rows, playerChoiseGames);
                }
                if (playerChoiseGames == GameLogic.USER_GAME_CHOICE_ALL_LINES)
                {
                    gameHorizontalWinnings = GameLogic.HorizontalLinesWinnings(slotsGrid, rows, playerChoiseGames);
                    gameVerticalWinnings = GameLogic.VerticalLinesWinnings(slotsGrid, rows, playerChoiseGames);
                    gameDiagonalWinnings = GameLogic.DiagonalLineWinnings(slotsGrid, rows, playerChoiseGames);
                }
                                                               
                
                if (gameCenterWinnings)
                {
                    winnings = true;
                    GameUi.GamestatusMessage($"Winn on Centerline{gameCenterWinnings}");

                }
                if (gameHorizontalWinnings)
                {
                    GameUi.GamestatusMessage($"Congratulation you win!!");
                    winnings = true;
                }
                if (gameVerticalWinnings)
                {
                    GameUi.GamestatusMessage($"Congratulation you win!!");
                    winnings = true;
                }
                if (gameDiagonalWinnings)
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
                balance = GameLogic.UserGameBalance(winnings, rows, playerChoiseGames, balance);


            } while (Math.Abs(balance) >= totalLines && key.Key == ConsoleKey.Spacebar);




        }
    }
}
