using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace sudoku.unittests
{
    public class IntersectTests
	{
		private readonly IResolver _resolver;
		private readonly Row _row;
		
		public IntersectTests()
		{
			_resolver = A.Fake<IResolver>();

			A.CallTo(() => _resolver.GetAllNumbers()).Returns(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
			A.CallTo(() => _resolver.IsOneSquareEmpty(A<List<Square>>.Ignored)).Returns(false);

			_row = new Row(_resolver);
		}

		[Fact]
		public void ShouldReturnOnlyPossibleOptionWhenRowAndColumnIntersect()
        {
			A.CallTo(() => _resolver.GetMissingNumbers(A<List<Square>>.Ignored)).Returns(new List<int> { 1, 7 });
			A.CallTo(() => _resolver.GetFoundNumbers(A<List<Square>>.Ignored)).Returns(new List<int> { 7, 9, 3, 6, 2, 5, 4, 8 });
			_row.Initialise(7);

			_row.Squares[0].Cell.Set(9);
			_row.Squares[1].Cell.Set(3);
			_row.Squares[2].Cell.Set(6);
			_row.Squares[3].Cell.Set(2);
			_row.Squares[5].Cell.Set(5);
			_row.Squares[6].Cell.Set(4);
			_row.Squares[8].Cell.Set(8);

			_row.Squares.Count(s => s.Cell.IsNumberFound).Should().Be(7);
			_row.Squares.Count(s => !s.Cell.IsNumberFound).Should().Be(2);

			var columnRow = new List<Row>();

			for (int x = 1; x < 10; x++)
			{
				var row = new Row(_resolver);

				row.Initialise(x);

				columnRow.Add(row);
			}

			var columns = new List<Column>();

			for (int c = 1; c < 10; c++)
            {
				var column = new Column(_resolver);

                if (c == 8)
                {
					columnRow[8].Squares[0].Cell.Set(7);

					columnRow[8].Squares.Count(s => s.Cell.IsNumberFound).Should().Be(1);
				}

				column.Initialise(columnRow, c);

				columns.Add(column);
			}

			var intersect = new Intersect(_resolver, _row, columns);

			intersect.Resolve();

			_row.Squares[7].Cell.IsNumberFound.Should().BeTrue();
			_row.Squares[7].Cell.Get().Should().Be(1);
		}
	}
}

