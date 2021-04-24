using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public CharacterFactory characterFactory;

    public int currentHeadshape = 0;
    public int currentBody = 0;
    public int currentMouth = 0;
    public int currentNose = 0;
    public int currentEyes = 0;
    public int currentEyebrows = 0;
    public int currentHair = 0;

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
        headshapeImage.sprite = characterFactory.headshapes[currentHeadshape];
        clothesImage.sprite = characterFactory.clothes[currentBody];
        mouthImage.sprite = characterFactory.mouths[currentMouth];
        noseImage.sprite = characterFactory.noses[currentNose];
        eyesImage.sprite = characterFactory.eyes[currentEyes];
        eyebrowsImage.sprite = characterFactory.eyebrows[currentEyebrows];
        hairImage.sprite = characterFactory.hairs[currentHair];
    }
}
