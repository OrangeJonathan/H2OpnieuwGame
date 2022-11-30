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

    // main button
    [Header("Main Button")]
    public Button mainButton;
    public Text mainButtonText;

    // increase max button
    [Header("Increase Max Button")]
    public Button increaseMaxButton;

    // funnel button
    [Header("Funnel Button")]
    public Button funnelButton;
    public Text funnelButtonText;
    bool funnelPressedFirst = false;

    [Header("Sell Button")]
    public Button sellButton;
    public Text moneyText;

    void Start()
    {
        // check main button input
        Button btnMain = mainButton.GetComponent<Button>();
        Text txtMain = mainButtonText.GetComponent<Text>();
        btnMain.onClick.AddListener(MainOnClick);

        // check increase max button input
        Button btnIncreaseMax = increaseMaxButton.GetComponent<Button>();
        btnIncreaseMax.onClick.AddListener(IncreaseMaxOnClick);

        // check funnel button input
        Button btnFunnel = funnelButton.GetComponent<Button>();
        Text txtFunnel = funnelButtonText.GetComponent<Text>();
        btnFunnel.onClick.AddListener(FunnelOnClick);

        // check sell all button input
        Button btnSellAll = sellButton.GetComponent<Button>();
        Text txtMoney = moneyText.GetComponent<Text>();
        btnSellAll.onClick.AddListener(SellAllOnClick);
    }

    // als main clicked
    void MainOnClick()
    {
        waterManager.clickWater();
    }

    // click increase max
    void IncreaseMaxOnClick()
    {
        // activeer deze functie in ander script
        increaseMax.increaseMaxClicked();

    }



    // click increase max
    void FunnelOnClick()
    {

        funnelManager.FunnelClicked();
        // check of eerste keer geklickt op deze knop
        funnelPressedFirst = true;
        
        // als wel eerste keer is
        if (funnelPressedFirst && funnelManager.level == 1)
        {
            
            // set button text naar dit VVVVVVV
            funnelButtonText.text = "Upgrade Funnel";
            // verander naar control = 1 voor eenmalige uitvoering van deze functie.
        }

        // activeer deze functie in ander script
        

    }

    void SellAllOnClick()
    {
        if (waterManager.water == 0) return;

        // sell water
        moneyManager.money += waterManager.water * moneyManager.moneyMultiplier;
        Debug.Log(moneyManager.money);
        waterManager.water = 0;
        waterManager.printWater();
        moneyManager.printMoney();
        
    }

}
