using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class funnelManager : MonoBehaviour
{

    // Link scripts
    [Header("Scripts")]
    [SerializeField] ButtonManager ButtonManager;
    [SerializeField] IncreaseMax IncreaseMax;
    [SerializeField] GameManager gameManager;
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] WaterManager waterManager;
    [SerializeField] ShopManager shopManager;
    public int level;


    [Header("UpgradeProperties")]
    public Upgrades upgrades;


    

    public void Start()
    {

        level = upgrades.getLevel(upgrades.upgradeLevel);
    } 

    // Wanneer op knop gedrukt
    public void FunnelClicked()
    {
        // check of genoeg geld
        if(moneyManager.money >= upgrades.cost)
        {
            // prijs van geld af halen
            moneyManager.money -= upgrades.cost;
            moneyManager.printMoney();
            // lvl up
            level++;
            upgrades.upgradeLevel++;
            Debug.Log(level);
            //set autoWater
            waterManager.autoWater += 1;

            // duurder maken
            upgrades.cost = upgrades.cost * upgrades.costMultiplier;

            // Set Level en Cost
            shopManager.funnelLevel.text = upgrades.upgradeLevel.ToString();
            shopManager.funnelCost.text = upgrades.cost.ToString();
        }



        //print water aantal
        moneyManager.printMoney();
    }

}

