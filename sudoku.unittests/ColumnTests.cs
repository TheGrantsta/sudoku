using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace sudoku.unittests
{
    public class ColumnTests
	{
		private readonly List<Row> _rows;

		public ColumnTests()
        {
			_rows = new List<Row>();

			for(int x = 1; x < 10; x++)
            {
				var row = new Row(A.Fake<IResolver>());

				row.Initialise(x);

				_rows.Add(row);
            }
        }

		[Fact]
		public void ShouldReturnListOfColumns()
		{
			var column = new Column(A.Fake<IResolver>());

			column.Initialise(_rows, 1);

			column.Squares
				.All(c => c.Coordinate.DisplayName.EndsWith("1"))
				.Should()
				.BeTrue();
			column.Squares.First().Coordinate.Should().BeEquivalentTo<Coordinate>(new Coordinate(1, 1));
			column.Squares.Last().Coordinate.Should().BeEquivalentTo<Coordinate>(new Coordinate(9, 1));
		}
	}
}

