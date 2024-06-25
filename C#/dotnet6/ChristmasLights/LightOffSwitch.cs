namespace DotnetStarter.Logic;

public class LightOffSwitch: LightSwitcher
{
    public void Execute(LightGrid grid, int row, int col)
    {
        grid.TurnOffLight(row,col);
    }
}