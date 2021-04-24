using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

struct Criteria
{
    public string description;
    public int value;
};

public class fetchCriteria : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string criteriaPath = "Resources/criteria.csv";
        using (var reader = new StreamReader(criteriaPath))
        {
            List<Criteria> listCriteria = new List<Criteria>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                if (int.TryParse(values[1], out int numValue))
                {
                    Criteria newCriteria;
                    newCriteria.description = values[0];
                    newCriteria.value = numValue;
                    listCriteria.Add(newCriteria);
                }
            }
            Debug.Log("Loaded " + listCriteria.Count + " criteria");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}