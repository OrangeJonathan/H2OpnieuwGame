using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] ButtonManager buttonManager;
    [SerializeField] funnelManager funnelManager;
    [SerializeField] GameManager gameManager;
    [SerializeField] IncreaseMax increaseMax;
    [SerializeField] WaterManager waterManager;


    [Header("Money")]
    public double money;
    public double moneyMultiplier = 1;

   


    public void printMoney()
    {
        Debug.Log("Money: " + money);
        buttonManager.moneyText.text = "Money: " + Math.Round(money, 2);

    }





}
