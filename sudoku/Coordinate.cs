using System;

namespace sudoku
{
	public class Coordinate
	{
		private readonly int _row;

		private readonly int _column;

		public int Row => _row;

		public int Column => _column;

		public string DisplayName => GetDisplayName();

		public Coordinate(int row, int column)
		{
			if (IsOutOfRange(row))
			{
				throw new ArgumentOutOfRangeException($"Row parameter {row} out of range");
			}

			if (IsOutOfRange(column))
			{
				throw new ArgumentOutOfRangeException($"Column parameter {column} out of range");
			}

			_row = row;
			_column = column;
		}

		private string GetDisplayName()
        {
            var rowLetters = new string[]{ "A", "B", "C","D", "E", "F","G", "H", "I"};

			return $"{rowLetters[_row - 1]}{_column}";
        }

		private static bool IsOutOfRange(int i)
		{
			return i < 1 || i > 9;
		}
	}
}

