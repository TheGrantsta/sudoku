using System;
using FluentAssertions;
using Xunit;

namespace sudoku.unittests;

public class CellTests
{
    [Fact]
    public void ShouldReturnIsNumberFoundIsFalseWhenNotSet()
    {
        var cell = new Cell();

        cell.IsNumberFound.Should().BeFalse();
    }

    [Fact]
    public void ShouldReturnIsNumberFoundIsTrueWhenIsSet()
    {
        var cell = new Cell();

        cell.Set(1);

        cell.IsNumberFound.Should().BeTrue();
    }

    [Fact]
    public void ShouldThrowArgumentExceptionWhenSetNumbersIsLessThanOne()
    {
        var cell = new Cell();

        Action add = () => cell.Set(0);

        add.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void ShouldThrowArgumentExceptionWhenSetNumbersIsGreaterThanNine()
    {
        var cell = new Cell();

        Action add = () => cell.Set(10);

        add.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void ShouldReturnIsNumberFoundIsTrueWhenIsSetAndRemoveAllAlternatives()
    {
        var cell = new Cell();

        cell.Add(2);
        cell.Add(3);

        cell.Set(1);

        cell.IsNumberFound.Should().BeTrue();
        cell.Numbers.Should().BeEmpty();
    }

    [Fact]
    public void ShouldReturnIsNumberFoundIsTrueWhenIsSetAndPreventAlternativesBeingAdded()
    {
        var cell = new Cell();

        cell.Set(1);

        cell.Add(2);
        cell.Add(3);

        cell.IsNumberFound.Should().BeTrue();
        cell.Numbers.Should().BeEmpty();
    }

    [Fact]
    public void ShouldResetListOfNumbers()
    {
        var cell = new Cell();

        cell.Add(1);
        cell.Add(2);

        cell.Clear();

        cell.Numbers.Should().BeEmpty();
        cell.IsNumberFound.Should().BeFalse();
    }

    [Fact]
    public void ShouldReturnSetNumber()
    {
        var cell = new Cell();

        cell.Set(9);

        cell.Get().Should().Be(9);
    }

    [Fact]
    public void ShouldReturnIsEmptyIsTrueWhenNumbersIsEmpty()
    {
        var cell = new Cell();

        cell.Numbers.Should().BeEmpty();
    }

    [Fact]
    public void ShouldReturnIsEmptyIsFalseWhenNumbersIsNotEmpty()
    {
        var cell = new Cell();

        cell.Add(1);

        cell.Numbers.Should().NotBeEmpty();
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
}
