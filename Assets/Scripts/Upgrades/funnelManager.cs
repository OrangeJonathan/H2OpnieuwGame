using System;
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
    [SerializeField] ClickUpManager clickUpManager;
    public int level;


    [Header("UpgradeProperties")]
    public Upgrades upgrades;


    

    public void Start()
    {
        shopManager.funnelButton.enabled = false;
        shopManager.funnelButton.image.enabled = false;
        shopManager.funnelButtonText.enabled = false;
        shopManager.funnelCost.enabled = false;
        shopManager.funnelLevel.enabled = false;
        level = upgrades.upgradeLevel;
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
            shopManager.funnelCost.text = Math.Round(upgrades.cost, 2).ToString();
        }



        //print water aantal
        moneyManager.printMoney();

        if ((upgrades.upgradeLevel >= 5) && clickUpManager.upgrades.upgradeLevel >= 20)
        {
            shopManager.waterFilterButton.enabled = true;
            shopManager.waterFilterButton.image.enabled = true;
            shopManager.waterFilterButtonText.enabled = true;
            shopManager.waterFilterCost.enabled = true;
            shopManager.waterFilterLevel.enabled = true;
        }
    }



}

