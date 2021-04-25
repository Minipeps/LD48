using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public bool soundEnabled = true;
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

    public void ToggleLanguage()
    {
        language = isFrench() ? "en" : "fr";
    }

    public void ToggleSound()
    {
        soundEnabled = !soundEnabled;
    }
}
