namespace sudoku
{
    public class Grid
	{
		private readonly List<Row> _rows;
		private readonly IResolver _resolver;

		public IReadOnlyList<Row> Rows => _rows;

		public Grid(IResolver resolver)
		{
			_rows = new List<Row>();
			_resolver = resolver;
		}

		public void Initialise()
		{
			for (int r = 1; r < 10; r++)
			{
				var row = new Row(_resolver);

				row.Initialise(r);

				_rows.Add(row);
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

		public void Resolve()
        {
			_rows.ForEach(r => r.Resolve());
        }
	}
}

