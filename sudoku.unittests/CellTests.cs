using System;
using FluentAssertions;
using Xunit;

namespace sudoku.unittests;

public class CellTests
{
    [Fact]
    public void ShouldReturnIsEmptyIsTrueWhenNumbersIsEmpty()
    {
        var cell = new Cell();

        cell.IsEmpty.Should().BeTrue();
    }

    [Fact]
    public void ShouldReturnIsEmptyIsFalseWhenNumbersIsNotEmpty()
    {
        var cell = new Cell();

        cell.Add(1);

        cell.IsEmpty.Should().BeFalse();
    }

    [Fact]
    public void ShouldReturnIsFoundIsFalseWhenNumbersHasOnlyOneNumber()
    {
        var cell = new Cell();

        cell.IsFound.Should().BeFalse();
    }

    [Fact]
    public void ShouldReturnIsFoundIsTrueWhenNumbersHasOnlyOneNumber()
    {
        var cell = new Cell();

        cell.Add(9);

        cell.IsFound.Should().BeTrue();
    }

    [Fact]
    public void ShouldThrowArgumentExceptionWhenAddNumbersIsLessThanOne()
    {
        var cell = new Cell();

        Action add = () => cell.Add(0);

        add.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void ShouldThrowArgumentExceptionWhenAddNumbersIsGreaterThanNine()
    {
        var cell = new Cell();

        Action add = () => cell.Add(10);

        add.Should().Throw<ArgumentOutOfRangeException>();
    }
}
