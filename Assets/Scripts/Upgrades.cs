using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades
{

    public string name;
    public int upgradeLevel;
    public double cost;
    public double costMultiplier;

    public int getLevel()
    {
        int level = upgradeLevel;
        return level;
    }



}
