using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{

    public int maxWater;

    // Als er een nieuwe game wordt gestart, dan worden de values die in deze functie staan gebruikt:
    public GameData()
    {
        this.maxWater = 5;
    }
}
