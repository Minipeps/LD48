using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLevelName : MonoBehaviour
{
    public Level level;
    public Text levelName;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowLevelName()
    {
        levelName.text = level.GetLevelName();
    }

    public void HideLevelName()
    {
        levelName.text = "?????";
    }
}
