using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public CharacterFactory characterFactory;

    [SerializeField]
    Image headshapeImage;
    [SerializeField]
    Image clothesImage;
    [SerializeField]
    Image mouthImage;
    [SerializeField]
    Image noseImage;
    [SerializeField]
    Image eyesImage;
    [SerializeField]
    Image eyebrowsImage;
    [SerializeField]
    Image hairImage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Update is called once per frame
    public void UpdateCharacterTraits(Character character)
    {
        headshapeImage.sprite = characterFactory.headshapes[character.headshapeType];
        clothesImage.sprite = characterFactory.clothes[character.bodyType];
        mouthImage.sprite = characterFactory.mouths[character.mouthType];
        noseImage.sprite = characterFactory.noses[character.noseType];
        eyesImage.sprite = characterFactory.eyes[character.eyesType];
        eyebrowsImage.sprite = characterFactory.eyebrows[character.eyebrowsType];
        hairImage.sprite = characterFactory.hairs[character.hairType];
    }
}
