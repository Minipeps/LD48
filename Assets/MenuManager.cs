using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    public SettingsManager settingsManager;
    public GameMaster gameMaster;
    public GameObject menuPanel;
    public GameObject pauseButton;
    public Text playButton;
    public Text rulesButton;
    public Text languageButton;
    public Text soundButton;
    public Text quitButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPlayButtonPressed()
    {
        menuPanel.SetActive(false);
        gameMaster.SwitchGameState(GameState.Play);
        pauseButton.SetActive(true);
    }

    public void OnPauseButtonPressed()
    {
        menuPanel.SetActive(true);
        gameMaster.SwitchGameState(GameState.Pause);
        pauseButton.SetActive(false);
    }

    public void OnLanguagePressed()
    {
        settingsManager.ToggleLanguage();
        UpdateWording();
    }

    public void OnSoundPressed()
    {
        settingsManager.ToggleSound();
        gameMaster.ReloadSound();
        UpdateWording();
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Purgatory...");
        if (Application.isEditor)
        {
            EditorApplication.ExitPlaymode();
        }
        else
        {
            Application.Quit();
        }
    }

    private void UpdateWording()
    {
        if (settingsManager.isFrench())
        {
            playButton.text = "Jouer!";
            rulesButton.text = "R�gles";
            languageButton.text = "Langue: Fran�ais";
            soundButton.text = "Son: " + (settingsManager.soundEnabled ? "On" : "Off");
            quitButton.text = "Quitter";
            soundButton.text = "Son" + ": " + (settingsManager.soundEnabled ? "On" : "Off");
        }
        else
        {
            playButton.text = "Play!";
            rulesButton.text = "Rules";
            languageButton.text = "Language: English";
            soundButton.text = "Sound: " + (settingsManager.soundEnabled ? "On" : "Off");
            quitButton.text = "Quit";
            soundButton.text = "Sound" + ": " + (settingsManager.soundEnabled ? "On" : "Off");
        }
    }
}
