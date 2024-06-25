namespace DotnetStarter.Logic;

public class Coordinates
{
    private readonly int _x1;
    private readonly int _y1;
    private readonly int _x2;
    private readonly int _y2;
    
    public Coordinates(int x1, int y1, int x2, int y2)
    {
        _x1 = x1;
        _y1 = y1;
        _x2 = x2;
        _y2 = y2;
    }

    public int GetX1()
    {
        return _x1;
    }
    
    public int GetY1()
    {
        return _y1;
    }
    
    public int GetX2()
    {
        return _x2;
    }
    
    public int GetY2()
    {
        return _y2;
    }
    
}