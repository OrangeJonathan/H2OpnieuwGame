using System.Collections;
using System.Collections.Generic;
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

    [Header("Exit Shop")]
    public Button exitShopButton;



    // increase max button
    [Header("Increase Max Button")]
    public Button increaseMaxButton;

    // funnel button
    [Header("Funnel Button")]
    public Button funnelButton;
    public Text funnelButtonText;
    bool funnelPressedFirst = false;


    void Start()
    {
        buttonManager.shop.enabled = false;

        // check exit shop
        Button btnExitShop = exitShopButton.GetComponent<Button>();
        btnExitShop.onClick.AddListener(exitShop);

        // check increase max button input
        Button btnIncreaseMax = increaseMaxButton.GetComponent<Button>();
        btnIncreaseMax.onClick.AddListener(IncreaseMaxOnClick);

        // check funnel button input
        Button btnFunnel = funnelButton.GetComponent<Button>();
        Text txtFunnel = funnelButtonText.GetComponent<Text>();
        btnFunnel.onClick.AddListener(FunnelOnClick);


    }

    void exitShop()
    {
        if (buttonManager.shopEnabled == false) return;

        buttonManager.shopEnabled = false;
        buttonManager.shop.enabled = false;

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
