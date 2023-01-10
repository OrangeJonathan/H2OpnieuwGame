using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Upgrades : MonoBehaviour
{

    [SerializeField] string nameUpgrade;
    public double cost;
    public double costMultiplier;
    public int upgradeLevel;
    
}
