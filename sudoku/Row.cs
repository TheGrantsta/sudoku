using System;

namespace sudoku
{
	public class Row
	{
		private readonly List<Square> _squares;

		public IReadOnlyList<Square> Squares => _squares;

		public Row()
        {
			_squares = new List<Square>();
        }
	}
}

