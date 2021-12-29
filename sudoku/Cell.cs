namespace sudoku;

public class Cell
{
    public List<int> Numbers { get; set; }

    public Cell()
    {
        Numbers = new List<int>();
    }

    public bool IsEmpty()
    {
        return !Numbers.Any();
    }
}

