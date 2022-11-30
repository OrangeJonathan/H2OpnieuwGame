using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class funnelManager : parentClass
{

    // Link scripts
    [Header("Scripts")]
    [SerializeField] ButtonManager ButtonManager;
    [SerializeField] IncreaseMax IncreaseMax;
    [SerializeField] GameManager gameManager;
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] WaterManager waterManager;

    Upgrades upgrades = new Upgrades();


    public int level;

    public void Start()
    {
        // Set variabelen van Upgrade uit "Upgrades" Class
        upgrades.nameUpgrade = "Funnel";
        upgrades.upgradeLevel = 0;
        upgrades.cost = 1;
        upgrades.costMultiplier = 1.3;

        level = upgrades.getLevel();
    } 

    // Wanneer op knop gedrukt
    public void FunnelClicked()
    {
        if(moneyManager.money >= upgrades.cost)
        {
            moneyManager.money -= upgrades.cost;
            moneyManager.printMoney();
            level++;
            Debug.Log(level);
            waterManager.autoWater += 1;


            upgrades.cost = upgrades.cost * upgrades.costMultiplier;
        }



        //print water aantal
        moneyManager.printMoney();
    }

}

