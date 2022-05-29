namespace sudoku
{
	public class Intersect
	{
		private readonly IResolver _resolver;
		private readonly Row _row;
		private readonly List<Column> _columns;

		public Intersect(IResolver resolver, Row row, List<Column> columns)
		{
			_resolver = resolver;
			_row = row;
			_columns = columns;
		}

		public void Resolve()
		{
			var missingNumbers = _resolver.GetMissingNumbers(_row.Squares.ToList());

			foreach (var square in _row.Squares.Where(s => !s.Cell.IsNumberFound))
			{
				var column = _columns.First(c => c.ColumnNumber == square.Coordinate.Column);

				var foundNumbers = _resolver.GetFoundNumbers(column.Squares.ToList());

				var uniqueNumbers = missingNumbers.Except<int>(foundNumbers);

				if (uniqueNumbers.Count() == 1)
				{
					square.Cell.Set(uniqueNumbers.First());
				}
			}
		}
	}
}

