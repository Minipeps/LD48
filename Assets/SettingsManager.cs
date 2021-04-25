using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Text playButton;
    public Text rulesButton;
    public Text languageButton;
    public Text soundButton;
    public Text quitButton;

    public bool soundEnabled = true;
    public bool musicEnabled = true;
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
        UpdateButtonsText();
    }

    public void ToggleSound()
    {
        soundEnabled = !soundEnabled;
        musicEnabled = !musicEnabled;

        soundButton.text = (isFrench() ? "Son" : "Sound") + ": " + (soundEnabled ? "On" : "Off");
    }

    private void UpdateButtonsText()
    {
        if (isFrench())
        {
            playButton.text = "Jouer!";
            rulesButton.text = "Règles";
            languageButton.text = "Langue: Français";
            soundButton.text = "Son: " + (soundEnabled ? "On" : "Off");
            quitButton.text = "Quitter";
        }
        else
        {
            playButton.text = "Play!";
            rulesButton.text = "Rules";
            languageButton.text = "Language: English";
            soundButton.text = "Sound: " + (soundEnabled ? "On" : "Off");
            quitButton.text = "Quit";
        }
    }
}
