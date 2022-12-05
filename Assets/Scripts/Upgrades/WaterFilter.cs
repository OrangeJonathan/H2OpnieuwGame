using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterFilter : MonoBehaviour
{

    [Header("Scripts")]
    [SerializeField] ButtonManager ButtonManager;
    [SerializeField] funnelManager funnelManager;
    [SerializeField] GameManager gameManager;
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] WaterManager waterManager;
    [SerializeField] ShopManager shopManager;
    [SerializeField] IncreaseMax increaseMax;
    [SerializeField] ClickUpManager clickUpManager;


    [Header("UpgradeProperties")]
    public Upgrades upgrades;


    public void Start()
    {
        shopManager.waterFilterButton.enabled = false;
        shopManager.waterFilterButton.image.enabled = false;
        shopManager.waterFilterButtonText.enabled = false;
        shopManager.waterFilterCost.enabled = false;
        shopManager.waterFilterLevel.enabled = false;
    }

    public void WaterFilterClicked()
    {
        

        if (moneyManager.money >= upgrades.cost)
        {

            Debug.Log("Water Filter");
            // Set Max Water + 3
            moneyManager.moneyMultiplier *= 1.5;
            // Zet water aantal naar water - cost
            moneyManager.money = moneyManager.money - upgrades.cost;
            // set text naar water/MaxWater en Money
            moneyManager.printMoney();
            waterManager.printWater();
            // set upgradelevel
            upgrades.upgradeLevel++;

            // Maak duurder
            upgrades.cost *= upgrades.costMultiplier;
            
            //Set level en Cost
            shopManager.waterFilterLevel.text = upgrades.upgradeLevel.ToString();
            shopManager.waterFilterCost.text = Math.Round(upgrades.cost).ToString();
        }

        // niet genoeg moneyz
        else
        {

            Debug.Log("niet genoeg");
        }

        // Enable next upgrade, increase max
        










    }


    
}
