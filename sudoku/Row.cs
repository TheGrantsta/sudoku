using System;

namespace sudoku
{
	public class Row
	{
		private readonly List<Square> _squares;

		public IReadOnlyList<Square> Squares => _squares;

		public Row(int i)
        {
			_squares = new List<Square>();

			for (var x = 1; x < 10; x++)
			{
				_squares.Add(
					new Square(
						new Cell(),
						new Coordinate(i, x)));
			}
        }
	}
}

