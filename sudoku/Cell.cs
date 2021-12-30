namespace sudoku;

public class Cell
{
    private readonly List<int> _numbers;

    public IReadOnlyList<int> Numbers => _numbers;

    public bool IsEmpty => !Numbers.Any();

    public bool IsFound => Numbers.Count == 1;

    public Cell()
    {
        _numbers = new List<int>();
    }

    public void Add(int i)
    {
        if (IsOutOfRange(i))
        {
            throw new ArgumentOutOfRangeException($"Add parameter {i} out of range");
        }

        _numbers.Add(i);
    }

    private static bool IsOutOfRange(int i)
    {
        return i < 1 || i > 9;
    }
}

