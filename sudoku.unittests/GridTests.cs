using System.Linq;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace sudoku.unittests
{
    public class GridTests
	{
		[Fact]
		public void ShouldReturnEmptyRowsForGrid()
        {
			var grid = new Grid(A.Fake<IResolver>());

			grid.Initialise();

			grid.Rows.Should().NotBeNullOrEmpty();
			grid.Rows.Count.Should().Be(9);
        }

		[Fact]
		public void ShouldSetInitialValueForCoordinate()
        {
			var grid = new Grid(A.Fake<IResolver>());

			grid.Initialise();

			grid.Set(new[] { "165" });

			grid.Rows[0].Squares[5].Cell.IsNumberFound.Should().BeTrue();
			grid.Rows[0].Squares[5].Cell.Get().Should().Be(5);
			grid.Rows[0].Squares[5].Coordinate.Should().BeEquivalentTo<Coordinate>(new Coordinate(1, 6));

			grid.Columns[5].Squares[0].Cell.IsNumberFound.Should().BeTrue();
			grid.Columns[5].Squares[0].Cell.Get().Should().Be(5);
		}
	}
}

