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
	}
}

