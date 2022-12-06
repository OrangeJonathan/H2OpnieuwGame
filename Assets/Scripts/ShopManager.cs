using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    [SerializeField] IncreaseMax increaseMax;
    [SerializeField] funnelManager funnelManager;
    [SerializeField] GameManager gameManager;
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] WaterManager waterManager;
    [SerializeField] ButtonManager buttonManager;
    [SerializeField] ClickUpgrade clickUpManager;
    [SerializeField] WaterFilter waterFilter;
    [SerializeField] Upgrades clickUpgrade;

    [Header("Exit Shop")]
    public Button exitShopButton;


    void Start()
    {
        buttonManager.shop.enabled = false;

        // check exit shop
        Button btnExitShop = exitShopButton.GetComponent<Button>();
        btnExitShop.onClick.AddListener(exitShop);



    }

    public void Update()
    {
    }

    void exitShop()
    {
        if (buttonManager.shopEnabled == false) return;

        buttonManager.shopEnabled = false;
        buttonManager.shop.enabled = false;
    }


}
