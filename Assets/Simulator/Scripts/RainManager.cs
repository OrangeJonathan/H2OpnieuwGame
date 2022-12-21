using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class RainManager : MonoBehaviour
{
    [SerializeField] Slider rainSlider;
    [SerializeField] Slider waterUsageSlider;
    [SerializeField] InputField rainInputField;
    [SerializeField] InputField waterUsageInputField;

    float rainAmountmm = 0;
    float waterUseAmountL = 0;
    int day = 0;
    int tankMaxL = 10000;   
    float tankCurrentL = 0;


    SliderClass rainClass;
    SliderClass WaterUsageClass;

    //public RainManager()
    //{
    //    rainClass = new SliderClass(rainSlider, rainInputField);
    //    WaterUsageClass = new SliderClass(waterUsageSlider, waterUsageInputField);
    //}


    // Start is called before the first frame update
    public void Start()
    {
        rainClass = new SliderClass(rainSlider, rainInputField);
        WaterUsageClass = new SliderClass(waterUsageSlider, waterUsageInputField);
    }


    public double DelayAmount = 10; 
    protected float Timer;
    public void Update()
    {
        Timer += Time.deltaTime;


        if (Timer >= DelayAmount)
        {
            Timer = 0f;
            day++;
            
            FillTank();
            UseWater();
            

            Debug.Log(tankCurrentL + "/" + tankMaxL);
        }
    }

    public void SyncRain()
    {
        rainClass.SyncSliderInputField();
    }

    public void SyncWaterUsage()
    {
        WaterUsageClass.SyncSliderInputField();
    }


    public void ChangeRainSlider()
    {
        rainAmountmm = rainSlider.value;
        rainInputField.text = rainSlider.value.ToString();

        Debug.Log(rainAmountmm);
    }

    public void ChangeRainInputField()
    {
        rainAmountmm = float.Parse(rainInputField.text);
        rainSlider.value = float.Parse(rainInputField.text);

        Debug.Log(rainAmountmm);
    }
    public void ChangeWaterUsage()
    {
        waterUseAmountL = waterUsageSlider.value;
        Debug.Log(waterUseAmountL);
    }

    public void FillTank()
    {
        if (tankCurrentL >= tankMaxL) return;

        tankCurrentL += rainAmountmm;

    }

    public void UseWater()
    {
        tankCurrentL -= waterUseAmountL;
    }
}
