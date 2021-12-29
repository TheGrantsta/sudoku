namespace sudoku;

public class Cell
{
    private readonly List<int> _numbers;

    public IReadOnlyList<int> Numbers => _numbers;

    public Cell()
    {
        _numbers = new List<int>();
    }

    public void Add(int i)
    {
        _numbers.Add(i);
    }

    public bool IsEmpty()
    {
        return !Numbers.Any();
    }

    public bool IsFound()
    {
        throw new NotImplementedException();
    }
}

