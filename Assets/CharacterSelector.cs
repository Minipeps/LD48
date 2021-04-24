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
    public void UpdateCharacterTraits(Avatar avatar)
    {
        headshapeImage.sprite = characterFactory.headshapes[avatar.headshapeType];
        clothesImage.sprite = characterFactory.clothes[avatar.bodyType];
        mouthImage.sprite = characterFactory.mouths[avatar.mouthType];
        noseImage.sprite = characterFactory.noses[avatar.noseType];
        eyesImage.sprite = characterFactory.eyes[avatar.eyesType];
        eyebrowsImage.sprite = characterFactory.eyebrows[avatar.eyebrowsType];
        hairImage.sprite = characterFactory.hairs[avatar.hairType];
    }
}
