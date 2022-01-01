namespace sudoku
{
    public class Row
	{
		private readonly List<Square> _squares;

		public IReadOnlyList<Square> Squares => _squares;

		public Row()
        {
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
            if (IsOneSquareEmpty())
            {
                var missingNumber = GetAllNumbers().Except<int>(GetFoundNumbers()).First();

                _squares.Single(s => s.Cell.IsEmpty).Cell.Add(missingNumber);
            }
        }

        private bool IsOneSquareEmpty()
        {
            return _squares.Count(s => !s.Cell.IsFound) == 1;
        }

        private static List<int> GetAllNumbers()
        {
            return new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        }

        private List<int> GetFoundNumbers()
        {
            return _squares.Where(s => s.Cell.IsFound).Select(s => s.Cell.Numbers.First()).ToList();
        }
    }
}

