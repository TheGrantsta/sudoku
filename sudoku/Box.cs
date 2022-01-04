namespace sudoku
{
    public class Box
	{
		private readonly IResolver _resolver;
        private readonly List<Square> _squares;

        public List<Square> Squares => _squares;

		public Box(IResolver resolver)
		{
			_resolver = resolver;
            _squares = new List<Square>();
		}

        public void Initialise(List<Row> rows, Coordinate topLeft)
        {
            for (var x = 0; x < 3; x++)
            {
                for (var i = 0; i < 3; i++)
                {
                    var square = rows[topLeft.Row - 1 + x].Squares[topLeft.Column - 1 + i];

                    _squares.Add(square);
                }
            }
        }
    }
}

