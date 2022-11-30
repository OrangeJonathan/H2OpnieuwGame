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

    // Water Variables
    [Header("Max Water")]
    public int maxWater = 5;
    
    void Start()
    {
        // check main button input
        Button btnMain = mainButton.GetComponent<Button>();
        Text txtMain = mainButtonText.GetComponent<Text>();
        btnMain.onClick.AddListener(MainOnClick);

        // check increase max button input
        Button btnIncreaseMax = increaseMaxButton.GetComponent<Button>();
        btnIncreaseMax.onClick.AddListener(increaseMaxOnClick);

        // check funnel button input
        Button btnFunnel = funnelButton.GetComponent<Button>();
        Text txtFunnel = funnelButtonText.GetComponent<Text>();
        btnFunnel.onClick.AddListener(funnelOnClick);
    }

    // als main clicked
    void MainOnClick()
    {
        // voorkomt meer water dan max
        if (gameManager.water < maxWater)
        {
            gameManager.water++;
            // Check if +1 niet over de max gaat, gaat dat wel, maak dan het water gelijk aan max water
            if (gameManager.water > maxWater)
            {
                // water = maxWater
                gameManager.water = maxWater;
            }
            // water + 1
            
        }
        Debug.Log("+1");
        // print
        gameManager.printWater();
    }

    // click increase max
    void increaseMaxOnClick()
    {
        // activeer deze functie in ander script
        increaseMax.increaseMaxClicked();

    }


    // control int for funnelOnClick
    int control = 0;

    // click increase max
    void funnelOnClick()
    {
        // check of eerste keer geklickt op deze knop
        funnelPressedFirst = true;
        
        // als wel eerste keer is
        if (funnelPressedFirst && control == 0)
        {
            
            // set button text naar dit VVVVVVV
            funnelButtonText.text = "Upgrade Funnel";
            // verander naar control = 1 voor eenmalige uitvoering van deze functie.
            control = 1;
        }

        // activeer deze functie in ander script
        funnelManager.funnelClicked();

    }

}
