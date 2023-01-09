using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class SliderClass
{
    private float oldSliderValue;
    private float newSliderValue { get; set; }
    private float oldInputFieldValue;
    private float newInputFieldValue;

    private Slider slider;
    private InputField inputField;
    private float newSliderValue1;

    public SliderClass(Slider slider, InputField inputField)
    {
        this.slider = slider;
        this.inputField = inputField;
    }

    public SliderClass(Slider slider)
    {
        this.slider = slider;
    }



    public void SyncSliderInputField()
    {
        this.newSliderValue = this.slider.value;

        if (this.inputField.text == "")
        {
            this.inputField.text = "0";
        }

        if (!float.TryParse(this.inputField.text, out newInputFieldValue))
        {
            Debug.Log("problem");
            Debug.Log(newInputFieldValue);
            Debug.Log(this.inputField.text);
            return;
        }

        if (this.oldSliderValue != this.newSliderValue)
        {
            ChangeInputField(this.slider, this.inputField);
        }

        if (this.oldInputFieldValue != this.newInputFieldValue)
        {
            ChangeSlider(this.slider, this.inputField);
        }

        Debug.Log(newSliderValue);

        this.oldSliderValue = this.newSliderValue;
        this.oldInputFieldValue = this.newInputFieldValue;
    }

    private void ChangeSlider(Slider slider, InputField inputField)
    {
        slider.value = float.Parse(inputField.text);
    }

    private void ChangeInputField(Slider slider, InputField inputField)
    {
        inputField.text = slider.value.ToString();
    }

    public float GetValue()
    {
        float rainAmountmm = this.slider.value;
        return rainAmountmm;
    }

}