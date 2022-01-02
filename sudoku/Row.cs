namespace sudoku
{
    public class Row
	{
		private readonly List<Square> _squares;
        private readonly IResolver _resolver;

		public IReadOnlyList<Square> Squares => _squares;

		public Row(IResolver resolver)
        {
			_squares = new List<Square>();
            _resolver = resolver;
        }

        public void Initialise(int i)
        {
            for (var x = 1; x < 10; x++)
            {
                _squares.Add(
                    new Square(
                        new Cell(),
                        new Coordinate(i, x)));
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

