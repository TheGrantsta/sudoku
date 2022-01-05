﻿namespace sudoku;

public class Cell
{
    private List<int> _numbers;

    private int _number;

    public IReadOnlyList<int> Numbers => _numbers;

    public bool IsEmpty => !_numbers.Any();

    public bool IsNumberFound => _number > 0;

    public Cell()
    {
        Reset();
    }

    public int Get()
    {
        return _number;
    }

    public void Set(int i)
    {
        if (IsOutOfRange(i))
        {
            throw new ArgumentOutOfRangeException($"Set parameter {i} out of range");
        }

        Reset();

        _number = i;
    }

    public void Add(int i)
    {
        if (IsOutOfRange(i))
        {
            throw new ArgumentOutOfRangeException($"Add parameter {i} out of range");
        }

        if (IsUniqueAndNumberIsNotFound(i))
        {
            _numbers.Add(i);
        }
    }

    public void Reset()
    {
        _numbers = new List<int>();
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
        return !_numbers.Any(n => n == i);
    }

    private bool IsNotFound()
    {
        return !IsNumberFound;
    }
}

