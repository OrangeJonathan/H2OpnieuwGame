using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// add , IDataPersistence
public class WaterFilter : Upgrades
{

    [Header("Scripts")]
    [SerializeField] ButtonManager ButtonManager;
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] WaterManager waterManager;

    [Header("Water Filter")]
    public Button waterFilterButton;
    public Text waterFilterButtonText;
    public Text waterFilterLevel;
    public Text waterFilterCost;


    [Header("UpgradeProperties")]
    public Upgrades waterFilterUpgrade;


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

        ButtonManager.moneyMultiplier = (upgradeLevel * 0.1);
    }

    public void Update()
    {
        if (moneyManager.money < cost)
        {
            waterFilterButton.GetComponent<Image>().color = Color.red;
        }
        else
        {
            waterFilterButton.GetComponent<Image>().color = Color.green;
        }
    }

    public void WaterFilterClicked()
    {
        if (moneyManager.money >= cost)
        {

            Debug.Log("Water Filter");

            

            moneyManager.money -= cost;

            moneyManager.printMoney();
            upgradeLevel++;
            ButtonManager.moneyMultiplier = (upgradeLevel * 0.1);

            // Maak duurder
            cost *= costMultiplier;

            //Set level en Cost
            waterFilterLevel.text = upgradeLevel.ToString();
            waterFilterCost.text = Math.Round(cost).ToString();
        }

        // niet genoeg moneyz
        else
        {
            Debug.Log("niet genoeg");
        }
        
    }

    //public void LoadData(GameData data)
    //{
    //    upgradeLevel = data.WaterFilterLevel;
    //}

    //public void SaveData(ref GameData data)
    //{
    //    data.WaterFilterLevel = upgradeLevel;
    //}

}
