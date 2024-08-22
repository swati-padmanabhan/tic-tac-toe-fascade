using TicTacToeFascade.Enums;
using TicTacToeFascade.Models;

namespace TicTacToeFascade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create two players
            Player player1 = new Player("Jackie", MarkType.X);
            Player player2 = new Player("Pokkie", MarkType.O);

            //create the game board
            Board board = new Board();

            //create the game instance
            Game game = new Game(player1, player2, board);

            //start the game
            game.PlayGame();
        }
    }
}
