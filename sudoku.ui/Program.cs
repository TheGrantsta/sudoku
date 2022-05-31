using sudoku;
using sudoku.ui;

Console.WriteLine("Sudoku resolver!");
Console.WriteLine("****************");
Console.WriteLine("");

var grid = new Grid(new Resolver());

grid.Initialise();

<<<<<<< HEAD
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
=======
//Mild
//grid.Set(new[] { "165" });
//grid.Set(new[] { "254", "289", "297" });
//grid.Set(new[] { "357", "372", "384" });
//grid.Set(new[] { "453", "482" });
//grid.Set(new[] { "525", "533", "548" });
//grid.Set(new[] { "618", "666", "674", "691" });
//grid.Set(new[] { "735", "762", "787", "794" });
//grid.Set(new[] { "828", "834", "846", "879", "881" });
//grid.Set(new[] { "923", "964", "976" });

//Difficult
grid.Set(new[] { "148" });
grid.Set(new[] { "216", "255", "273" });
grid.Set(new[] { "334", "375", "388" });
grid.Set(new[] { "412", "435", "459", "463" });
grid.Set(new[] { "517", "562", "589" });
grid.Set(new[] { "647", "691" });
grid.Set(new[] { "719", "723", "765", "774" });
grid.Set(new[] { "814", "832" });
grid.Set(new[] { "928", "937", "954", "969", "982" });

//grid.Set(new[] { "742" });

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
>>>>>>> a0d929a933dc375f3943b73371102eda2ce3ec5f

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