using System;
using FluentAssertions;
using Xunit;

namespace sudoku.unittests
{
    public class CoordinateTests
    {
        [Fact]
        public void ShouldThrowArgumentExceptionWhenRowIsLessThanOne()
        {
            Action coord = () => new Coordinate(1, 0);

            coord.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ShouldThrowArgumentExceptionWhenColumnIsLessThanOne()
        {
            Action coord = () => new Coordinate(1, 0);

            coord.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void ShouldReturnConstructedProperties()
        {
            var coord = new Coordinate(2, 7);

            coord.Row.Should().Be(2);
            coord.Column.Should().Be(7);
        }

        [Theory]
        [InlineData(1, 6, "A6")]
        [InlineData(2, 6, "B6")]
        [InlineData(3, 6, "C6")]
        [InlineData(4, 6, "D6")]
        [InlineData(5, 6, "E6")]
        [InlineData(6, 6, "F6")]
        [InlineData(7, 6, "G6")]
        [InlineData(8, 6, "H6")]
        [InlineData(9, 6, "I6")]
        public void ShouldReturnDisplayName(int row, int column, string expected)
        {
            var coord = new Coordinate(row, column);

            coord.DisplayName.Should().Be(expected);
        }
    }
}

