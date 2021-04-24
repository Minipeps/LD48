using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionFiller : MonoBehaviour
{
    public ResourceFetcher fetcher;

    public Text nameField;

    [SerializeField]
    Text descriptionFieldPrefab;

    List<Text> descriptionFields = new List<Text>();
    List<Criteria> criterias = new List<Criteria>();

    private float yPos;

    // Start is called before the first frame update
    void Start()
    {
        nameField.text = fetcher.GetNames()[0];
        var criterias = fetcher.GetCriterias();
        yPos = 40;
        foreach (Criteria criteria in criterias)
        {
            AddDescriptionField(criteria);
            yPos += descriptionFieldPrefab.rectTransform.rect.height;
            if (yPos > 100)
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void AddDescriptionField(Criteria criteria)
    {
        Text newField = Instantiate(descriptionFieldPrefab, this.transform);
        newField.text = " - " + criteria.description;
        newField.rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, yPos, descriptionFieldPrefab.rectTransform.rect.height);
        descriptionFields.Add(newField);
    }
}
