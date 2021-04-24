using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public CharacterFactory characterFactory;
    public CharacterSelector characterSelector;
    public DescriptionFiller descriptionFiller;
    public ResourceFetcher resourceFetcher;
    public ScoringSystem scoringSystem;

    private int scoreDecreasingRate = 10;
    private int winningScore = 100;
    private int losingScore = -150;

    private int scoreMin = 0;
    private int scoreMax = 10000;

    private Level currentLevel;
    private int currentScore;
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
        scoringSystem.DecreaseScore(scoreDecreasingRate);
    }

    public void UpdateCharacterDisplay()
    {
        characterSelector.UpdateCharacterTraits(currentCharacter.avatar);
        descriptionFiller.UpdateCharacterDescription(currentCharacter);
    }

    public void OnGoToHellClicked()
    {
        if (currentCharacter.shouldGoToHell)
        {
            Debug.Log("WIN: Go to Hell!" );
            UpdateScore(winningScore);
        }
        else
        {
            Debug.Log("FAIL: What (the hell) ?" );
            UpdateScore(losingScore);
        }
        SwitchToNewCharacter();
    }

    public void OnGoToHeavenClicked()
    {
        if (!currentCharacter.shouldGoToHell)
        {
            Debug.Log("WIN: I'll let you pass on this one...");
            UpdateScore(winningScore);
        }
        else
        {
            Debug.Log("FAIL: Well, it seems you were naughtier than I thought!");
            UpdateScore(losingScore);
        }
        SwitchToNewCharacter();
    }

    private void SwitchToNewCharacter()
    {
        currentCharacter = characterFactory.MakeCharacter(3);
        UpdateCharacterDisplay();
    }

    private void UpdateScore(int value)
    {
        currentScore += value;
        if (currentScore < scoreMin) {
            currentScore = scoreMin;
        } else if (currentScore > scoreMax)
        {
            currentScore = scoreMax;
        }
        // TODO: Update scoringSystem
        Debug.Log("Current score : " + currentScore);
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
        Debug.Log("Current Level : " + currentLevel);
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
    public static Level NewLevel(this Level level, int score)
    {
        if (score < 2000) {
            return Level.Level1;
        } else if (score < 4000) {
            return Level.Level2;
        } else if (score < 6000) {
            return Level.Level3;
        } else if (score < 8000) {
            return Level.Level4;
        } else {
            return Level.Level5;
        }
    }
}