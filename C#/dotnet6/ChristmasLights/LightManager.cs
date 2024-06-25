namespace DotnetStarter.Logic;

public class LightManager
{
    private readonly LightGrid _grid ;
    private readonly int _size;
    public LightManager(int size)
    {
        _grid = new LightGrid(size);
        _size = size;
    }
    public void TurnOnRange(Coordinates coordinates)
    {
        IterateOver(coordinates, new LightOnSwitch());
    }
    public void TurnOffRange(Coordinates coordinates)
    {
        IterateOver(coordinates, new LightOffSwitch());
    }
    
    public void ToggleRange(Coordinates coordinates)
    {
        IterateOver(coordinates, new LightOffSwitch());
    }

    public int TotalLightsOn()
    {
        var result = 0;
        for (var i = 0; i < _size; i++)
        {
            for (var j = 0; j < _size; j++)
            {
                if (_grid.IsOn(i, j))
                    result++;
            }
        }
        return result;
    }

    private void IterateOver(Coordinates coordinates, LightSwitcher lightSwitcher)
    {
        for (var row = coordinates.GetX1(); row <= coordinates.GetX2(); row++)
        {
            for (var col = coordinates.GetY1(); col <= coordinates.GetY2(); col++)
            {
                lightSwitcher.Execute(_grid, row, col);
            }
        }
    }
}