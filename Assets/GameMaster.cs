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
    public const int angelDevilProba = 15;
}

public enum GameState
{
    Menu,
    Pause,
    Play,
    Credits,
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
    public BannerAnimation levelBanner;
    public ScreenShake screenShake;
    public EndGameManager endGameManager;

    public GameObject buttonsHandle;

    public GameState currentGameState;

    public Level maxReachedLevel;

    // TMP: debug end trigger
    public bool triggerEnd = false;

    private Level currentLevel;
    private float currentScore;
    private Character currentCharacter;

    // Start is called before the first frame update
    void Start()
    {
        ResetGame();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentGameState)
        {
            case GameState.Menu:
            case GameState.Pause:
            case GameState.Credits:
                break;
            case GameState.Play:
                UpdateCountdown(Time.deltaTime);
                break;
        }

        // TMP: debug end trigger
        if (triggerEnd)
        {
            triggerEnd = false;
            SwitchGameState(GameState.Credits);
        }
    }

    public void ResetGame()
    {
        endGameManager.Reset();
        SwitchGameState(GameState.Menu);
        currentScore = 0;
        maxReachedLevel = Level.Level1;
        scoringSystem.UpdateScore(currentScore);
        currentLevel = Level.Level1;
        backgroundFiller.UpdateBackground(currentLevel);
        audioManager.PlayAmbiance(currentLevel, currentLevel);
        audioManager.PlayMusic(currentLevel, currentGameState);
    }

    public void SwitchGameState(GameState newState)
    {
        var shouldStartMusic = false;
        switch (newState)
        {
            case GameState.Menu:
            case GameState.Pause:
                // Disable buttons
                SetButtonState(false);
                break;
            case GameState.Play:
                SetButtonState(true);
                SwitchToNewCharacter();
                if (currentGameState == GameState.Menu)
                    levelBanner.AnimateBanner(currentLevel.GetLevelName());
                shouldStartMusic = currentGameState == GameState.Menu;
                break;
            case GameState.Credits:
                SetButtonState(false);
                screenShake.StrongShake();
                endGameManager.TriggerEndCredits();
                audioManager.StopAllAmbiances();
                break;
        }
        currentGameState = newState;
        if (shouldStartMusic)
        {
            audioManager.PlayMusic(currentLevel, currentGameState);
        }
    }

    public void UpdateCharacterDisplay()
    {
        characterSelector.UpdateCharacterTraits(currentCharacter.avatar);
        descriptionFiller.UpdateCharacterDescription(currentCharacter);
    }

    public void OnGoToHellClicked()
    {
        SwipeCharacter(currentCharacter, currentCharacter.shouldGoToHell);
    }

    public void OnGoToHeavenClicked()
    {
        SwipeCharacter(currentCharacter, !currentCharacter.shouldGoToHell);
    }

    public void ReloadSound()
    {
        audioManager.PlayAmbiance(currentLevel, currentLevel);
    }

    private void SwipeCharacter(Character character, bool isWin)
    {
        UpdateScore(isWin ? Constants.winRate : Constants.loseRate);
        audioManager.PlayResultSound(isWin);
        if (!isWin && (character.isDevil || character.isAngel))
        {
            audioManager.PlaySpecialFeatureFailSound(character.isDevil);
        }
        if (!isWin)
            screenShake.Shake();
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
        currentCharacter = characterFactory.MakeCharacter(currentLevel.Criteria(), currentLevel.Countdown());
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
            SwitchGameState(GameState.Credits);
        }
        scoringSystem.UpdateScore(currentScore);
        UpdateLevel();
    }

    private void UpdateLevel()
    {
        var newLevel = currentLevel.NewLevel(currentScore);
        if (newLevel != currentLevel)
        {
            if (newLevel > maxReachedLevel)
            {
                maxReachedLevel = newLevel;
                audioManager.PlayLevelTransition(newLevel);
            }
            var previousLevel = currentLevel;
            currentLevel = newLevel;
            backgroundFiller.UpdateBackground(currentLevel);
            audioManager.PlayAmbiance(previousLevel, currentLevel);
            audioManager.PlayMusic(currentLevel, currentGameState);
            levelBanner.AnimateBanner(currentLevel.GetLevelName());
        }
    }

    private void UpdateCountdown(float time)
    {
        currentCharacter.countdown -= time;
        if (currentCharacter.fullCountdown != 0)
        {
            var progress = 100 * currentCharacter.countdown / currentCharacter.fullCountdown;
            timerController.SetProgress((int)progress);
        }
        if (currentCharacter.countdown <= 0)
        {
            SwipeCharacter(currentCharacter, false);
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

    public static int Countdown(this Level level)
    {
        switch (level)
        {
            case Level.Level1:
                return 8;
            case Level.Level2:
                return 8;
            case Level.Level3:
                return 6;
            case Level.Level4:
                return 6;
            case Level.Level5:
                return 4;
            default:
                return 8;
        }
    }

    public static string GetLevelName(this Level level)
    {
        switch (level)
        {
            case Level.Level1:
                return "Limbus Office";
            case Level.Level2:
                return "Bureau of Indulgence";
            case Level.Level3:
                return "Heresy Institute";
            case Level.Level4:
                return "Violence Agency";
            case Level.Level5:
                return "Treachery Department";
            default:
                return "Test Level of Doom";
        }
    }
}
