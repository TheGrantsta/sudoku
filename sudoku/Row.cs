namespace sudoku
{
    public class Row
	{
		private readonly IResolver _resolver;
        private readonly List<Square> _squares;

        public IReadOnlyList<Square> Squares => _squares;

		public Row(IResolver resolver)
        {
            _resolver = resolver;
            _squares = new List<Square>();
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

