using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class funnelManager : MonoBehaviour
{

    // Link scripts
    [Header("Scripts")]
    [SerializeField] ButtonManager ButtonManager;
    [SerializeField] IncreaseMax IncreaseMax;
    [SerializeField] GameManager gameManager;
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] WaterManager waterManager;

    Upgrades Funnel = new Upgrades();


    public int level;

    public void Start()
    {
        // Set variabelen van Upgrade uit "Upgrades" Class
        Funnel.name = "Funnel";
        Funnel.upgradeLevel = 0;
        Funnel.cost = 1;
        Funnel.costMultiplier = 1.3;

        level = Funnel.getLevel();
    }


    public void Update()
    {
        //nog niks
    }

    // Wanneer op knop gedrukt
    public void funnelClicked()
    {
        if(moneyManager.money >= Funnel.cost)
        {
            moneyManager.money -= Funnel.cost;
            moneyManager.printMoney();
            level++;
            Debug.Log(level);
            waterManager.autoWater += 1;


            Funnel.cost = Funnel.cost * Funnel.costMultiplier;
        }



        //print water aantal
        moneyManager.printMoney();
    }

}

