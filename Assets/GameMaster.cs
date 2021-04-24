using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Difficulty
{
    Hell,
    DeeperHell,
    // TODO
}

public class GameMaster : MonoBehaviour
{
    public CharacterFactory characterFactory;
    public CharacterSelector characterSelector;
    public DescriptionFiller descriptionFiller;
    public ResourceFetcher resourceFetcher;
    public ScoringSystem scoringSystem;

    [Range(0, 100)]
    public int scoreDecreasingRate = 10;
    [Range(0, 10000)]
    public int winningScore = 1000;
    [Range(0, 10000)]
    public int losingScore = 1000;

    private Difficulty currentDifficulty;
    private Character currentCharacter;

    // Start is called before the first frame update
    void Start()
    {
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
            scoringSystem.IncreaseScore(winningScore);
            Debug.Log("WIN: Go to Hell!");
        }
        else
        {
            scoringSystem.DecreaseScore(losingScore);
            Debug.Log("FAIL: What (the hell) ?");
        }
        SwitchToNewCharacter();
    }

    public void OnGoToHeavenClicked()
    {
        if (!currentCharacter.shouldGoToHell)
        {
            scoringSystem.IncreaseScore(winningScore);
            Debug.Log("WIN: I'll let you pass on this one...");
        }
        else
        {
            scoringSystem.DecreaseScore(losingScore);
            Debug.Log("FAIL: Well, it seems you were naughtier than I tought!");
        }
        SwitchToNewCharacter();
    }

    private void SwitchToNewCharacter()
    {
        currentCharacter = characterFactory.MakeCharacter(3);
        UpdateCharacterDisplay();
    }
}
