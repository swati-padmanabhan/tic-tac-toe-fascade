using TicTacToeFascade.Enums;
using TicTacToeFascade.Exceptions;

namespace TicTacToeFascade.Models
{

    //represents the cell on the tic tac toe board
    internal class Cell
    {
        public MarkType Mark { get; private set; }

        //constructor initializes the class as empty
        public Cell()
        {
            Mark = MarkType.EMPTY;
        }


        //check if the cell is empty
        public bool IsEmpty()
        {
            return Mark == MarkType.EMPTY;
        }

        //sets a mark on the cell
        public void SetMark(MarkType mark)
        {
            if (!IsEmpty())
            {
                throw new CellAlreadyMarkedException("Cell is Already Marked");
            }
            Mark = mark;
        }


        //gets the current mark of the cell
        public MarkType GetMark()
        {
            return Mark;
        }


    }
}