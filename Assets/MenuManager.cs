using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    public GameMaster gameMaster;
    public GameObject menuPanel;

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
    }

    public void OnPauseButtonPressed()
    {
        menuPanel.SetActive(true);
        gameMaster.SwitchGameState(GameState.Pause);
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
}
