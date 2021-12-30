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
        if (i < 1 || i > 9)
        {
            throw new ArgumentOutOfRangeException($"Add parameter {i} out of range");
        }

        _numbers.Add(i);
    }
}

