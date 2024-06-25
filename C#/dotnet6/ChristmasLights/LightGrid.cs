using System.Runtime.Intrinsics.X86;

namespace DotnetStarter.Logic;

public class LightGrid
{
    private readonly bool[,] _grid;
    
    public LightGrid(int size)
    {
        _grid = new bool[size, size];
    }

    public void TurnOnLight(int x, int y)
    {
        _grid[x, y] = true;
    }
    
    public void TurnOffLight(int x, int y)
    {
        _grid[x, y] = false;
    }
    
    public void ToggleLight(int x, int y)
    {
        _grid[x, y] = !_grid[x,y];
    }

    public bool IsOn(int x, int y)
    {
        return _grid[x, y];
    }
    
}