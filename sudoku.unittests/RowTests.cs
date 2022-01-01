using System.Linq;
using FluentAssertions;
using Xunit;

namespace sudoku.unittests
{
    public class RowTests
	{
		[Fact]
		public void ShouldReturnListOfSquares()
        {
			var row = new Row();

			row.Initialise(2);

			row.Squares.Should().NotBeNullOrEmpty();
			row.Squares.All(s => s.Cell.IsEmpty).Should().BeTrue();
			row.Squares.All(s => s.Coordinate.DisplayName.StartsWith("B")).Should().BeTrue();
		}

		[Fact]
		public void ShouldFindLastNumberInRow()
		{
			var row = new Row();

			row.Initialise(2);

			for (var x = 0; x < 9; x++)
			{
				row.Squares[x].Cell.Add(x + 1);
			}

			row.Resolve();

			row.Squares.All(s => s.Cell.IsFound).Should().BeTrue();
			row.Squares.Last().Cell.Numbers.First().Should().Be(9);
		}

		[Fact]
		public void ShouldFindLastNumberInRowWhenMiddleSquareIsEmpty()
		{
			var row = new Row();

			row.Initialise(2);

			for (var x = 0; x < 9; x++)
			{
				if (x != 5)
				{
					row.Squares[x].Cell.Add(x + 1);
				}
			}

			row.Resolve();

			row.Squares.All(s => s.Cell.IsFound).Should().BeTrue();
			row.Squares[5].Cell.Numbers.First().Should().Be(6);
		}
	}
}

