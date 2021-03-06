using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionFiller : MonoBehaviour
{
    public SettingsManager settingsManager;
    public Text nameField;

    [SerializeField]
    Text descriptionFieldPrefab;

    List<Text> descriptionFields = new List<Text>();
    List<Criteria> criterias = new List<Criteria>();

    private float yPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateCharacterDescription(Character character)
    {
        // Update name
        nameField.text = character.name;

        // Update criterias
        yPos = 60;
        ClearDescriptionFields();
        foreach (Criteria criteria in character.criterias)
        {
            AddDescriptionField(criteria);
            yPos += descriptionFieldPrefab.rectTransform.rect.height;
        }
    }

    private void AddDescriptionField(Criteria criteria)
    {
        Text newField = Instantiate(descriptionFieldPrefab, this.transform);
        if (settingsManager.isFrench())
        {
            newField.text = " - " + criteria.description.fr;
        }
        else
        {
            newField.text = " - " + criteria.description.en;
        }
        newField.rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, yPos, descriptionFieldPrefab.rectTransform.rect.height);
        descriptionFields.Add(newField);
    }

    private void ClearDescriptionFields()
    {
        foreach (Text field in descriptionFields)
        {
            Destroy(field.gameObject);
        }
        descriptionFields.Clear();
    }
}
