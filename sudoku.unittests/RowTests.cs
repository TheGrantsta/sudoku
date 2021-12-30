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
			var row = new Row(1);

			row.Squares.Should().NotBeNullOrEmpty();
			row.Squares.All(s => s.Cell.IsEmpty).Should().BeTrue();
			row.Squares.All(s => s.Coordinate.DisplayName.StartsWith("A")).Should().BeTrue();
		}
	}
}

