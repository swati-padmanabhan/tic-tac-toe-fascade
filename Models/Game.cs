﻿using TicTacToeFascade.Enums;
using TicTacToeFascade.Exceptions;
using TicTacToeFascade.View_Controllers;

namespace TicTacToeFascade.Models
{

    //manages the game logic
    internal class Game
    {
        public Board Board { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public ResultAnalyzer ResultAnalyzer { get; set; }
        public Player CurrentPlayer { get; set; }

        //constructor initializes the game with two players and a board
        public Game(Player player1, Player player2, Board board)
        {
            Player1 = player1;
            Player2 = player2;
            Board = board;
            CurrentPlayer = Player1;
            ResultAnalyzer = new ResultAnalyzer(board);
        }


        //main method to play the game
        public void PlayGame()
        {
            while (ResultAnalyzer.AnalyzeResult() == ResultType.PROGRESS && !Board.IsBoardFull())
            {
                Console.Clear();
                Menu.DisplayWelcomeMessage(Player1, Player2);
                Console.WriteLine($"Current Player: {CurrentPlayer.Name} with mark {CurrentPlayer.Mark}");

                //print the current state of the board
                Board.PrintBoard();
                int choice = Menu.GetPlayerChoice();

                try
                {
                    //try to mark the current cell with the current player's mark
                    Board.SetCellMark(choice, CurrentPlayer.Mark);
                }
                catch (CellAlreadyMarkedException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                    continue;
                }
                catch (CellNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An unexpected error occurred: " + ex.Message);
                    continue;
                }



                //check if the current move won the game
                if (ResultAnalyzer.AnalyzeResult() == ResultType.WIN)
                {
                    Console.Clear();
                    Menu.DisplayWelcomeMessage(Player1, Player2);
                    Board.PrintBoard();
                    Console.WriteLine("╔═══════════════════════════════╗");
                    Console.WriteLine($"║         {CurrentPlayer.Name} wins!          ║");
                    Console.WriteLine("╚═══════════════════════════════╝");
                    return;
                }

                //switch to the other player for the next turn
                CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;
            }

            //if the board is full and no one has won, it's a draw
            if (Board.IsBoardFull())
            {
                Console.Clear();
                Menu.DisplayWelcomeMessage(Player1, Player2);
                Board.PrintBoard();
                Console.WriteLine("╔═══════════════════════════════╗");
                Console.WriteLine("║          It's a draw!         ║");
                Console.WriteLine("╚═══════════════════════════════╝");
            }
        }



    }
}
