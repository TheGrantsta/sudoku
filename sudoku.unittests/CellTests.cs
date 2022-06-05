using System;
using System.Linq;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace sudoku.unittests;

public class CellTests
{
    private Cell _cell;

    public CellTests()
    {
        var steps  = A.Fake<ISteps>();

        _cell = new Cell(steps);
    }
    [Fact]
    public void ShouldReturnIsNumberFoundIsFalseWhenNotSet()
    {
        _cell.IsNumberFound.Should().BeFalse();
    }

    [Fact]
    public void ShouldReturnIsNumberFoundIsTrueWhenIsSet()
    {
        _cell.Set(1);

        _cell.IsNumberFound.Should().BeTrue();
    }


    [Fact]
    public void ShouldThrowArgumentExceptionWhenSetIsCalledMoreThanOnce()
    {
        _cell.Set(2);

        Action add = () => _cell.Set(1);

        add.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void ShouldThrowArgumentExceptionWhenSetNumbersIsLessThanOne()
    {
        Action add = () => _cell.Set(0);

        add.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void ShouldThrowArgumentExceptionWhenSetNumbersIsGreaterThanNine()
    {
        Action add = () => _cell.Set(10);

        add.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void ShouldReturnIsNumberFoundIsTrueWhenIsSetAndRemoveAllAlternatives()
    {
        _cell.Add(2);
        _cell.Add(3);

        _cell.Set(1);

        _cell.IsNumberFound.Should().BeTrue();
        _cell.Numbers.Count().Should().Be(1);
        _cell.Numbers.First().Number.Should().Be(1);
    }

    [Fact]
    public void ShouldReturnIsNumberFoundIsTrueWhenIsSetAndPreventAlternativesBeingAdded()
    {
        _cell.Set(1);

        _cell.Add(2);
        _cell.Add(3);

        _cell.IsNumberFound.Should().BeTrue();
        _cell.Numbers.Count().Should().Be(1);
        _cell.Numbers.First().Number.Should().Be(1);
    }

    [Fact]
    public void ShouldReturnSetNumber()
    {
        _cell.Set(9);

        _cell.Get().Should().Be(9);
    }

    [Fact]
    public void ShouldReturnIsEmptyIsTrueWhenNumbersIsEmpty()
    {
        _cell.Numbers.Should().BeEmpty();
    }

    [Fact]
    public void ShouldReturnIsEmptyIsFalseWhenNumbersIsNotEmpty()
    {
        _cell.Add(1);

        _cell.Numbers.Should().NotBeEmpty();
    }

    [Fact]
    public void ShouldThrowArgumentExceptionWhenAddNumbersIsLessThanOne()
    {
        Action add = () => _cell.Add(0);

        add.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void ShouldThrowArgumentExceptionWhenAddNumbersIsGreaterThanNine()
    {
        Action add = () => _cell.Add(10);

        add.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void ShouldReturnDistinctListOfNumbers()
    {
        _cell.Add(1);
        _cell.Add(2);
        _cell.Add(1);

        _cell.Numbers.Count.Should().Be(2);
        _cell.Numbers.All(c => c.IsGuess).Should().BeTrue();
        _cell.Numbers[0].Number.Should().Be(1);
        _cell.Numbers[1].Number.Should().Be(2);
    }
}
