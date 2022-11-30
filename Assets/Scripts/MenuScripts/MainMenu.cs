// -Stijn

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Play game button
    [Header("Play Button")]
    public Button PlayButton;

    // Settingsbutton
    [Header("Settings Button")]
    public Button SettingsButton;

    // Quit game button
    [Header("Quit Button")]
    public Button QuitButton;

    void Start()
    {
        // Play game button input
        Button Playbtn = PlayButton.GetComponent<Button>();
        Playbtn.onClick.AddListener(LoadGame);

        // Settings button input
        Button Settingsbtn = SettingsButton.GetComponent<Button>();
        Settingsbtn.onClick.AddListener(LoadSettings);

        // Quit button input
        Button Quitbtn = QuitButton.GetComponent<Button>();
        Quitbtn.onClick.AddListener(QuitGame);

    }

    // De LoadGame functie laad het spel.
    void LoadGame()
    {
        // WIP
        SceneManager.LoadScene("SampleScene");
        Debug.Log("Loading Game");
    }

    // De LoadSettings functie laad het instellingen menu.
    void LoadSettings()
    {
        SceneManager.LoadScene("Settings Menu");
        Debug.Log("Loading Settings Menu");
    }

    // De QuitGame functie sluit het spel af.
    void QuitGame()
    {
        // WIP
        Application.Quit();
        Debug.Log("Quitting Game.");
    }

}
