using FluentAssertions;
using Xunit;

namespace sudoku.unittests
{
    public class StepsTests
	{
        [Fact]
		public void ShouldAddStep()
        {
            var steps = new Steps();

            steps.Add("A1", 1, false);

            steps.Get().TryDequeue(out Step step);

            step.Coordinate.Should().Be("A1");
            step.Value.Should().Be(1);
            step.IsGuess.Should().Be(false);
        }

        [Fact]
        public void ShouldRemoveGuessSteps()
        {
            var steps = new Steps();

            steps.Add("A1", 1, false);
            steps.Add("A2", 1, false);
            steps.Add("A3", 1, false);
            steps.Add("A4", 1, true);

            steps.RemoveGuesses();

            for(var i = 0; i < 4; i++)
            {
                steps.Get().TryDequeue(out _);
            }

            steps.Get().IsEmpty.Should().BeTrue();
        }
	}
}

