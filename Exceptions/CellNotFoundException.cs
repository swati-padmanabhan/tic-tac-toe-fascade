namespace TicTacToeFascade.Exceptions
{
    internal class CellNotFoundException : Exception
    {
        public CellNotFoundException(string message) : base(message) { }
    }
}
