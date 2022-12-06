using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterManager : MonoBehaviour, IDataPersistence
{

    [Header("Scripts")]
    [SerializeField] ButtonManager buttonManager;
    [SerializeField] funnelManager funnelManager;
    [SerializeField] GameManager gameManager;
    [SerializeField] IncreaseMax increaseMax;
    [SerializeField] MoneyManager moneyManager;


    [Header("Water")]
    public double water = 0;
    public double waterPower = 1;
    public int maxWater = 5;
    public double autoWater = 0;
    public double autoWaterMs = 0;

    public void LoadData(GameData data)
    {
        maxWater = data.maxWater;
    }

    public void SaveData(ref GameData data)
    {
        data.maxWater = maxWater;
    }

    public double DelayAmount = 0.01; // Second count

    protected float Timer;

    void Update()
    {
        Timer += Time.deltaTime;

        


       if (autoWater == 0) return;

       if (Timer >= DelayAmount)
       {
            autoWaterMs = (autoWater / 100);
            Timer = 0f;
            water += autoWaterMs;
            if (water > maxWater)
            {
                water = maxWater;
                printWater();
            }
           printWater();
       }

    }

    public void clickWater()
    {
        // voorkomt meer water dan max
        if (water < maxWater)
        {
            
            // Check if water multiplier niet over de max gaat, gaat dat wel, maak dan het water gelijk aan max water
            if ((water + waterPower) > maxWater)
            {
                // water = maxWater
                water = maxWater;
            }
            else
            {
                water += waterPower;
            }

        }
        // print
        printWater();
    }

    public void printWater()
    {
        
        Debug.Log("amount Water: " + water + "  " + "max Water: " + maxWater);
        buttonManager.mainButtonText.text = Math.Round(water, 2).ToString() + "/" + maxWater.ToString();
    }

}
