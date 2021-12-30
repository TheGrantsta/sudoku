namespace sudoku;

public class Cell
{
    private List<int> _numbers;

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

        if (IsUnique(i))
        {
            _numbers.Add(i);
        }
    }

    public void Remove(int i)
    {
        if (IsOutOfRange(i))
        {
            throw new ArgumentOutOfRangeException($"Remove parameter {i} out of range");
        }

        if (IsNotFound())
        {
            _numbers = _numbers.Where(n => n != i).ToList();
        }
    }

    private static bool IsOutOfRange(int i)
    {
        return i < 1 || i > 9;
    }

    private bool IsUnique(int i)
    {
        return !_numbers.Any(n => n == i);
    }

    private bool IsNotFound()
    {
        return !IsFound;
    }
}

