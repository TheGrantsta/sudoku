namespace sudoku
{
    public class Column
	{
        private readonly IResolver _resolver;
		private readonly List<Square> _squares;

		public IReadOnlyList<Square> Squares => _squares;

        public Column(IResolver resolver)
        {
            _resolver = resolver;
            _squares = new List<Square>();
        }

		public void Initialise(List<Row> rows, int i)
		{
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

                _squares.Single(s => s.Cell.IsEmpty).Cell.Add(missingNumber);
            }
        }
    }
}

