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

<<<<<<< HEAD
                var square = _squares.Single(s => !s.Cell.IsNumberFound);
=======
                var square = _squares.Single(s => s.Cell.IsMissing);
>>>>>>> a0d929a933dc375f3943b73371102eda2ce3ec5f

                square.Cell.Set(missingNumber);

                Console.Write($"(C) {square.Coordinate.DisplayName} - {missingNumber}; ");
            }

            _squares.ForEach(s => s.Cell.Clear());
        }
    }
}

