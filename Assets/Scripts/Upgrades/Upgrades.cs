using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Upgrades : MonoBehaviour
{

    public string nameUpgrade;
    public double cost;
    public double costMultiplier;
    public int upgradeLevel;

}

public class IncreaseMaxUpgrade : Upgrades
{
    public Upgrades increaseMax = new();

    public void Start()
    {
        increaseMax.nameUpgrade = "Click Upgrade";
        increaseMax.cost = 1;
        increaseMax.costMultiplier = 1;
        increaseMax.upgradeLevel = 0;
    }

}

public class FunnelUpgrade : Upgrades
{
    public Upgrades funnel = new();

    public void Start()
    {
        funnel.nameUpgrade = "Click Upgrade";
        funnel.cost = 1;
        funnel.costMultiplier = 1;
        funnel.upgradeLevel = 0;
    }

}

public class WaterFilterUpgrade : Upgrades
{
    public Upgrades waterFilter = new();

    public void Start()
    {
        waterFilter.nameUpgrade = "Click Upgrade";
        waterFilter.cost = 1;
        waterFilter.costMultiplier = 1;
        waterFilter.upgradeLevel = 0;
    }

}