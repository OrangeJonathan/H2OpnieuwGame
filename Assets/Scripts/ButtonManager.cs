using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    //Link scripts
    [Header("Scripts")]
    [SerializeField] IncreaseMax increaseMax;
    [SerializeField] funnelManager funnelManager;
    [SerializeField] GameManager gameManager;
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] WaterManager waterManager;
    [SerializeField] ShopManager shopManager;

    // main button
    [Header("Main Button")]
    [SerializeField] Button mainButton;
    public Text mainButtonText;

    
    [Header("Sell Button")]
    [SerializeField] Button sellButton;
    public Text moneyText;
    public double moneyMultiplier = 0;


    [Header("Shop")]
    [SerializeField] Button enterShopButton;

    public bool shopEnabled = true;
    public Canvas shop;

    void Start()
    {
        // check main button input
        Button btnMain = mainButton.GetComponent<Button>();
        Text txtMain = mainButtonText.GetComponent<Text>();
        btnMain.onClick.AddListener(MainOnClick);

        // check sell all button input
        Button btnSellAll = sellButton.GetComponent<Button>();
        Text txtMoney = moneyText.GetComponent<Text>();
        btnSellAll.onClick.AddListener(SellAllOnClick);

        // shop
        Button btnEnterShop = enterShopButton.GetComponent<Button>();
        btnEnterShop.onClick.AddListener(enterShopOnClick);
    }

    // als main clicked
    void MainOnClick()
    {
        waterManager.clickWater();
    }

    // click increase max
    

    void SellAllOnClick()
    {
        if (waterManager.water == 0) return;

        moneyManager.money = waterManager.water * moneyMultiplier;
        Debug.Log(moneyManager.money);
        waterManager.water = 0;
        waterManager.printWater();
        moneyManager.printMoney();
        
    }


    void enterShopOnClick()
    {
        shopEnabled = true;
        shop.enabled = true;

    }

}
