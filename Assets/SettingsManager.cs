using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public GameMaster gameMaster;
    public Text playButton;
    public Text rulesButton;
    public Text languageButton;
    public Text soundButton;
    public Text quitButton;

    public bool soundEnabled = true;
    public string language = "en";

    public bool isFrench()
    {
        return language == "fr";
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchLanguage()
    {
        language = isFrench() ? "en" : "fr";
        UpdateWording();
    }

    public void ToggleSound()
    {
        soundEnabled = !soundEnabled;
        gameMaster.ReloadSound();
        UpdateWording();
    }

    private void UpdateWording()
    {
        if (isFrench())
        {
            playButton.text = "Jouer!";
            rulesButton.text = "Règles";
            languageButton.text = "Langue: Français";
            soundButton.text = "Son: " + (soundEnabled ? "On" : "Off");
            quitButton.text = "Quitter";
            soundButton.text = "Son" + ": " + (soundEnabled ? "On" : "Off");
        }
        else
        {
            playButton.text = "Play!";
            rulesButton.text = "Rules";
            languageButton.text = "Language: English";
            soundButton.text = "Sound: " + (soundEnabled ? "On" : "Off");
            quitButton.text = "Quit";
            soundButton.text = "Sound" + ": " + (soundEnabled ? "On" : "Off");
        }
    }
}
