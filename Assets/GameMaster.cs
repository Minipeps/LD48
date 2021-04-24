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

    }

    public void UpdateCharacterDisplay()
    {
        characterSelector.UpdateCharacterTraits(currentCharacter);
        descriptionFiller.UpdateCharacterDescription(currentCharacter);
    }

    public void OnGoToHellClicked()
    {
        // TODO: update score
        if (currentCharacter.shouldGoToHell)
            Debug.Log("WIN: Go to Hell!");
        else
            Debug.Log("FAIL: What (the hell) ?");
        SwitchToNewCharacter();
    }

    public void OnGoToHeavenClicked()
    {
        // TODO: update score
        if (!currentCharacter.shouldGoToHell)
            Debug.Log("WIN: I'll let you pass on this one...");
        else
            Debug.Log("FAIL: Well, it seems you were naughtier than I tought!");
        SwitchToNewCharacter();
    }

    private void SwitchToNewCharacter()
    {
        currentCharacter = characterFactory.MakeCharacter(3);
        UpdateCharacterDisplay();
    }
}
