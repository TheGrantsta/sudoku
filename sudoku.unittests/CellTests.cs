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

    [Fact]
    public void ShouldReturnDistinctListOfNumbers()
    {
        var cell = new Cell();

        cell.Add(1);
        cell.Add(2);
        cell.Add(1);

        cell.Numbers.Count.Should().Be(2);
        cell.Numbers[0].Should().Be(1);
        cell.Numbers[1].Should().Be(2);
    }

    [Fact]
    public void ShouldThrowArgumentExceptionWhenRemoveNumbersIsLessThanOne()
    {
        var cell = new Cell();

        Action add = () => cell.Remove(0);

        add.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void ShouldThrowArgumentExceptionWhenRemoveNumbersIsGreaterThanNine()
    {
        var cell = new Cell();

        Action add = () => cell.Remove(10);

        add.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void ShouldRemoveNumberFromListOfNumbers()
    {
        var cell = new Cell();

        cell.Add(1);
        cell.Add(2);

        cell.Remove(2);

        cell.Numbers.Count.Should().Be(1);
        cell.Numbers[0].Should().Be(1);
    }

    [Fact]
    public void ShouldNotRemoveNumberFromListOfNumbersWhenIsFoundIsTrue()
    {
        var cell = new Cell();

        cell.Add(2);

        cell.Remove(2);

        cell.Numbers.Count.Should().Be(1);
        cell.Numbers[0].Should().Be(2);
        cell.IsFound.Should().BeTrue();
    }

    [Fact]
    public void ShouldNotRemoveNumberFromListOfNumbersWhenNotInList()
    {
        var cell = new Cell();

        cell.Add(1);
        cell.Add(2);

        cell.Remove(3);

        cell.Numbers.Count.Should().Be(2);
        cell.Numbers[0].Should().Be(1);
        cell.Numbers[1].Should().Be(2);
    }

    [Fact]
    public void ShouldNotRemoveNumberWhenListOfNumbersIsEmpty()
    {
        var cell = new Cell();

        cell.Remove(2);

        cell.IsEmpty.Should().BeTrue();
    }
}
