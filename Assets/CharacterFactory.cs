using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public struct Character
{
    public string name;
    public List<Criteria> criterias;
    public bool shouldGoToHell;
    public Avatar avatar;
    public double fullCountdown;
    public double countdown;
};

public struct Avatar
{
    public int headshapeType;
    public int bodyType;
    public int mouthType;
    public int noseType;
    public int eyesType;
    public int eyebrowsType;
    public int hairType;
    public bool wingFeature;
    public bool haloFeature;
    public bool hornFeature;
    public bool evilEyesFeature;
};


public class CharacterFactory : MonoBehaviour
{

    public ResourceFetcher fetcher;
    private System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {

    }

    public Character MakeCharacter(int criteriaCount, double countdown)
    {
        Character newCharacter = new Character();
        newCharacter.name = GetRandomName();
        var randomAngelDevilValue = random.Next(0, Constants.angelDevilProba);
        var isAngel = randomAngelDevilValue == 0;
        var isDevil = randomAngelDevilValue == 1;
        var criterias = new List<Criteria>();
        var moralValue = 0;
        foreach (int criteriaValue in GenerateRandomCriteriaValues(criteriaCount, isAngel, isDevil))
        {
            var newCriteria = GetRandomCriteria(criteriaValue, criterias);
            criterias.Add(newCriteria);
            moralValue += newCriteria.value;
        }
        newCharacter.criterias = criterias;
        newCharacter.shouldGoToHell = moralValue < 0;
        if (isDevil)
        {
            newCharacter.shouldGoToHell = true;
        } else if (isAngel)
        {
            newCharacter.shouldGoToHell = false;
        }
        newCharacter.avatar = GenerateRandomCharacterAvatar(isAngel, isDevil);
        newCharacter.fullCountdown = countdown;
        newCharacter.countdown = countdown;
        return newCharacter;
    }

    private string GetRandomName()
    {
        var firstNames = fetcher.GetFirstNames();
        var firstName = firstNames[random.Next(firstNames.Count)];
        var lastNames = fetcher.GetLastNames();
        var lastName = lastNames[random.Next(lastNames.Count)];
        return firstName + " " + lastName;
    }

    private Avatar GenerateRandomCharacterAvatar(bool isAngel, bool isDevil)
    {
        var avatar = new Avatar();
        var mainAngelDevilFeature = random.Next(2) == 0;
        avatar.headshapeType = random.Next(fetcher.headshapes.Length);
        avatar.bodyType = random.Next(fetcher.clothes.Length);
        avatar.mouthType = random.Next(fetcher.mouths.Length);
        avatar.noseType = random.Next(fetcher.noses.Length);
        avatar.eyesType = random.Next(fetcher.eyes.Length);
        avatar.eyebrowsType = random.Next(fetcher.eyebrows.Length);
        avatar.hairType = random.Next(fetcher.hairs.Length);
        avatar.wingFeature = isAngel && mainAngelDevilFeature;
        avatar.haloFeature = isAngel && !mainAngelDevilFeature;
        avatar.hornFeature = isDevil && mainAngelDevilFeature;
        avatar.evilEyesFeature = isDevil && !mainAngelDevilFeature;
        return avatar;
    }

    private Criteria GetRandomCriteria(int value, List<Criteria> alreadyPickedCriterias)
    {
        var criterias = fetcher.GetCriterias();
        var filteredCriterias = criterias.FindAll(criteria => criteria.value == value);
        Criteria criteriaCandidate;
        while (alreadyPickedCriterias.Contains(criteriaCandidate = filteredCriterias[random.Next(filteredCriterias.Count)]))
        { /* Do nothing */ }
        return criteriaCandidate;
    }

    private List<int> GenerateRandomCriteriaValues(int criteriaCount, bool isAngel, bool isDevil)
    {
        var values = new List<int>();
        var sum = 0;
        var respectAngel = false;
        var respectDevil = false;
        while (sum == 0 || !respectAngel || !respectDevil)
        {

            values.Clear();
            foreach (int _ in Enumerable.Range(1, criteriaCount))
            {
                var value = random.Next(-1, 2);
                values.Add(value);
                sum += value;
            }
            respectAngel = !isAngel || sum < 0;
            respectDevil = !isDevil || sum > 0;
        }
        return values;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
