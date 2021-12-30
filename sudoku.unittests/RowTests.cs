using System;
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

			row.Squares.Should().NotBeNullOrEmpty();
        }
	}
}

