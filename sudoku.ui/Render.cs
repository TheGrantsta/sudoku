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
            ((List<Row>)_grid.Rows).ForEach(s => RowOuput(s));
        }

		private static void RowOuput(Row r)
        {
			((List<Square>)r.Squares).ForEach(s => SquareOutput(s));
			
			Console.WriteLine("");
        }

		private static void SquareOutput(Square square)
        {
			var cellString = square.Cell.IsFound ? $"|{square.Cell.Numbers.First()}|" : "|_|";

			Console.Write(cellString);
        }
	}
}

