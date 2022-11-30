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

    Upgrades Funnel = new Upgrades();


    int level;

    public void Start()
    {
        // Set variabelen van Upgrade uit "Upgrades" Class
        Funnel.name = "Funnel";
        Funnel.upgradeLevel = 0;
        Funnel.cost = 1;
        Funnel.costMultiplier = 1.1;

        level = Funnel.getLevel();
    }


    public void Update()
    {
        //nog niks
    }

    // Wanneer op knop gedrukt
    public void funnelClicked()
    {

        //print water aantal
        gameManager.printWater();
    }

}
