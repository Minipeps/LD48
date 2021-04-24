using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public struct Character
{
    public string name;
    public List<Criteria> criterias;
    public bool shouldGoToHell;
    public int headshapeType;
    public int bodyType;
    public int mouthType;
    public int noseType;
    public int eyesType;
    public int eyebrowsType;
    public int hairType;
};


public class CharacterFactory : MonoBehaviour
{

    public ResourceFetcher fetcher;
    private System.Random random = new System.Random();

    // Character traits sprites
    public Sprite[] headshapes;
    public Sprite[] clothes;
    public Sprite[] mouths;
    public Sprite[] noses;
    public Sprite[] eyes;
    public Sprite[] eyebrows;
    public Sprite[] hairs;

    void Awake()
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

    // Start is called before the first frame update
    void Start()
    {

    }

    public Character MakeCharacter(int criteriaCount)
    {
        Character newCharacter = new Character();
        newCharacter.name = GetRandomName();
        var criterias = new List<Criteria>();
        var moralValue = 0;
        foreach (int criteriaValue in GenerateRandomCriteriaValues(criteriaCount))
        {
            var newCriteria = GetRandomCriteria(criteriaValue);
            criterias.Add(newCriteria);
            moralValue += newCriteria.value;
        }
        newCharacter.criterias = criterias;
        newCharacter.shouldGoToHell = moralValue < 0;
        GenerateRandomCharacterTraits(ref newCharacter);
        return newCharacter;
    }

    private string GetRandomName()
    {
        var names = fetcher.GetNames();
        return names[random.Next(names.Count)];
    }

    private void GenerateRandomCharacterTraits(ref Character character)
    {
        character.headshapeType = random.Next(headshapes.Length);
        character.bodyType = random.Next(clothes.Length);
        character.mouthType = random.Next(mouths.Length);
        character.noseType = random.Next(noses.Length);
        character.eyesType = random.Next(eyes.Length);
        character.eyebrowsType = random.Next(eyebrows.Length);
        character.hairType = random.Next(hairs.Length);
    }

    private Criteria GetRandomCriteria(int value)
    {
        var criterias = fetcher.GetCriterias();
        var filteredCriterias = criterias.FindAll(criteria => criteria.value == value);
        return filteredCriterias[random.Next(filteredCriterias.Count)];
    }

    private List<int> GenerateRandomCriteriaValues(int criteriaCount)
    {
        var values = new List<int>();
        var sum = 0;
        while (sum == 0)
        {
            values.Clear();
            foreach (int _ in Enumerable.Range(1, criteriaCount))
            {
                var value = random.Next(-3, 3);
                values.Add(value);
                sum += value;
            }
        }
        return values;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
