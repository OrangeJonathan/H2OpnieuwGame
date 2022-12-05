using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class funnelManager : Upgrades
{

    // Link scripts
    [Header("Scripts")]
    [SerializeField] ButtonManager ButtonManager;
    [SerializeField] IncreaseMax IncreaseMax;
    [SerializeField] GameManager gameManager;
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] WaterManager waterManager;
    [SerializeField] ShopManager shopManager;
    [SerializeField] ClickUpgrade clickUpManager;
    public int level;



    // funnel button
    [Header("Funnel")]
    public Button funnelButton;
    public Text funnelButtonText;
    public Text funnelLevel;
    public Text funnelCost;


    [Header("UpgradeProperties")]
    public Upgrades upgrades;


    public void Update()
    {
        if (moneyManager.money < upgrades.cost)
        {
            funnelButton.GetComponent<Image>().color = Color.red;
        }
        else
        {
            funnelButton.GetComponent<Image>().color = Color.green;
        }
    }

    public void Start()
    {
        //shopManager.funnelButton.enabled = false;
        //shopManager.funnelButton.image.enabled = false;
        //shopManager.funnelButtonText.enabled = false;
        //shopManager.funnelCost.enabled = false;
        //shopManager.funnelLevel.enabled = false;
        //level = upgrades.upgradeLevel;
        Button btnFunnel = funnelButton.GetComponent<Button>();
        Text txtFunnel = funnelButtonText.GetComponent<Text>();
        Text txtFunnelLevel = funnelLevel.GetComponent<Text>();
        Text txtFunnelCost = funnelCost.GetComponent<Text>();
        btnFunnel.onClick.AddListener(FunnelClicked);

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
            
            // Set Level en Cost
            funnelLevel.text = upgrades.upgradeLevel.ToString();
            funnelCost.text = Math.Round(upgrades.cost, 2).ToString();


            // als wel eerste keer is
            if (upgrades.upgradeLevel >= 1)
            {
                // set button text naar dit VVVVVVV
                funnelButtonText.text = "Upgrade Funnel";
                // verander naar control = 1 voor eenmalige uitvoering van deze functie.
            }
        }



        //print water aantal
        moneyManager.printMoney();

        //if ((upgrades.upgradeLevel >= 5) && clickUpManager.upgradeLevel >= 20)
        //{
        //    shopManager.waterFilterButton.enabled = true;
        //    shopManager.waterFilterButton.image.enabled = true;
        //    shopManager.waterFilterButtonText.enabled = true;
        //    shopManager.waterFilterCost.enabled = true;
        //    shopManager.waterFilterLevel.enabled = true;
        //}
    }



}

