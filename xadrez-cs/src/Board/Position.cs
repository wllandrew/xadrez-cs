namespace Board
{
    public struct Position(int row, int column)
    {
        public int Row { get; set; } = row;
        public int Column { get; set; } = column;

        public readonly bool Equals(Position pos)
        {
            return Row.Equals(pos) && Column.Equals(pos.Column);
        }
    }
}