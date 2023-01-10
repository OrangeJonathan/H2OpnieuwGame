using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// add , IDataPersistence
public class ClickUpgrade : Upgrades
{
    [Header("Scripts")]
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] WaterManager waterManager;

    [Header("UpgradeProperties")]
    public Upgrades clickUp;

    [Header("Click Upgrade Buttons")]
    public Button clickUpButton;
    public Text clickUpLevel;
    public Text clickUpCost;


    void Start()
    {
        Upgrades upgrClickUp = clickUp.GetComponent<Upgrades>();
        Button btnClickUp = clickUpButton.GetComponent<Button>();
        Text txtClickUpLevel = clickUpLevel.GetComponent<Text>();
        Text txtClickUpCost = clickUpCost.GetComponent<Text>();
        btnClickUp.onClick.AddListener(clickUpOnClick);

        waterManager.waterPower = upgradeLevel + 1;
    }
    public void Update()
    {
        if (moneyManager.money >= cost)
        {
            clickUpButton.GetComponent<Image>().color = Color.green;
        }
        
        else
        {
            clickUpButton.GetComponent<Image>().color = Color.red;
        }
    }

    void clickUpOnClick()
    {
        if (moneyManager.money >= cost)
        {
            Debug.Log("Increased Clicks");

            moneyManager.money -= cost;

            upgradeLevel++;
            waterManager.waterPower = upgradeLevel;
            cost += costMultiplier;

            moneyManager.printMoney();
            waterManager.printWater();


            clickUpLevel.text = upgradeLevel.ToString();
            clickUpCost.text = Math.Round(cost).ToString();


        }
        else
        {
            clickUpButton.GetComponent<Image>().color = Color.red;
        }

        //if (clickUpgrade.upgradeLevel >= 3)
        //{
        //    increaseMaxButton.enabled = true;
        //    increaseMaxButton.image.enabled = true;
        //    increaseMaxButtonText.enabled = true;
        //    incMaxCost.enabled = true;
        //    incMaxLevel.enabled = true;
        //}
    }

    //public void LoadData(GameData data)
    //{
    //    upgradeLevel = data.ClickLevel; ;
    //}

    //public void SaveData(ref GameData data)
    //{
    //    data.ClickLevel = upgradeLevel;
    //}



}
