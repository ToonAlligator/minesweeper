// See https://aka.ms/new-console-template for more information
Console.WriteLine("Minesweeper!");
Board board = new();
board.setMines();
board.Print();

while (board.state == gameState.Active)
{
    Console.WriteLine("set coords:");
    string? input = Console.ReadLine();
    string[] coords = input.Split(',');
    board.revealCell(int.Parse(coords[0]), int.Parse(coords[1]));
    board.Print();
}
switch(board.state)
{
    case gameState.Win:
        Console.WriteLine("You Win");
        break;
    case gameState.Lose:
        Console.WriteLine("You Lose");
        break;
    default:
        Console.WriteLine("You broke the game :)");
        break;
}