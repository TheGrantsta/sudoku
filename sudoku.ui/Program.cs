using sudoku;
using sudoku.ui;

Console.WriteLine("Sudoku resolver!");
Console.WriteLine("****************");
Console.WriteLine("");

var grid = new Grid(new Resolver());

grid.Initialise();

//Fiendish
grid.Set(new[] { "131", "157", "175", "194" });
grid.Set(new[] { "227", "251", "283" });
grid.Set(new[] { "313", "345", "399" });
grid.Set(new[] { "438", "467" });
grid.Set(new[] { "514", "521", "553", "588", "597" });
grid.Set(new[] { "642", "679" });
grid.Set(new[] { "711", "768", "792" });
grid.Set(new[] { "826", "854", "887" });
grid.Set(new[] { "918", "937", "952", "971" });

var render = new Render(grid);

render.Display();

Console.WriteLine("");
Console.WriteLine("*******************************");
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

Console.WriteLine("");
Console.WriteLine("");