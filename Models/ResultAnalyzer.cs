using TicTacToeFascade.Enums;

namespace TicTacToeFascade.Models
{
    //this class analyzes the board to determine the game's result
    internal class ResultAnalyzer
    {
        private readonly Board board;

        //constructor accepts the board to analyze
        public ResultAnalyzer(Board board)
        {
            this.board = board;
        }

        //analyzes the board and returns the result
        public ResultType AnalyzeResult()
        {
            //check for any win condition
            if (HorizontalWinCheck() || VerticalWinCheck() || DiagonalWinCheck())
            {
                return ResultType.WIN;
            }
            if (board.IsBoardFull())
            {
                return ResultType.DRAW;
            }
            return ResultType.PROGRESS;

        }

        //checks for a win in any horizontal row
        private bool HorizontalWinCheck()
        {
            //check rows for a win
            for (int i = 0; i <= 6; i += 3)
            {
                if (board.GetCell(i).Mark != MarkType.EMPTY &&
                    board.GetCell(i).Mark == board.GetCell(i + 1).Mark &&
                    board.GetCell(i).Mark == board.GetCell(i + 2).Mark)
                {
                    return true;
                }
            }
            return false;
        }

        private bool VerticalWinCheck()
        {
            //check columns for a win
            for (int i = 0; i <= 2; i++)
            {
                if (board.GetCell(i).Mark != MarkType.EMPTY &&
                    board.GetCell(i).Mark == board.GetCell(i + 3).Mark &&
                    board.GetCell(i).Mark == board.GetCell(i + 6).Mark)
                {
                    return true;
                }
            }
            return false;
        }

        private bool DiagonalWinCheck()
        {
            //check first diagonal(0, 4, 8)
            if (board.GetCell(0).Mark != MarkType.EMPTY &&
                board.GetCell(0).Mark == board.GetCell(4).Mark &&
                board.GetCell(0).Mark == board.GetCell(8).Mark)
            {
                return true;
            }
            //check second diagonal(2, 4, 6)
            if (board.GetCell(2).Mark != MarkType.EMPTY &&
                board.GetCell(2).Mark == board.GetCell(4).Mark &&
                board.GetCell(2).Mark == board.GetCell(6).Mark)
            {
                return true;
            }
            return false;
        }
    }
}
