using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public ResourceFetcher resourceFetcher;

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
    [SerializeField]
    Image hornsImage;
    [SerializeField]
    Image wingsImage;
    [SerializeField]
    Image haloImage;

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
        headshapeImage.sprite = resourceFetcher.headshapes[avatar.headshapeType];
        clothesImage.sprite = resourceFetcher.clothes[avatar.bodyType];
        mouthImage.sprite = resourceFetcher.mouths[avatar.mouthType];
        noseImage.sprite = resourceFetcher.noses[avatar.noseType];
        eyesImage.sprite = resourceFetcher.eyes[avatar.eyesType];
        if (avatar.evilEyesFeature)
        {
            eyesImage.sprite = resourceFetcher.evilEyes;
        }
        eyebrowsImage.sprite = resourceFetcher.eyebrows[avatar.eyebrowsType];
        hairImage.sprite = resourceFetcher.hairs[avatar.hairType];
        hornsImage.gameObject.SetActive(avatar.hornFeature);
        wingsImage.gameObject.SetActive(avatar.wingFeature);
        haloImage.gameObject.SetActive(avatar.haloFeature);
    }
}
