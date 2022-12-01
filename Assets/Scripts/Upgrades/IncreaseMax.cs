using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseMax : MonoBehaviour

{

    // Link script naar andere Scripts.
    [Header("Scripts")]
    [SerializeField] ButtonManager ButtonManager;
    [SerializeField] funnelManager funnelManager;
    [SerializeField] GameManager gameManager;
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] WaterManager waterManager;

    [Header("UpgradeProperties")]
    public Upgrades upgrades;

    //Start
    void Start()
    {

        


    }

    // Methode elke keer als de knop "Increase Max" wordt geklikt.
    public void increaseMaxClicked()
    {
        // Betaal systeem, als je water hoger of gelijk is aan de prijs "cost"
        if (moneyManager.money >= upgrades.cost)
        {
           
            Debug.Log("Increased Max");
            // Set Max Water + 3
            waterManager.maxWater += 3;
            // Zet water aantal naar water - cost
            moneyManager.money = moneyManager.money - upgrades.cost;
            // set text naar water/MaxWater en Money
            moneyManager.printMoney();
            waterManager.printWater();
            // set upgradelevel
            upgrades.upgradeLevel++;

            // Maak duurder
            upgrades.cost += upgrades.costMultiplier;
        }

        // niet genoeg water
        else
        {
            Debug.Log("niet genoeg");
        }

        
    }
}
