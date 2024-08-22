using TicTacToeFascade.Exceptions;
using TicTacToeFascade.Models;


namespace TicTacToeFascade.View_Controllers
{
    internal class Menu
    {

        //display menu at the start of the game
        public static void DisplayWelcomeMessage(Player player1, Player player2)
        {
            Console.WriteLine("╔═══════════════════════════════╗");
            Console.WriteLine("║    Welcome to Tic Tac Toe!    ║");
            Console.WriteLine("╠═══════════════════════════════╣");
            Console.WriteLine($"║     Player 1: {player1.Name} (X)      ║");
            Console.WriteLine($"║     Player 2: {player2.Name} (O)      ║");
            Console.WriteLine("╚═══════════════════════════════╝\n");
        }

        public static int GetPlayerChoice()
        {
            int choice;
            while (true)
            {
                Console.Write("Enter a position (0-8): ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    if (choice >= 0 && choice < 9)
                    {
                        return choice;
                    }
                    else
                    {
                        throw new InvalidInputException("Invalid input. Please enter a number between 0 and 8.");
                    }
                }
                catch (InvalidInputException iie)
                {
                    Console.WriteLine(iie.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input was not a valid number. Please try again.");
                }
            }
        }
    }
}
