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
    [Header("Managers")]
    [SerializeField] DateManager dateManager;


    [Header("Sliders and Inputfields")]
    [SerializeField] Slider rainSlider;
    [SerializeField] Slider waterUsageSlider;
    [SerializeField] InputField rainInputField;
    [SerializeField] InputField waterUsageInputField;

    [Header("Tank")]
    [SerializeField] Slider tankSlider; // puur voor de visuals, niet waar data wordt uitgehaald
    public int tankMaxL = 10000;
    public float tankCurrentL = 0;

    [Header("Text")]
    [SerializeField] Text tankText;
    [SerializeField] Text dayText;


    [Header("rest")]
    //float rainAmountmm = 0;
    //float waterUseAmountL = 0;
    
    float waterGovernmentL = 0;

    SliderClass rainClass;
    SliderClass WaterUsageClass;

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
        
    }

    public void SyncRain()
    {
        rainClass.SyncSliderInputField();
    }

    public void SyncWaterUsage()
    {
        WaterUsageClass.SyncSliderInputField();
    }

    public void FillTank()
    {
        if (tankCurrentL >= tankMaxL) return;

        tankCurrentL += rainClass.GetValue();
        ChangeTankText();
    }

    public void UseWater()
    {
        tankCurrentL -= WaterUsageClass.GetValue();

        if (tankCurrentL < 0)
        {
            waterGovernmentL += (tankCurrentL) * -1;
            tankCurrentL = 0;
            Debug.Log("Water Government: " + waterGovernmentL);
        }

        ChangeTankText();
    }

    public void ChangeTankText()
    {
        tankText.text = tankCurrentL.ToString() + "/10000";
        tankSlider.GetComponentInChildren<Slider>().value = tankCurrentL;
    }

    


}
