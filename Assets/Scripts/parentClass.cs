using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class parentClass : MonoBehaviour
{

    

}


[System.Serializable]
public class Upgrades
{
    public string nameUpgrade;
    public int upgradeLevel;
    public double cost;
    public double costMultiplier;

    public int getLevel()
    {
        int level = upgradeLevel;
        return level;
    }
}