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

			grid.Rows.Should().NotBeNullOrEmpty();
			grid.Rows.Count.Should().Be(9);
        }
	}
}

