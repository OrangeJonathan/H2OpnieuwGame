using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterManager : MonoBehaviour
{

    [Header("Scripts")]
    [SerializeField] ButtonManager buttonManager;
    [SerializeField] funnelManager funnelManager;
    [SerializeField] GameManager gameManager;
    [SerializeField] IncreaseMax increaseMax;
    [SerializeField] MoneyManager moneyManager;


    [Header("Water")]
    public double water = 0;
    public int maxWater = 5;
    public double autoWater = 0;


    public int DelayAmount = 1; // Second count

    protected float Timer;

    void Update()
    {
        Timer += Time.deltaTime;

       
        if (Timer >= DelayAmount)
        {
            Timer = 0f;
            water += autoWater;
            if (water > maxWater)
            {
                water = maxWater;
                printWater();
            }
            else
            {
                printWater();
            }

            

        }
    }

    public void printWater()
    {
        
        Debug.Log("amount Water: " + water + "  " + "max Water: " + maxWater);
        buttonManager.mainButtonText.text = Math.Round(water, 2).ToString() + "/" + maxWater.ToString();
    }

}
