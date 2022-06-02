namespace sudoku;

public class Cell
{
    private readonly List<CellNumber> _numbers;

    private CellNumber _cellNumber;

    public IReadOnlyList<CellNumber> Numbers => _numbers;

    public bool IsNumberFound => _cellNumber.Number > 0 && !_cellNumber.IsGuess;

    public bool IsEmpty => !_numbers.Any();

    public Cell()
    {
        _numbers = new List<CellNumber>();
    }

    public int Get()
    {
        return _cellNumber.Number;
    }

    public void Set(int i)
    {
        if (IsOutOfRange(i))
        {
            throw new ArgumentOutOfRangeException($"Set parameter {i} out of range");
        }

        Clear();

        _cellNumber = new CellNumber { Number = i };
    }

    public void Add(int i)
    {
        if (IsOutOfRange(i))
        {
            throw new ArgumentOutOfRangeException($"Add parameter {i} out of range");
        }

        if (IsUniqueAndNumberIsNotFound(i))
        {
            _numbers.Add(new CellNumber { Number = i, IsGuess = true });
        }
    }

    public void Clear()
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

