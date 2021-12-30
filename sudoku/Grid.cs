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
	}
}

