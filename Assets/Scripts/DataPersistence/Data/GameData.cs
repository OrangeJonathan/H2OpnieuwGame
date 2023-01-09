using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public double Water; // De hoeveelheid water in de opslagtank.   
    public double Money; // De hoeveelheid geld.

    public int ClickLevel; // Het level van de 'Click' upgrade.
    public int OpslagTankLevel; // Het level van de 'OpslagTank' upgrade.
    public int FunnelLevel; // Het level van de 'Funnel' upgrade.
    public int WaterFilterLevel; // Het level van de 'WaterFilter' upgrade.

    // Als er een nieuwe game wordt gestart, dan worden de values die in deze functie staan gebruikt:
    public GameData()
    {
        // Default Values when starting game.
        this.Water = 0;
        this.Money = 0;
        
        this.ClickLevel = 0;
        this.OpslagTankLevel = 0;
        this.FunnelLevel = 0;
        this.WaterFilterLevel = 0;
    }
}
