namespace sudoku.ui
{
    public class Render
	{
		private readonly Grid _grid;

		public Render(Grid grid)
		{
			_grid = grid;
		}

		public void Setup()
        {
            RenderGrid();

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Hit ENTER key to see answer");
            Console.ReadKey();
        }

        public void Result()
        {
            bool isResolved = _grid.Resolve();

            RenderGrid();

            if (isResolved)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Sudoku puzzle resolved!");
            }

            ShowSteps();

            Console.WriteLine("");
            Console.WriteLine("");
        }

        private void RenderGrid()
        {
            Console.WriteLine("");
            Console.WriteLine("Sudoku resolver!");
            Console.WriteLine("");
            Console.WriteLine("  *|A||B||C|*|D||E||F|*|G||H||I|*");
            Console.Write("  *******************************");

            ((List<Row>)_grid.Rows).ForEach(s => RowOuput(s));
        }

        private void ShowSteps()
        {
            Console.WriteLine("");
            Console.WriteLine("Steps");

            var steps = _grid.Steps.Get();
            var cnt = 1;

            do
            {
                steps.TryDequeue(out Step step);

                var foo = $"{cnt}: {step.Coordinate} -> {step.Value} / ";

                if (cnt % 6 == 0)
                {
                    Console.WriteLine(foo);
                }
                else
                {
                    Console.Write(foo);
                }

                cnt++;
            } while (!steps.IsEmpty);
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

