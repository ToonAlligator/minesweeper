using System.Collections.Generic;

public class Board
{
    public int rows { get; set; }
    public int cols { get; set; }
    public int minesAmount { get; set; }
    public List<Cell> cells { get; set; }
    public List<(int,int)> mines { get; set; }
    public gameState state { get; set; }

    public Board()
    {
        state = gameState.Active;
        rows = 9;
        cols = 9;
        minesAmount = 10;
        cells = new();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                cells.Add(new Cell(i,j));
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
                Console.Write($"\t [{cells.Where(x => x.coordX == i && x.coordY == j).First().value}]");
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
        
    }
    public (int,int) getRandomCoords()
    {
        var rand = new Random();
        int xMine = rand.Next(rows);
        int yMine = rand.Next(cols);

        return (xMine, yMine);
    }
    public void revealCell(int x, int y)
    {
        var cell = cells.Where(c => c.coordX == x && c.coordY == y).First();
        if (mines.Contains((x,y)))
        {
            cell.value = "*";
            state = gameState.Lose;
            return;
        }
        if (x < rows && y < cols)
        {
            int adjacentMinesCount = 0;
            for (int i = x-1; i <= x + 1; i++)
            {
                for (int j = y-1; j <= y + 1; j++)
                {
                    if (i >= 0 && j >= 0 && i < rows && j < cols)
                    {
                        if (mines.Contains((i,j)))
                        {
                            adjacentMinesCount++;
                        }
                    }
                }
            }
            cell.value = adjacentMinesCount.ToString();
            cell.state = cellState.Revealed;
            checkVictory();
        }
    }
    public void checkVictory()
    {
        if (cells.Where(c => c.value == " ").FirstOrDefault() == null)
        {
            state = gameState.Win;
        }
    }

    public void RevealMines(bool show)
    {
        if (show)
        {
            foreach ((int,int) mine in mines)
            {
                var cell = cells.Where(c => c.coordX == mine.Item1 && c.coordY == mine.Item2).First();
                cell.value = "*";
            }
        }
    }
}
