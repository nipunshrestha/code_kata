namespace DotnetStarter.Logic;

public class LightToggleSwitch : LightSwitcher
{
    public void Execute(LightGrid grid, int row, int col)
    {
        grid.ToggleLight(row, col);
    }
}