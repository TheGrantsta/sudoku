namespace sudoku;

public class Cell
{
    private readonly List<CellNumber> _numbers;

    public IReadOnlyList<CellNumber> Numbers => _numbers;

    public bool IsNumberFound => IsNumberFoundInList();

    private bool IsNumberFoundInList()
    {
        if (_numbers.Any())
        {
            return _numbers.First().Number > 0 && !_numbers.First().IsGuess;
        }

        return false;
    }

    public Cell()
    {
        _numbers = new List<CellNumber>();
    }

    public int Get()
    {
        return _numbers.Single().Number;
    }

    public void Set(int i)
    {
        if (IsOutOfRange(i))
        {
            throw new ArgumentOutOfRangeException($"Set parameter {i} out of range");
        }

        Clear();

        Add(i, false);
    }

    public void Add(int i, bool isGuess = true)
    {
        if (IsOutOfRange(i))
        {
            throw new ArgumentOutOfRangeException($"Add parameter {i} out of range");
        }

        if (IsUniqueAndNumberIsNotFound(i))
        {
            _numbers.Add(new CellNumber { Number = i, IsGuess = isGuess });
        }
    }

    private void Clear()
    {
        _numbers.Clear();
    }

    private static bool IsOutOfRange(int i)
    {
        return i < 1 || i > 9;
    }

    private bool IsUniqueAndNumberIsNotFound(int i)
    {
        return IsUnique(i) && IsNotFound();
    }

    private bool IsUnique(int i)
    {
        return !_numbers.Any(n => n.Number == i);
    }

    private bool IsNotFound()
    {
        return !IsNumberFound;
    }
}

public struct CellNumber
{
    public int Number { get; set; }

    public bool IsGuess { get; set; }
}

