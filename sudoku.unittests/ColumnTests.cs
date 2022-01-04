using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace sudoku.unittests
{
    public class ColumnTests
	{
		private readonly IResolver _resolver;
		private readonly List<Row> _rows;

		public ColumnTests()
        {
			_resolver = A.Fake<IResolver>();

			A.CallTo(() => _resolver.GetAllNumbers()).Returns(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
			A.CallTo(() => _resolver.IsOneSquareEmpty(A<List<Square>>.Ignored)).Returns(true);

			_rows = new List<Row>();

			for(int x = 1; x < 10; x++)
            {
				var row = new Row(_resolver);

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

		[Fact]
		public void ShouldFindLastNumberInColumn()
		{
			A.CallTo(() => _resolver.GetFoundNumbers(A<List<Square>>.Ignored))
                .Returns(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 });

			for(var r = 0; r < 8; r++)
            {
				_rows[r].Squares[0].Cell.Add(r + 1);
			}

			var column = new Column(_resolver);

			column.Initialise(_rows, 1);

			column.Resolve();

			column.Squares
				.All(c => c.Cell.IsFound)
				.Should()
				.BeTrue();
			column.Squares.First().Cell.Numbers.First().Should().Be(1);
			column.Squares.Last().Cell.Numbers.First().Should().Be(9);
		}
	}
}
