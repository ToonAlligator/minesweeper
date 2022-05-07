// See https://aka.ms/new-console-template for more information
Console.WriteLine("Minesweeper!");
Board board = new();
board.setMines();
board.Print();

while (true)
{
    Console.WriteLine("set coords:");
    string? input = Console.ReadLine();
    string[] coords = input.Split(',');
    board.revealCell(int.Parse(coords[0]), int.Parse(coords[1]));
    board.Print();
}
