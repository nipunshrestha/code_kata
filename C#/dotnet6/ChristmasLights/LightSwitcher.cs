namespace DotnetStarter.Logic;

interface LightSwitcher
{
    public void Execute(LightGrid grid, int row, int col);
}