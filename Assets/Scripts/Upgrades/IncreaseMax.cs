using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseMax : Upgrades

{

    // Link script naar andere Scripts.
    [Header("Scripts")]
    [SerializeField] ButtonManager ButtonManager;
    [SerializeField] funnelManager funnelManager;
    [SerializeField] GameManager gameManager;
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] WaterManager waterManager;
    [SerializeField] ShopManager shopManager;
    [SerializeField] ClickUpgrade clickUpManager;

    [Header("Increase Max")]
    public Button increaseMaxButton;
    public Text increaseMaxButtonText;
    public Text incMaxLevel;
    public Text incMaxCost;


    [Header("UpgradeProperties")]
    public Upgrades upgrades;

    //Start
    void Start()
    {
        //shopManager.increaseMaxButton.enabled = false;
        //shopManager.increaseMaxButton.image.enabled = false;
        //shopManager.increaseMaxButtonText.enabled = false;
        //shopManager.incMaxCost.enabled = false;
        //shopManager.incMaxLevel.enabled = false;
        Button btnIncreaseMax = increaseMaxButton.GetComponent<Button>();
        Text txtIncreaseMaxButton = increaseMaxButtonText.GetComponent<Text>();
        Text txtIncMaxLevel = incMaxLevel.GetComponent<Text>();
        Text txtIncMax = incMaxCost.GetComponent<Text>();
        btnIncreaseMax.onClick.AddListener(increaseMaxClicked);

    }

    public void Update()
    {
        if (moneyManager.money < upgrades.cost)

        {
            increaseMaxButton.GetComponent<Image>().color = Color.red;
        }
        else
        {
            increaseMaxButton.GetComponent<Image>().color = Color.green;
        }
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
            
            // Set level en Cost
            incMaxLevel.text = upgrades.upgradeLevel.ToString();
            incMaxCost.text = Math.Round(upgrades.cost, 2).ToString();
        }

        // niet genoeg water
        else
        {
            Debug.Log("niet genoeg");
        }


    }
}
