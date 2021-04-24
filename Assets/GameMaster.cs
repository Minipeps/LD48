using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    public const int scoreMin = 0;
    public const int scoreMax = 10000;
    public const int winRate = 500;
    public const int loseRate = -700;
    public const double decreaseRate = -16.0;
    public const int limitLevel1 = 2000;
    public const int limitLevel2 = 4000;
    public const int limitLevel3 = 6000;
    public const int limitLevel4 = 8000;
}

public class GameMaster : MonoBehaviour
{
    public CharacterFactory characterFactory;
    public CharacterSelector characterSelector;
    public DescriptionFiller descriptionFiller;
    public ResourceFetcher resourceFetcher;
    public ScoringSystem scoringSystem;
    public AudioManager audioManager;

    private Level currentLevel;
    private float currentScore;
    private Character currentCharacter;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        currentLevel = Level.Level1;
        SwitchToNewCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        float scoreLost = (float)(Constants.decreaseRate * Time.deltaTime);
        UpdateScore(scoreLost);
    }

    public void UpdateCharacterDisplay()
    {
        characterSelector.UpdateCharacterTraits(currentCharacter.avatar);
        descriptionFiller.UpdateCharacterDescription(currentCharacter);
    }

    public void OnGoToHellClicked()
    {
        bool win = currentCharacter.shouldGoToHell;
        if (win)
        {
            Debug.Log("WIN: Go to Hell!");
            UpdateScore(Constants.winRate);
        }
        else
        {
            Debug.Log("FAIL: What (the hell) ?");
            UpdateScore(Constants.loseRate);
        }
        audioManager.playResultSound(win);
        SwitchToNewCharacter();
    }

    public void OnGoToHeavenClicked()
    {
        bool win = !currentCharacter.shouldGoToHell;
        if (win)
        {
            Debug.Log("WIN: I'll let you pass on this one...");
            UpdateScore(Constants.winRate);
        }
        else
        {
            Debug.Log("FAIL: Well, it seems you were naughtier than I thought!");
            UpdateScore(Constants.loseRate);
        }
        audioManager.playResultSound(win);
        SwitchToNewCharacter();
    }

    private void SwitchToNewCharacter()
    {
        currentCharacter = characterFactory.MakeCharacter(3);
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
            currentLevel = newLevel;
            // TODO: Update new background, new music etc
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
}
