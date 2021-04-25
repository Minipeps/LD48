using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public struct Description
{
    public string en;
    public string fr;
}

public struct Criteria
{
    public Description description;
    public int value;
};

public struct BackgroundSprites
{
    public Sprite level1;
    public Sprite level2;
    public Sprite level3;
    public Sprite level4;
    public Sprite level5;
};

public class ResourceFetcher : MonoBehaviour
{

    List<Criteria> criterias;
    List<string> firstNames;
    List<string> lastNames;
    public Sprite[] headshapes;
    public Sprite[] clothes;
    public Sprite[] mouths;
    public Sprite[] noses;
    public Sprite[] eyes;
    public Sprite[] eyebrows;
    public Sprite[] hairs;
    public Sprite evilEyes;
    public BackgroundSprites backgroundSprites;

    // Start is called before the first frame update
    void Awake()
    {
        FetchFirstNames();
        FetchLastNames();
        FetchCriteria();
        FetchAvatars();
        FetchBackground();
    }

    public List<Criteria> GetCriterias()
    {
        return criterias;
    }

    public List<string> GetFirstNames()
    {
        return firstNames;
    }

    public List<string> GetLastNames()
    {
        return lastNames;
    }

    public BackgroundSprites GetBackgroundSprites()
    {
        return backgroundSprites;
    }

    private void FetchFirstNames()
    {
        string namesPath = "Resources/firstnames.csv";
        using (var reader = new StreamReader(namesPath))
        {
            firstNames = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                firstNames.Add(values[0]);
            }
            Debug.Log("Loaded " + firstNames.Count + " first names");
        }
    }

    private void FetchLastNames()
    {
        string namesPath = "Resources/lastnames.csv";
        using (var reader = new StreamReader(namesPath))
        {
            lastNames = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                lastNames.Add(values[0]);
            }
            Debug.Log("Loaded " + lastNames.Count + " last names");
        }
    }

    private void FetchCriteria()
    {
        string criteriaPath = "Resources/criteria.csv";
        using (var reader = new StreamReader(criteriaPath))
        {
            criterias = new List<Criteria>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                if (int.TryParse(values[0], out int numValue))
                {
                    Criteria newCriteria;
                    Description newDescription;
                    newDescription.en = values[1];
                    newDescription.fr = values[2];
                    newCriteria.description = newDescription;
                    newCriteria.value = numValue;
                    criterias.Add(newCriteria);
                }
            }
            Debug.Log("Loaded " + criterias.Count + " criteria");
        }
    }

    private void FetchAvatars()
    {
        headshapes = Resources.LoadAll<Sprite>("ProfilePictures/headshape");
        clothes = Resources.LoadAll<Sprite>("ProfilePictures/clothes");
        mouths = Resources.LoadAll<Sprite>("ProfilePictures/mouth");
        noses = Resources.LoadAll<Sprite>("ProfilePictures/nose");
        eyes = Resources.LoadAll<Sprite>("ProfilePictures/eyes");
        eyebrows = Resources.LoadAll<Sprite>("ProfilePictures/eyebrows");
        hairs = Resources.LoadAll<Sprite>("ProfilePictures/hair");
        evilEyes = Resources.Load<Sprite>("ProfilePictures/DemonFeatures/demoneyes");

        Debug.Log("Loaded " + headshapes.Length + " headshapes");
        Debug.Log("Loaded " + clothes.Length + " clothes");
        Debug.Log("Loaded " + mouths.Length + " mouths");
        Debug.Log("Loaded " + noses.Length + " noses");
        Debug.Log("Loaded " + eyes.Length + " eyes");
        Debug.Log("Loaded " + eyebrows.Length + " eyebrows");
        Debug.Log("Loaded " + hairs.Length + " hairs");
    }

    private void FetchBackground()
    {
        backgroundSprites.level1 = Resources.Load<Sprite>("Backgrounds/lv1");
        backgroundSprites.level2 = Resources.Load<Sprite>("Backgrounds/lv2");
        backgroundSprites.level3 = Resources.Load<Sprite>("Backgrounds/lv3");
        backgroundSprites.level4 = Resources.Load<Sprite>("Backgrounds/lv4");
        backgroundSprites.level5 = Resources.Load<Sprite>("Backgrounds/lv5");
        Debug.Log("Backgrounds loaded");
    }

    // Update is called once per frame
    void Update()
    {

    }
}