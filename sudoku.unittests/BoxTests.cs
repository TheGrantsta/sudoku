using System;
using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace sudoku.unittests
{
	public class BoxTests
	{
		private readonly IResolver _resolver;
		private readonly List<Row> _rows;

		public BoxTests()
		{
			_resolver = A.Fake<IResolver>();

			A.CallTo(() => _resolver.GetAllNumbers()).Returns(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
			A.CallTo(() => _resolver.IsOneSquareEmpty(A<List<Square>>.Ignored)).Returns(true);

			_rows = new List<Row>();

			for (int x = 1; x < 10; x++)
			{
				var row = new Row(_resolver);

				row.Initialise(x);

				_rows.Add(row);
			}
		}

		[Theory]
		[InlineData(1, 1, "A1", "C3")]
		[InlineData(1, 4, "A4", "C6")]
		[InlineData(1, 7, "A7", "C9")]
		[InlineData(4, 1, "D1", "F3")]
		[InlineData(4, 4, "D4", "F6")]
		[InlineData(4, 7, "D7", "F9")]
		[InlineData(7, 1, "G1", "I3")]
		[InlineData(7, 4, "G4", "I6")]
		[InlineData(7, 7, "G7", "I9")]
		public void ShouldReturnListOfBoxes(int row, int column, string topLeft, string bottomRight)
		{
			var box = new Box(_resolver);

			box.Initialise(_rows, new Coordinate(row, column));

			box.Squares.All(s => s.Cell.IsEmpty).Should().BeTrue();
			box.Squares.Count.Should().Be(9);
			box.Squares.First().Coordinate.DisplayName.Should().Be(topLeft);
			box.Squares.Last().Coordinate.DisplayName.Should().Be(bottomRight);
		}

		[Fact]
		public void ShouldFindLastNumberInBox()
		{
			A.CallTo(() => _resolver.GetFoundNumbers(A<List<Square>>.Ignored))
				.Returns(new List<int> { 1, 2, 3, 5, 6, 7, 8, 9 });

			_rows[0].Squares[0].Cell.Set(1);
			_rows[0].Squares[1].Cell.Set(2);
			_rows[0].Squares[2].Cell.Set(3);
			_rows[1].Squares[1].Cell.Set(5);
			_rows[1].Squares[2].Cell.Set(6);
			_rows[2].Squares[0].Cell.Set(7);
			_rows[2].Squares[1].Cell.Set(8);
			_rows[2].Squares[2].Cell.Set(9);

			var box = new Box(_resolver);

			box.Initialise(_rows, new Coordinate(1, 1));

			box.Resolve();

			box.Squares
				.All(c => c.Cell.IsNumberFound)
				.Should()
				.BeTrue();
			box.Squares[3].Cell.Get().Should().Be(4);
		}
	}
}

