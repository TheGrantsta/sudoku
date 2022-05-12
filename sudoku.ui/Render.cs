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

            ((List<Row>)_grid.Rows).ForEach(s => RowOuput(s));

            if (_grid.Rows.Any(r => r.Squares.Any(c => c.Cell.IsEmpty)))
            {
				Console.WriteLine("");
				Console.WriteLine("Sudoku puzzle NOT resolved!");
            }
        }

		private static void RowOuput(Row r)
        {
			((List<Square>)r.Squares).ForEach(s => SquareOutput(s));
			
			Console.WriteLine("");
        }

		private static void SquareOutput(Square square)
        {
			var cellString = square.Cell.IsNumberFound ? $"|{square.Cell.Get()}|" : "|_|";

			Console.Write(cellString);
        }
	}
}

