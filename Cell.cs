public class Cell
{
    public int coordX { get; set; }
    public int coordY { get; set; }
    public string value { get; set; }
    public cellState state { get; set; }

    public Cell(int x, int y)
    {
        coordX = x;
        coordY = y;
        value =  " ";
        state = cellState.Hidden;
    }
}