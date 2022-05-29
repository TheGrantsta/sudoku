namespace sudoku
{
    public class Grid
	{
		private readonly IResolver _resolver;
		private readonly List<Row> _rows;
		private readonly List<Column> _columns;
		private readonly List<Box> _boxes;

		public IReadOnlyList<Row> Rows => _rows;
		public IReadOnlyList<Column> Columns => _columns;
		public IReadOnlyList<Box> Boxes => _boxes;

		public Grid(IResolver resolver)
		{
			_resolver = resolver;
			_rows = new List<Row>();
			_columns = new List<Column>();
			_boxes = new List<Box>();
		}

		public void Initialise()
        {
            InitialiseRows();

            InitialiseColumns();

            InitialiseBoxes();
        }

        public void Set(string[] values)
		{
			foreach (var value in values)
			{
				var row = int.Parse(value.Substring(0, 1)) - 1;
				var column = int.Parse(value.Substring(1, 1)) - 1;
				var number = int.Parse(value.Substring(2, 1));

				_rows[row].Squares[column].Cell.Set(number);
			}
		}

		public void Resolve()
        {
			do
			{
				_rows.ForEach(r =>
				{
					r.Resolve();
                    new Intersect(_resolver, r, _columns).Resolve();
				});

				_columns.ForEach(c => c.Resolve());

				_boxes.ForEach(b => b.Resolve(_columns));

			} while (IsSquareToBeFound());
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

		private void InitialiseBoxes()
		{
			for (var r = 0; r < 3; r++)
			{
				for (var c = 0; c < 3; c++)
				{
					var box = new Box(_resolver);

					box.Initialise(_rows, new Coordinate(r * 3 + 1, c * 3 + 1));

					_boxes.Add(box);
				}
			}
		}

		private int loops = 0;

		private bool IsSquareToBeFound()
		{
			loops++;

			if(loops > 500)
            {
				return false;
            }

			return !_rows.All(r => r.Squares.All(s => s.Cell.IsNumberFound));
		}
	}
}

