using System;

namespace DotnetStarter.Logic;

public abstract class MainRunLoop
{
    /*
     * That represents a grid
     * Light manager -> Turn on, toggle, turn off
     * singleton pattern of only one grid
     */

    public static void Main(String[] args)
    {
        var lightManager = new LightManager(1000);
        lightManager.TurnOnRange(new Coordinates(887, 9, 959, 629));
        lightManager.TurnOnRange(new Coordinates(454, 398, 844, 448));
        lightManager.TurnOffRange(new Coordinates(539, 243, 559, 965));
        lightManager.TurnOffRange(new Coordinates(370, 819, 676, 868));
        lightManager.TurnOffRange(new Coordinates(145, 40, 370, 997));
        lightManager.TurnOffRange(new Coordinates(301, 3, 808, 453));
        lightManager.TurnOnRange(new Coordinates(351, 678, 951, 908));
        lightManager.ToggleRange(new Coordinates(720, 196, 897, 994));
        lightManager.ToggleRange(new Coordinates(831, 394, 904, 860));

        Console.WriteLine(lightManager.TotalLightsOn());
    }
}