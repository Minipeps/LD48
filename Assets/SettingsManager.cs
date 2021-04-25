using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Text languageButton;

    public bool soundEnabled = true;
    public bool musicEnabled = true;
    public string language = "en";

    public bool isFrench()
    {
        return language == "fr";
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchLanguage()
    {
        if (isFrench())
        {
            language = "en";
            languageButton.text = "Language: English";
        }
        else
        {
            language = "fr";
            languageButton.text = "Langue: Français";
        }
    }
}
