using sudoku;
using sudoku.ui;

Console.WriteLine("Sudoku resolver!");
Console.WriteLine("****************");
Console.WriteLine("");

var grid = new Grid();

grid.Initialise();

grid.Set(new[] { "165" });
grid.Set(new[] { "254", "289", "297" });
grid.Set(new[] { "357", "372", "384" });
grid.Set(new[] { "453", "482" });
grid.Set(new[] { "525", "533", "548" });
grid.Set(new[] { "618", "666", "674", "691" });
grid.Set(new[] { "735", "762", "787", "794" });
grid.Set(new[] { "828", "834", "846", "879", "881" });
grid.Set(new[] { "923", "964", "976" });

var render = new Render(grid);

render.Display();

Console.WriteLine("");
Console.WriteLine("****************");
Console.WriteLine("");

Console.WriteLine("Hit ENTER key to see answer");
Console.ReadKey();

Console.WriteLine("");

grid.Set(new[] { "857", "862", "895" });

grid.Resolve();

render.Display();

Console.WriteLine("");
Console.WriteLine("****************");
