using sudoku;
using sudoku.ui;

Console.WriteLine("Sudoku resolver!");
Console.WriteLine("****************");
Console.WriteLine("");

var grid = new Grid(new Resolver());

grid.Initialise();

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