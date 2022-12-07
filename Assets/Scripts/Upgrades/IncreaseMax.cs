using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// add , IDataPersistence
public class IncreaseMax : Upgrades

{

    // Link script naar andere Scripts.
    [Header("Scripts")]
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] WaterManager waterManager;

    [Header("Increase Max")]
    public Button increaseMaxButton;
    public Text increaseMaxButtonText;
    public Text incMaxLevel;
    public Text incMaxCost;


    [Header("UpgradeProperties")]
    public Upgrades increaseMaxUpgrade;

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

        waterManager.maxWater = (upgradeLevel * 3) + 5;

    }

    public void Update()
    {
        if (moneyManager.money < cost)

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
        if (moneyManager.money >= cost)
        {
           
            Debug.Log("Increased Max");

            // Zet water aantal naar water - cost
            moneyManager.money = moneyManager.money - cost;
            // set text naar water/MaxWater en Money
            
            // set upgradelevel
            upgradeLevel++;
            waterManager.maxWater = (upgradeLevel * 3) + 5;
            moneyManager.printMoney();
            waterManager.printWater();

            // Maak duurder
            cost += costMultiplier;
            
            // Set level en Cost
            incMaxLevel.text = upgradeLevel.ToString();
            incMaxCost.text = Math.Round(cost, 2).ToString();
        }

        // niet genoeg water
        else
        {
            Debug.Log("niet genoeg");
        }


    }



    //public void LoadData(GameData data)
    //{
    //    upgradeLevel = data.OpslagTankLevel;
    //}

    //public void SaveData(ref GameData data)
    //{
    //    data.OpslagTankLevel = upgradeLevel;
    //}
}
