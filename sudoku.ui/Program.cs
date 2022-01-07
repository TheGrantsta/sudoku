using sudoku;
using sudoku.ui;

Console.WriteLine("Sudoku resolver!");
Console.WriteLine("****************");
Console.WriteLine("");

var grid = new Grid(new Resolver());

grid.Initialise();

//Mild
grid.Set(new[] { "165" });
grid.Set(new[] { "254", "289", "297" });
grid.Set(new[] { "357", "372", "384" });
grid.Set(new[] { "453", "482" });
grid.Set(new[] { "525", "533", "548" });
grid.Set(new[] { "618", "666", "674", "691" });
grid.Set(new[] { "735", "762", "787", "794" });
grid.Set(new[] { "828", "834", "846", "879", "881" });
grid.Set(new[] { "923", "964", "976" });

//Super fiendish
//grid.Set(new[] { "196" });
//grid.Set(new[] { "238", "269", "274", "281", "292" });
//grid.Set(new[] { "322", "333", "341" });

//grid.Set(new[] { "434", "476", "497" });
//grid.Set(new[] { "589" });
//grid.Set(new[] { "626", "662", "675" });

//grid.Set(new[] { "729", "742", "761" });
//grid.Set(new[] { "823", "855", "898" });
//grid.Set(new[] { "914", "928", "943", "982", "995" });

var render = new Render(grid);

render.Display();

Console.WriteLine("");
Console.WriteLine("****************");
Console.WriteLine("");

Console.WriteLine("Hit ENTER key to see answer");
Console.ReadKey();

Console.WriteLine("");

grid.Resolve();

render.Display();

Console.WriteLine("");
Console.WriteLine("****************");
