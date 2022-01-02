using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace sudoku.unittests
{
    public class RowTests
	{
		private readonly IResolver _resolver;
		private readonly Row _row;

		public RowTests()
		{
			_resolver = A.Fake<IResolver>();

			A.CallTo(() => _resolver.GetAllNumbers()).Returns(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
			A.CallTo(() => _resolver.IsOneSquareEmpty(A<List<Square>>.Ignored)).Returns(true);

			_row = new Row(_resolver);
		}

		[Theory]
        [InlineData(1, "A")]
		[InlineData(2, "B")]
		[InlineData(3, "C")]
		[InlineData(4, "D")]
		[InlineData(5, "E")]
		[InlineData(6, "F")]
		[InlineData(7, "G")]
		[InlineData(8, "H")]
		[InlineData(9, "I")]
		public void ShouldReturnListOfSquares(int rowNumber, string columnLetter)
        {
			_row.Initialise(rowNumber);

			_row.Squares.Should().NotBeNullOrEmpty();
			_row.Squares.All(s => s.Cell.IsEmpty).Should().BeTrue();
			_row.Squares.All(s => s.Coordinate.DisplayName.StartsWith(columnLetter)).Should().BeTrue();
		}

		[Fact]
		public void ShouldFindLastNumberInRow()
		{
			A.CallTo(() => _resolver.GetFoundNumbers(A<List<Square>>.Ignored)).Returns(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 });

			_row.Initialise(2);

			for (var x = 0; x < 8; x++)
			{
				_row.Squares[x].Cell.Add(x + 1);
			}

			_row.Resolve();

			_row.Squares.All(s => s.Cell.IsFound).Should().BeTrue();
			_row.Squares.Last().Cell.Numbers.First().Should().Be(9);
		}

		[Fact]
		public void ShouldFindLastNumberInRowWhenMiddleSquareIsEmpty()
		{
			A.CallTo(() => _resolver.GetFoundNumbers(A<List<Square>>.Ignored)).Returns(new List<int> { 1, 2, 3, 4, 6, 7, 8, 9 });

			_row.Initialise(2);

			for (var x = 0; x < 9; x++)
			{
				if (x != 5)
				{
					_row.Squares[x].Cell.Add(x + 1);
				}
			}

			_row.Resolve();

			_row.Squares.All(s => s.Cell.IsFound).Should().BeTrue();
			_row.Squares[0].Cell.Numbers.First().Should().Be(1);
			_row.Squares[4].Cell.Numbers.First().Should().Be(5);
			_row.Squares[8].Cell.Numbers.First().Should().Be(9);
		}
	}
}

