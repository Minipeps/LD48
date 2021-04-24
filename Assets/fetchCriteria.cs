using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class fetchCriteria : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string criteriaPath = "Resources/criteria.csv";
        print("start");

        using (var reader = new StreamReader(criteriaPath))
        {
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                listA.Add(values[0]);
                listB.Add(values[1]);
            }
            listA.ForEach(print);
            listB.ForEach(print);
        }

        print("end");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
