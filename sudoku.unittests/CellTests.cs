using FluentAssertions;
using Xunit;

namespace sudoku.unittests;

public class CellTests
{
    [Fact]
    public void ShouldReturnIsEmptyIsTrueWhenNumbersIsEmpty()
    {
        var cell = new Cell();

        cell.IsEmpty().Should().BeTrue();
    }

    [Fact]
    public void ShouldReturnIsEmptyIsFalseWhenNumbersIsNotEmpty()
    {
        var cell = new Cell();

        cell.Numbers.Add(1);

        cell.IsEmpty().Should().BeFalse();
    }
}
