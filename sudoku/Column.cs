namespace sudoku
{
    public class Column
	{
        private readonly IResolver _resolver;
		private readonly List<Square> _squares;
        private int _columnNumber;

		public IReadOnlyList<Square> Squares => _squares;
        public int ColumnNumber => _columnNumber;

        public Column(IResolver resolver)
        {
            _resolver = resolver;
            _squares = new List<Square>();
        }

		public void Initialise(List<Row> rows, int i)
		{
            _columnNumber = i;

            foreach(var row in rows)
            {
				foreach(var square in row.Squares)
                {
                    if (square.Coordinate.Column == i)
                    {
                        _squares.Add(square);
                    }
                }
            }
		}

        public void Resolve()
        {
            if (_resolver.IsOneSquareEmpty(_squares))
            {
                var missingNumber = _resolver.GetAllNumbers().Except<int>(_resolver.GetFoundNumbers(_squares)).First();

                var square = _squares.Single(s => !s.Cell.IsNumberFound);

                square.Cell.Set(missingNumber);

                Console.Write($"(C) {square.Coordinate.DisplayName} - {missingNumber}; ");
            }
        }
    }
}

