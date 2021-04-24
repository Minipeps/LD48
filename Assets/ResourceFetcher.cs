using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public struct Criteria
{
    public string description;
    public int value;
};

public class ResourceFetcher : MonoBehaviour
{

    List<Criteria> criterias;
    List<string> names;

    // Start is called before the first frame update
    void Awake()
    {
        fetchNames();
        fetchCriteria();
    }

    public List<Criteria> GetCriterias()
    {
        return criterias;
    }

    public List<string> GetNames()
    {
        return names;
    }

    private void fetchNames()
    {
        string namesPath = "Resources/names.csv";
        using (var reader = new StreamReader(namesPath))
        {
            names = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                names.Add(values[0]);
            }
            Debug.Log("Loaded " + names.Count + " names");
        }
    }

    private void fetchCriteria()
    {
        string criteriaPath = "Resources/criteria.csv";
        using (var reader = new StreamReader(criteriaPath))
        {
            criterias = new List<Criteria>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                if (int.TryParse(values[1], out int numValue))
                {
                    Criteria newCriteria;
                    newCriteria.description = values[0];
                    newCriteria.value = numValue;
                    criterias.Add(newCriteria);
                }
            }
            Debug.Log("Loaded " + criterias.Count + " criteria");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}