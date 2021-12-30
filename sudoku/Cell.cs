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
        _numbers.Add(i);
    }
}

