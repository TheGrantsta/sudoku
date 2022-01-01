using System.Linq;
using FluentAssertions;
using Xunit;

namespace sudoku.unittests
{
    public class GridTests
	{
		[Fact]
		public void ShouldReturnEmptyRowsForGrid()
        {
			var grid = new Grid();

			grid.Initialise();

			grid.Rows.Should().NotBeNullOrEmpty();
			grid.Rows.Count.Should().Be(9);
        }

		[Fact]
		public void ShouldSetInitialValueForCoordinate()
        {
			var grid = new Grid();

			grid.Initialise();

			grid.Set(new[] { "165" });

			grid.Rows[0].Squares[5].Cell.IsEmpty.Should().BeFalse();
			grid.Rows[0].Squares[5].Cell.IsFound.Should().BeTrue();
			grid.Rows[0].Squares[5].Cell.Numbers.Single().Should().Be(5);
			grid.Rows[0].Squares[5].Coordinate.Should().BeEquivalentTo<Coordinate>(new Coordinate(1, 6));
        }
	}
}

