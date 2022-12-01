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
        if(moneyManager.money >= upgrades.cost)
        {
            moneyManager.money -= upgrades.cost;
            moneyManager.printMoney();
            level++;
            upgrades.upgradeLevel++;
            Debug.Log(level);
            waterManager.autoWater += 1;


            upgrades.cost = upgrades.cost * upgrades.costMultiplier;
        }



        //print water aantal
        moneyManager.printMoney();
    }

}

