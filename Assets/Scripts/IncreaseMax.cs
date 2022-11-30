<<<<<<< HEAD
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
    [Header("Upgrade")]
    public Upgrades increaseMax = new Upgrades();

    //Start
    void Start()
    {

        // Set variabelen van Upgrade uit "Upgrades" Class
        increaseMax.name = "increaseMaxWater";
        increaseMax.upgradeLevel = 0;
        increaseMax.cost = 1;
        // de multiplier geld hier as een +
        increaseMax.costMultiplier = 1;
        
    }

    // Methode elke keer als de knop "Increase Max" wordt geklikt.
    public void increaseMaxClicked()
    {
        // Betaal systeem, als je water hoger of gelijk is aan de prijs "cost"
        if (gameManager.water >= increaseMax.cost)
        {
           
            Debug.Log("Increased Max");
            // Set Max Water + 3
            ButtonManager.maxWater += 3;
            // Zet water aantal naar water - cost
            gameManager.water = gameManager.water - increaseMax.cost;
            // set text naar water/MaxWater
            gameManager.printWater();
            // Maak duurder
            increaseMax.cost = increaseMax.cost + increaseMax.costMultiplier;
        }

        // niet genoeg water
        else
        {
            Debug.Log("niet genoeg");
        }

        
    }
}
=======
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


    [Header("Upgrade")]
    public Upgrades increaseMax = new Upgrades();

    //Start
    void Start()
    {

        // Set variabelen van Upgrade uit "Upgrades" Class
        increaseMax.name = "increaseMaxWater";
        increaseMax.upgradeLevel = 0;
        increaseMax.cost = 1;
        // multiplier word hier gebruikt als een addition
        increaseMax.costMultiplier = 2;
        
    }

    // Methode elke keer als de knop "Increase Max" wordt geklikt.
    public void increaseMaxClicked()
    {
        // Betaal systeem, als je water hoger of gelijk is aan de prijs "cost"
        if (moneyManager.money >= increaseMax.cost)
        {
           
            Debug.Log("Increased Max");
            // Set Max Water + 3
            waterManager.maxWater += 3;
            // Zet water aantal naar water - cost
            moneyManager.money = moneyManager.money - increaseMax.cost;
            // set text naar water/MaxWater en Money
            moneyManager.printMoney();
            waterManager.printWater();   
            // Maak duurder
            increaseMax.cost = increaseMax.cost + increaseMax.costMultiplier;
        }

        // niet genoeg water
        else
        {
            Debug.Log("niet genoeg");
        }

        
    }
}
>>>>>>> Jonathan
