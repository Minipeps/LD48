using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionFiller : MonoBehaviour
{
    public ResourceFetcher fetcher;

    [SerializeField]
    Text descriptionFieldPrefab;

    List<Text> descriptionFields = new List<Text>();
    List<Criteria> criterias = new List<Criteria>();

    private int yPos;

    // Start is called before the first frame update
    void Start()
    {
        var names = fetcher.GetNames();
        var criterias = fetcher.GetCriterias();
        yPos = -10;
        foreach (Criteria criteria in criterias)
        {
            AddDescriptionField(criteria);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void AddDescriptionField(Criteria criteria)
    {
        Text newField = Instantiate(descriptionFieldPrefab, this.transform);
        newField.text = criteria.description;
        newField.rectTransform.localPosition.Set(10, yPos, 0);
        descriptionFields.Add(newField);
    }
}
