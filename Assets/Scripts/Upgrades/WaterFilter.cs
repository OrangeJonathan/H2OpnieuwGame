using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterFilter : Upgrades
{

    [Header("Scripts")]
    [SerializeField] ButtonManager ButtonManager;
    [SerializeField] funnelManager funnelManager;
    [SerializeField] GameManager gameManager;
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] WaterManager waterManager;
    [SerializeField] ShopManager shopManager;
    [SerializeField] IncreaseMax increaseMax;
    [SerializeField] ClickUpgrade clickUpManager;

    [Header("Water Filter")]
    public Button waterFilterButton;
    public Text waterFilterButtonText;
    public Text waterFilterLevel;
    public Text waterFilterCost;


    [Header("UpgradeProperties")]
    public Upgrades upgrades;


    public void Start()
    {
        //shopManager.waterFilterButton.enabled = false;
        //shopManager.waterFilterButton.image.enabled = false;
        //shopManager.waterFilterButtonText.enabled = false;
        //shopManager.waterFilterCost.enabled = false;
        //shopManager.waterFilterLevel.enabled = false;

        Button btnWaterFilter = waterFilterButton.GetComponent<Button>();
        Text txtWaterFilterButton = waterFilterButtonText.GetComponent<Text>();
        Text txtWaterFilterLevel = waterFilterLevel.GetComponent<Text>();
        Text txtWaterFilterCost = waterFilterCost.GetComponent<Text>();
        btnWaterFilter.onClick.AddListener(WaterFilterClicked);
    }

    public void WaterFilterClicked()
    {
        if (moneyManager.money >= upgrades.cost)
        {

            Debug.Log("Water Filter");

            ButtonManager.moneyMultiplier *= 1.5;

            moneyManager.money = moneyManager.money - upgrades.cost;

            moneyManager.printMoney();
            upgrades.upgradeLevel++;

            // Maak duurder
            upgrades.cost *= upgrades.costMultiplier;

            waterFilterButton.GetComponent<Image>().color = Color.green;
            //Set level en Cost
            waterFilterLevel.text = upgrades.upgradeLevel.ToString();
            waterFilterCost.text = Math.Round(upgrades.cost).ToString();
        }

        // niet genoeg moneyz
        else
        {
            waterFilterButton.GetComponent<Image>().color = Color.red;
            Debug.Log("niet genoeg");
        }
        
    }


    
}
