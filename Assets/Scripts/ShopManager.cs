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
    [SerializeField] ClickUpManager clickUpManager;

    [Header("Exit Shop")]
    public Button exitShopButton;

    [Header("Click Upgrade")]
    public Button clickUpButton;
    public Text clickUpLevel;
    public Text clickUpCost;

    // increase max button
    [Header("Increase Max")]
    public Button increaseMaxButton;
    public Text incMaxLevel;
    public Text incMaxCost;

    // funnel button
    [Header("Funnel")]
    public Button funnelButton;
    public Text funnelButtonText;
    public Text funnelLevel;
    public Text funnelCost;
    bool funnelPressedFirst = false;



    void Start()
    {
        buttonManager.shop.enabled = false;

        // check exit shop
        Button btnExitShop = exitShopButton.GetComponent<Button>();
        btnExitShop.onClick.AddListener(exitShop);

        // check Click Upgrade button input
        Button btnClickUp = clickUpButton.GetComponent<Button>();
        Text txtClickUpLevel = clickUpLevel.GetComponent<Text>();
        btnClickUp.onClick.AddListener(clickUpOnClick);


        // check increase max button input
        Button btnIncreaseMax = increaseMaxButton.GetComponent<Button>();
        Text txtIncMaxLevel = incMaxLevel.GetComponent<Text>();
        btnIncreaseMax.onClick.AddListener(IncreaseMaxOnClick);

        // check funnel button input
        Button btnFunnel = funnelButton.GetComponent<Button>();
        Text txtFunnel = funnelButtonText.GetComponent<Text>();
        Text txtFunnelLevel = funnelLevel.GetComponent<Text>();
        btnFunnel.onClick.AddListener(FunnelOnClick);


    }

    public void Update()
    {
        AffordableColor();
    }

    void exitShop()
    {
        if (buttonManager.shopEnabled == false) return;

        buttonManager.shopEnabled = false;
        buttonManager.shop.enabled = false;



    }

    public void AffordableColor()
    {
        // check if clickup can afford
        if (moneyManager.money < clickUpManager.upgrades.cost)
        {
            clickUpButton.GetComponent<Image>().color = Color.red;
        }
        else
        {
            clickUpButton.GetComponent<Image>().color = Color.green;
        }

        

        // check if Increase Max can afford
        if (moneyManager.money < increaseMax.upgrades.cost) 

        {
            increaseMaxButton.GetComponent<Image>().color = Color.red;
        }
        else
        {
            increaseMaxButton.GetComponent<Image>().color = Color.green;
        }


        // check if Funnel can afford
        if (moneyManager.money < funnelManager.upgrades.cost)

        {
            funnelButton.GetComponent<Image>().color = Color.red;
        }
        else
        {
            funnelButton.GetComponent<Image>().color = Color.green;
        }





    }




    void clickUpOnClick()
    {
        clickUpManager.clickUpClicked();

    }




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


}
