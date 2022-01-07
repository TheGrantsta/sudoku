namespace sudoku
{
    public class Box
	{
		private readonly IResolver _resolver;
        private readonly List<Square> _squares;

        private List<Row> _rows;

        public List<Square> Squares => _squares;

		public Box(IResolver resolver)
		{
			_resolver = resolver;
            _squares = new List<Square>();
            _rows = new List<Row>();
		}

        public void Initialise(List<Row> rows, Coordinate topLeft)
        {
            _rows = rows;

            for (var x = 0; x < 3; x++)
            {
                for (var i = 0; i < 3; i++)
                {
                    var square = rows[topLeft.Row - 1 + x].Squares[topLeft.Column - 1 + i];

                    _squares.Add(square);
                }
            }
        }

        public void Find(List<Column> columns)
        {
            var boxNumbers = _resolver.GetFoundNumbers(_squares);

            foreach (var square in _squares.Where(c => c.Cell.IsEmpty && !c.Cell.IsNumberFound))
            {
                var rowNumbers = _resolver
                    .GetFoundNumbers(_rows[square.Coordinate.Row - 1].Squares
                    .ToList());

                var columnNumbers = _resolver
                    .GetFoundNumbers(columns[square.Coordinate.Column - 1].Squares
                    .ToList());

                foreach (var number in _resolver.GetAllNumbers())
                {
                    //Refactor this IF statement
                    if (!boxNumbers.Any(n => n == number) &&
                        !rowNumbers.Any(n => n == number) &&
                        !columnNumbers.Any(n => n == number))
                    {
                        square.Cell.Add(number);
                    }
                }
            }
        }

        public void Resolve()
        {
            if (_resolver.IsOneSquareEmpty(_squares))
            {
                var missingNumber = _resolver.GetAllNumbers().Except<int>(_resolver.GetFoundNumbers(_squares)).First();

                _squares.Single(s => !s.Cell.IsNumberFound).Cell.Set(missingNumber);
            }

            var numbersInBox = GetNumbersInBox();

            if (IsUniqueNumberInBox(numbersInBox, out NumberInBox numberInBox))
            {
                var square = _squares.Where(s => s.Coordinate.DisplayName == numberInBox.Coordinate).First();

                square.Cell.Set(numberInBox.Number);
            }
        }

        private List<NumberInBox> GetNumbersInBox()
        {
            var numbersInBox = new List<NumberInBox>();

            foreach (var square in _squares.Where(s => !s.Cell.IsNumberFound))
            {
                foreach (var number in square.Cell.Numbers)
                {
                    numbersInBox.Add(new NumberInBox { Coordinate = square.Coordinate.DisplayName, Number = number });
                }
            }

            return numbersInBox;
        }

        private static bool IsUniqueNumberInBox(List<NumberInBox> numbersInBox, out NumberInBox uniqueNumberInBox)
        {
            uniqueNumberInBox = new NumberInBox();

            var uniqueNumber = numbersInBox.GroupBy(n => n.Number).OrderBy(n => n.Count()).FirstOrDefault();

            if (uniqueNumber == null || uniqueNumber.Count() != 1)
            {
                return false;
            }

            uniqueNumberInBox = uniqueNumber.First();

            return true;
        }
    }

    internal struct NumberInBox
    {
        public string Coordinate { get; set; }

        public int Number { get; set; }
    }
}

