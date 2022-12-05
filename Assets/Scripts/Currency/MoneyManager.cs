using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] ButtonManager buttonManager;


    [Header("Money")]
    public double money;

   
    public void increaseMoney(double moneyAdded)
    {
        money += moneyAdded;
    }

    public void decreaseMoney(double moneyRemoved)
    {
        money -= moneyRemoved;
    }


    public void printMoney()
    {
        Debug.Log("Money: " + money);
        buttonManager.moneyText.text = "Money: " + Math.Round(money, 2);
    }





}
