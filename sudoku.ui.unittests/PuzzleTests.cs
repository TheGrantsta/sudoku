using FluentAssertions;
using Xunit;

namespace sudoku.ui.unittests;

public class PuzzleTests
{
    private readonly Grid _grid;

    public PuzzleTests()
    {
        _grid = new Grid(new Resolver(), new Steps());

        _grid.Initialise();
    }

    [Fact]
    public void ShouldCompleteMildPuzzle()
    {
        _grid.Set(new[] { "165" });
        _grid.Set(new[] { "254", "289", "297" });
        _grid.Set(new[] { "357", "372", "384" });
        _grid.Set(new[] { "453", "482" });
        _grid.Set(new[] { "525", "533", "548" });
        _grid.Set(new[] { "618", "666", "674", "691" });
        _grid.Set(new[] { "735", "762", "787", "794" });
        _grid.Set(new[] { "828", "834", "846", "879", "881" });
        _grid.Set(new[] { "923", "964", "976" });

        var isResolved = _grid.Resolve();

        isResolved.Should().BeTrue();
    }

    [Fact]
    public void ShouldCompleteDifficultPuzzle()
    {
        _grid.Set(new[] { "148" });
        _grid.Set(new[] { "216", "255", "273" });
        _grid.Set(new[] { "334", "375", "388" });
        _grid.Set(new[] { "412", "435", "459", "463" });
        _grid.Set(new[] { "517", "562", "589" });
        _grid.Set(new[] { "647", "691" });
        _grid.Set(new[] { "719", "723", "765", "774" });
        _grid.Set(new[] { "814", "832" });
        _grid.Set(new[] { "928", "937", "954", "969", "982" });
        _grid.Set(new[] { "742" });

        var isResolved = _grid.Resolve();

        isResolved.Should().BeTrue();
    }

    [Fact(Skip = "Not working")]
    public void ShouldCompleteFiendishPuzzle()
    {
        _grid.Set(new[] { "131", "157", "175", "194" });
        _grid.Set(new[] { "227", "251", "283" });
        _grid.Set(new[] { "313", "345", "399" });
        _grid.Set(new[] { "438", "467" });
        _grid.Set(new[] { "514", "521", "553", "588", "597" });
        _grid.Set(new[] { "642", "679" });
        _grid.Set(new[] { "711", "768", "792" });
        _grid.Set(new[] { "826", "854", "887" });
        _grid.Set(new[] { "918", "937", "952", "971" });

        var isResolved = _grid.Resolve();

        isResolved.Should().BeTrue();
    }

    [Fact(Skip = "Not working")]
    public void ShouldCompleteSuperFiendishPuzzle()
    {
        _grid.Set(new[] { "196" });
        _grid.Set(new[] { "238", "269", "274", "281", "292" });
        _grid.Set(new[] { "322", "333", "341" });
        _grid.Set(new[] { "434", "476", "497" });
        _grid.Set(new[] { "589" });
        _grid.Set(new[] { "626", "662", "675" });
        _grid.Set(new[] { "729", "742", "761" });
        _grid.Set(new[] { "823", "855", "898" });
        _grid.Set(new[] { "914", "928", "943", "982", "995" });

        var isResolved = _grid.Resolve();

        isResolved.Should().BeTrue();
    }
}
