using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Constants
{
    public const int scoreMin = 0;
    public const int scoreMax = 10000;
    public const int winRate = 500;
    public const int loseRate = -750;
    public const int limitLevel1 = 2000;
    public const int limitLevel2 = 4000;
    public const int limitLevel3 = 6000;
    public const int limitLevel4 = 8000;
    public const int angelDevilProba = 20;
}

public enum GameState
{
    Pause,
    Play,
}

public class GameMaster : MonoBehaviour
{
    public CharacterFactory characterFactory;
    public CharacterSelector characterSelector;
    public BackgroundFiller backgroundFiller;
    public DescriptionFiller descriptionFiller;
    public TimerController timerController;
    public ResourceFetcher resourceFetcher;
    public ScoringSystem scoringSystem;
    public AudioManager audioManager;

    public GameObject buttonsHandle;

    public GameState currentGameState;

    private Level currentLevel;
    private float currentScore;
    private Character currentCharacter;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        currentLevel = Level.Level1;
        audioManager.PlayAmbiance(currentLevel, currentLevel);
        SwitchGameState(GameState.Pause);
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentGameState)
        {
            case GameState.Pause:
                break;
            case GameState.Play:
                UpdateCountdown(Time.deltaTime);
                break;
        }
    }

    public void SwitchGameState(GameState newState)
    {
        switch (newState)
        {
            case GameState.Pause:
                // Disable buttons
                SetButtonState(false);
                break;
            case GameState.Play:
                SetButtonState(true);
                SwitchToNewCharacter();
                break;
        }
        currentGameState = newState;
    }

    public void UpdateCharacterDisplay()
    {
        characterSelector.UpdateCharacterTraits(currentCharacter.avatar);
        descriptionFiller.UpdateCharacterDescription(currentCharacter);
    }

    public void OnGoToHellClicked()
    {
        SwipeCharacter(currentCharacter.shouldGoToHell);
    }

    public void OnGoToHeavenClicked()
    {
        SwipeCharacter(!currentCharacter.shouldGoToHell);
    }

    private void SwipeCharacter(bool isWin)
    {
        UpdateScore(isWin ? Constants.winRate : Constants.loseRate);
        audioManager.PlayResultSound(isWin);
        SwitchToNewCharacter();
    }

    private void SetButtonState(bool enable)
    {
        foreach (Button button in buttonsHandle.GetComponentsInChildren<Button>())
        {
            button.interactable = enable;
        }
    }

    private void SwitchToNewCharacter()
    {
        currentCharacter = characterFactory.MakeCharacter(currentLevel.Criteria(), 8.0);
        UpdateCharacterDisplay();
    }

    private void UpdateScore(float value)
    {
        currentScore += value;
        if (currentScore < Constants.scoreMin)
        {
            currentScore = Constants.scoreMin;
        }
        else if (currentScore > Constants.scoreMax)
        {
            currentScore = Constants.scoreMax;
        }
        scoringSystem.UpdateScore(currentScore);
        UpdateLevel();
    }

    private void UpdateLevel()
    {
        var newLevel = currentLevel.NewLevel(currentScore);
        if (newLevel != currentLevel)
        {
            var previousLevel = currentLevel;
            currentLevel = newLevel;
            backgroundFiller.UpdateBackground(currentLevel);
            audioManager.PlayAmbiance(previousLevel, currentLevel);
        }
    }

    private void UpdateCountdown(float time)
    {
        currentCharacter.countdown -= time;
        if (currentCharacter.countdown <= 0)
        {
            SwipeCharacter(false);
        }
    }
}

public enum Level
{
    Level1,
    Level2,
    Level3,
    Level4,
    Level5
}

static class LevelMethods
{
    public static Level NewLevel(this Level level, float score)
    {
        if (score < Constants.limitLevel1)
        {
            return Level.Level1;
        }
        else if (score < Constants.limitLevel2)
        {
            return Level.Level2;
        }
        else if (score < Constants.limitLevel3)
        {
            return Level.Level3;
        }
        else if (score < Constants.limitLevel4)
        {
            return Level.Level4;
        }
        else
        {
            return Level.Level5;
        }
    }

    public static int Criteria(this Level level)
    {
        switch (level)
        {
            case Level.Level1:
                return 2;
            case Level.Level2:
                return 3;
            case Level.Level3:
                return 3;
            case Level.Level4:
                return 4;
            case Level.Level5:
                return 5;
            default:
                return 3;
        }
    }
}
