using System.Linq;
using FluentAssertions;
using Xunit;

namespace sudoku.unittests
{
	public class ResolverTests
	{
		[Fact]
		public void ShouldReturnNumbersOneToNine()
        {
			var numbers = new Resolver().GetAllNumbers();

			numbers.Count.Should().Be(9);
        }

        [Fact]
        public void ShouldReturnMissingNumbers()
        {
            Resolver resolver = new();

            Row row = new(resolver, new Steps());

            row.Initialise(2);

            for (var x = 0; x < 8; x++)
            {
                row.Squares[x].Cell.Set(x + 1);
            }

            var missingNumbers = resolver.GetMissingNumbers(row.Squares.ToList());

            missingNumbers.Count.Should().Be(1);
            missingNumbers.First().Should().Be(9);
        }
    }
}

