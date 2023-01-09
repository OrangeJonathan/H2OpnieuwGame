using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class DateManager : MonoBehaviour
{
    [SerializeField] Button nextDayBtn;
    [SerializeField] Text dateText;

    [SerializeField] RainManager rainManager;
    

    // make private ints of dates
    private int day = 1;
    private int month = 1;
    private int daysInMonth = 31;
    private bool toggleNextDay = false;


    public void Start()
    {
        Button btnNextDay = nextDayBtn.GetComponent<Button>();
        Text txtMain = nextDayBtn.GetComponent<Text>();
        nextDayBtn.onClick.AddListener(NextDayButton);
    }

    public double DelayAmount = 10;
    protected float Timer;
    private void Update()
    {
        DayTimer();
    }


    // Change the Text on the UI to the current date
    private void ChangeDateText()
    {
        string monthName;
        monthName = ConvertMonth(month);
        dateText.text = day.ToString() + " | " + monthName;
    }

    private void DayTimer()
    {
        Timer += Time.deltaTime;


        if (Timer >= DelayAmount || toggleNextDay)
        {
            Timer = 0f;
            ChangeDay();

            rainManager.FillTank();
            rainManager.UseWater();
            toggleNextDay = false;

            Debug.Log(rainManager.tankCurrentL + "/" + rainManager.tankMaxL);
        }
    }



    private void NextDayButton()
    {
        toggleNextDay = true;
    }

    // Change the day
    public void ChangeDay()
    {
        day++;
        ChangeDateText();

        if ((day == 32) && (daysInMonth == 31))
        {
            day = 1;
            ChangeDateText();
            ChangeMonth();
        }
        else if ((day == 31) && (daysInMonth == 30))
        {
            day = 1;
            ChangeDateText();
            ChangeMonth();
        }
        else if ((day == 29) && (daysInMonth == 28))
        {
            day = 1;
            ChangeDateText();
            ChangeMonth();
        }

    }

    // Change the Month
    private void ChangeMonth()
    {
        month++;
        ConvertMonth(month);
        ChangeDateText();
        if (month == 13)
        {
            ChangeDateText();
            month = 1;
        }
    }


    // Convert month to month name
    private string ConvertMonth(int month)
    {
        int monthNumber = month;
        string monthName = "January";

        switch (monthNumber)
        {
            case 1:
                monthName = "January";
                daysInMonth = 31;
                break;
            case 2:
                monthName = "February";
                daysInMonth = 28;
                break;
            case 3:
                monthName = "March";
                daysInMonth = 31;
                break;
            case 4:
                monthName = "April";
                daysInMonth = 30;
                break;
            case 5:
                monthName = "May";
                daysInMonth = 31; 
                break;
            case 6:
                monthName = "June";
                daysInMonth = 30;
                break;
            case 7:
                monthName = "July";
                daysInMonth = 31;
                break;
            case 8:
                monthName = "August";
                daysInMonth = 31;
                break;
            case 9:
                monthName = "September";
                daysInMonth = 30;
                break;
            case 10:
                monthName = "October";
                daysInMonth = 31;
                break;
            case 11:
                monthName = "November";
                daysInMonth = 30;
                break;
            case 12:
                monthName = "December";
                daysInMonth = 31;
                break;
        }

        return monthName;
    }

}
