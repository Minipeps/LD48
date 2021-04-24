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
        SwitchToNewCharacter();
    }

    public void OnGoToHeavenClicked()
    {
        // TODO: update score
        SwitchToNewCharacter();
    }

    private void SwitchToNewCharacter()
    {
        currentCharacter = characterFactory.MakeCharacter(3);
        UpdateCharacterDisplay();
    }
}
