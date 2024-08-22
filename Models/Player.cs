using TicTacToeFascade.Enums;

namespace TicTacToeFascade.Models
{

    //represents a player in tic tac toe game
    internal class Player
    {
        public string Name { get; set; }
        public MarkType Mark { get; set; }

        //constructor initializes a player with a name and a mark
        public Player(string name, MarkType mark)
        {
            Name = name;
            Mark = mark;
        }
    }
}
