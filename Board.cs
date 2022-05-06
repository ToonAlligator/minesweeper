using System.Collections.Generic;

public class Board
{
    public int rows { get; set; }
    public int cols { get; set; }
    public int minesAmount { get; set; }
    public string[,] cells { get; set; }
    public List<(int,int)> mines { get; set; }

    public Board()
    {
        rows = 9;
        cols = 9;
        minesAmount = 10;
        cells = new string[rows,cols];
        for (int i =0; i < rows; i++)
        {
            for (int j=0; j< cols; j++)
            {
                cells[i,j] = "[ ]";
            }
        }
        mines = new();
    }
    public void Print()
    {
        for (int i =0; i < rows; i++)
        {
            for (int j=0; j< cols; j++)
            {
                Console.Write($"\t {cells[i,j]}");
            }
            Console.WriteLine();
        }    
    }

    public void setMines()
    {
        while (mines.Count < minesAmount)
        {
            (int,int) newMine;
            do
            {
                newMine = getRandomCoords();
            }
            while (mines.Contains(newMine));
            mines.Add(newMine);
        }
        foreach ((int,int) mine in mines)
        {
            cells[mine.Item1, mine.Item2] = "[*]";
        }
    }
    public (int,int) getRandomCoords()
    {
        var rand = new Random();
        int xMine = rand.Next(rows);
        int yMine = rand.Next(cols);

        return (xMine, yMine);
    }
}
