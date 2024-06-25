namespace DotnetStarter.Logic;

public class LightOnSwitch: LightSwitcher
{
    public void Execute(LightGrid grid, int row, int col)
    {
        grid.TurnOnLight(row, col);
    }
}