namespace sudoku
{
    public class Square
	{
		private readonly Cell _cell;

        private readonly Coordinate _coordinate;

        public Cell Cell => _cell;

		public Coordinate Coordinate => _coordinate;

        public Square(Cell cell, Coordinate coordinate)
		{
			_cell = cell;
			_coordinate = coordinate;
		}
    }
}

