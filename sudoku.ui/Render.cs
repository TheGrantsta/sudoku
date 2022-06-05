namespace sudoku.ui
{
    public class Render
	{
		private readonly Grid _grid;

		public Render(Grid grid)
		{
			_grid = grid;
		}

		public void Display()
        {
			Console.WriteLine("");
            Console.WriteLine("  *|A||B||C|*|D||E||F|*|G||H||I|*");
            Console.Write("  *******************************");

            ((List<Row>)_grid.Rows).ForEach(s => RowOuput(s));
        }

		private static void RowOuput(Row r)
        {
            Console.WriteLine("");

            Console.Write($"{r.Squares.First().Coordinate.Row}:");

            ((List<Square>)r.Squares).ForEach(s => SquareOutput(s));

            if (r.Squares.First().Coordinate.Row % 3 == 0)
            {
                Console.WriteLine("");
                Console.Write("  *******************************");
            }
        }

		private static void SquareOutput(Square square)
        {
            if (square.Coordinate.Column == 1)
            {
				Console.Write("*");
            }

			var cellString = square.Cell.IsNumberFound ? $"|{square.Cell.Get()}|" : "|_|";

			Console.Write(cellString);

            if (square.Coordinate.Column % 3 == 0)
            {
                Console.Write("*");
            }
        }
    }
}

