using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] ButtonManager buttonManager;
    [SerializeField] funnelManager funnelManager;
    [SerializeField] IncreaseMax increaseMax;

    [Header("Water")]
    public double water;
    public double autoWater;



    // print water
   public void printWater()
    {

        Debug.Log("amount Water: " + water + "  " + "max Water: " + buttonManager.maxWater);
        buttonManager.mainButtonText.text = Math.Round(water, 2).ToString() + "/" + buttonManager.maxWater.ToString();
    }
    

}
