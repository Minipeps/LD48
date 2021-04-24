using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public struct Character
{
    public string name;
    public List<Criteria> criterias;
    public bool shouldGoToHell;
};


public class CharacterFactory : MonoBehaviour
{

    public ResourceFetcher fetcher;
    private System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        var character = MakeCharacter(3);
        Debug.Log("Character loaded: " + character.name);
        foreach(Criteria criteria in character.criterias)
        {
            Debug.Log(criteria.description);
        }
        if (character.shouldGoToHell) {
            Debug.Log("He should go to Hell");
        } else
        {
            Debug.Log("He should go to Heaven");
        }
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
        return newCharacter;
    }

    private string GetRandomName()
    {
        var names = fetcher.GetNames();
        return names[random.Next(names.Count)];
    }

    private Criteria GetRandomCriteria(int value)
    {
        var criterias = fetcher.GetCriterias();
        var filteredCriterias = criterias.FindAll( criteria => criteria.value == value);
        return filteredCriterias[random.Next(filteredCriterias.Count)];
    }

    private List<int> GenerateRandomCriteriaValues(int criteriaCount)
    {
        var values = new List<int>();
        var sum = 0;
        while(sum == 0)
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
