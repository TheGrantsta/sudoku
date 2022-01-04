namespace sudoku
{
    public class Grid
	{
		private readonly IResolver _resolver;
		private readonly List<Row> _rows;
		private readonly List<Column> _columns;

		public IReadOnlyList<Row> Rows => _rows;
		public IReadOnlyList<Column> Columns => _columns;

		public Grid(IResolver resolver)
		{
			_resolver = resolver;
			_rows = new List<Row>();
			_columns = new List<Column>();
		}

		public void Initialise()
        {
            InitialiseRows();

            InitialiseColumns();
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

			_columns.ForEach(c => c.Resolve());
		}

		private void InitialiseRows()
		{
			for (int r = 1; r < 10; r++)
			{
				var row = new Row(_resolver);

				row.Initialise(r);

				_rows.Add(row);
			}
		}

		private void InitialiseColumns()
		{
			for (int c = 1; c < 10; c++)
			{
				var column = new Column(_resolver);

				column.Initialise(_rows, c);

				_columns.Add(column);
			}
		}
	}
}

