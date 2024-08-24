using TicTacToeFascade.Enums;
using TicTacToeFascade.Exceptions;

namespace TicTacToeFascade.Models
{

    //represents the tic tac toe board consisting of 9 cells
    internal class Board
    {
        private Cell[] cells = new Cell[9];


        //constructor initializes the board with 9 empty cells
        public Board()
        {
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i] = new Cell();
            }
        }


        //method to get a cell by its index
        public Cell GetCell(int loc)
        {
            if (loc < 0 || loc >= cells.Length)
            {
                throw new CellNotFoundException("Invalid cell index. Please provide a valid index between 0 and 8.");
            }
            return cells[loc];
        }

        //checks if all cells on the board are marked
        public bool IsBoardFull()
        {
            foreach (var cell in cells)
            {
                if (cell.IsEmpty())
                {
                    return false;
                }
            }
            return true;
        }

        //marks a cell at a specific location on the board
        public void SetCellMark(int loc, MarkType mark)
        {

            //ensure the location is valid before attempting to mark.
            if (loc < 0 || loc >= cells.Length)
            {
                throw new CellNotFoundException("Invalid cell index. Please provide a valid index between 0 and 8.");
            }
            cells[loc].SetMark(mark);
        }

        //prints the board 
        public void PrintBoard()
        {
            for (int i = 0; i < cells.Length; i++)
            {

                //print the mark in the cell, or a space if it is empty
                Console.Write(cells[i].GetMark() == MarkType.EMPTY ? " " : cells[i].GetMark().ToString());


                //print vertical dividers between cells, but not after the last cell in a row
                if ((i + 1) % 3 != 0)
                {
                    Console.Write(" | ");
                }

                //print horizontal divider after each row, except the last row
                if ((i + 1) % 3 == 0 && i < cells.Length - 1)
                {
                    Console.WriteLine("\n---------");
                }
            }

            Console.WriteLine();
        }
    }
}
