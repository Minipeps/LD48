using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public int currentHeadshape;
    public int currentBody;
    public int currentMouth;
    public int currentNose;
    public int currentEyes;
    public int currentEyebrows;
    public int currentHair;

    Sprite[] headshapes;
    Sprite[] clothes;
    Sprite[] mouths;
    Sprite[] noses;
    Sprite[] eyes;
    Sprite[] eyebrows;
    Sprite[] hairs;

    [SerializeField]
    Image headshapeImage;
    [SerializeField]
    Image bodyImage;
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
        headshapes = Resources.LoadAll<Sprite>("ProfilePictures/headshape");
        clothes = Resources.LoadAll<Sprite>("ProfilePictures/clothes");
        mouths = Resources.LoadAll<Sprite>("ProfilePictures/mouth");
        noses = Resources.LoadAll<Sprite>("ProfilePictures/nose");
        eyes = Resources.LoadAll<Sprite>("ProfilePictures/eyes");
        eyebrows = Resources.LoadAll<Sprite>("ProfilePictures/eyebrows");
        hairs = Resources.LoadAll<Sprite>("ProfilePictures/hair");

        Debug.Log("Loaded " + headshapes.Length + " headshapes");
        Debug.Log("Loaded " + clothes.Length + " clothes");
        Debug.Log("Loaded " + mouths.Length + " mouths");
        Debug.Log("Loaded " + noses.Length + " noses");
        Debug.Log("Loaded " + eyes.Length + " eyes");
        Debug.Log("Loaded " + eyebrows.Length + " eyebrows");
        Debug.Log("Loaded " + hairs.Length + " hairs");
    }

    // Update is called once per frame
    void Update()
    {
        headshapeImage.sprite = headshapes[currentHeadshape];
    }
}
