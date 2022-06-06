using sudoku;
using sudoku.ui;

Console.WriteLine("");
Console.WriteLine("Sudoku resolver!");

var grid = new Grid(new Resolver(), new Steps());

grid.Initialise();

grid.Set(new[] { "148" });
grid.Set(new[] { "216", "255", "273" });
grid.Set(new[] { "334", "375", "388" });
grid.Set(new[] { "412", "435", "459", "463" });
grid.Set(new[] { "517", "562", "589" });
grid.Set(new[] { "647", "691" });
grid.Set(new[] { "719", "723", "765", "774" });
grid.Set(new[] { "814", "832" });
grid.Set(new[] { "928", "937", "954", "969", "982" });
grid.Set(new[] { "742" });

var render = new Render(grid);

render.Display();

Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("Hit ENTER key to see answer");
Console.ReadKey();

Console.WriteLine("");

bool isResolved = grid.Resolve();

render.Display();

if (isResolved)
{
    Console.WriteLine("");
    Console.WriteLine("Sudoku puzzle resolved!");
}

render.ShowSteps();

Console.WriteLine("");
Console.WriteLine("");