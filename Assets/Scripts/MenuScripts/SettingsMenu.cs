// -Stijn

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    // Back to Main Menu button
    [Header("Back Button")]
    public Button BackButton;

    // Start is called before the first frame update
    void Start()
    {
        // Back button input
        Button Backbtn = BackButton.GetComponent<Button>();
        Backbtn.onClick.AddListener(LoadMainMenu);

    }

    // Update is called once per frame
    void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Loading Main Menu");
    }


    // Hieronder de verschillende settings toevoegen:
}
