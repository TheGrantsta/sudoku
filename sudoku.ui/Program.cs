using sudoku;
using sudoku.ui;

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

render.Setup();

render.Result();