namespace sudoku
{
    public interface IResolver
	{
		List<int> GetAllNumbers();

		bool IsOneSquareEmpty(List<Square> squares);

		List<int> GetFoundNumbers(List<Square> squares);
	}

    public class Resolver : IResolver
    {
        public List<int> GetAllNumbers()
        {
            return new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        }

        public bool IsOneSquareEmpty(List<Square> squares)
        {
            return squares.Count(s => !s.Cell.IsNumberFound) == 1;
        }

        public List<int> GetFoundNumbers(List<Square> squares)
        {
            return squares
                .Where(s => s.Cell.IsNumberFound)
                .Select(s => s.Cell.Get())
                .ToList();
        }
    }
}

