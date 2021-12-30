namespace sudoku
{
    public class Grid
	{
		private readonly List<Row> _rows;

		public IReadOnlyList<Row> Rows => _rows;

		public Grid()
		{
			_rows = new List<Row>();

            for (int r = 1; r < 10; r++)
            {
                _rows.Add(new Row(r));
            }
		}

		public void Set(string[] values)
		{
			foreach (var value in values)
			{
				var row = int.Parse(value.Substring(0, 1)) - 1;
				var column = int.Parse(value.Substring(1, 1)) - 1;
				var number = int.Parse(value.Substring(2, 1));

				_rows[row].Squares[column].Cell.Add(number);
			}
		}
	}
}

