using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    [Range(Constants.scoreMin, Constants.scoreMax)]
    public float currentScore = Constants.scoreMin;

    public Image scoreBar;
    public GameObject profile;

    private float yOffsetMin = 150f;
    private float yOffsetMax = 900;

    private float cursorHeight = 100f;

    private DisplayLevelName[] displayLevels;

    // Start is called before the first frame update
    void Start()
    {
        displayLevels = GetComponentsInChildren<DisplayLevelName>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreBar();
    }

    public void UpdateScore(float value)
    {
        currentScore = value;
        if ((currentScore) > Constants.scoreMax)
        {
            currentScore = Constants.scoreMax;
        }
        else if (currentScore < Constants.scoreMin)
        {
            currentScore = Constants.scoreMin;
        }
    }

    public void UpdateLevelNames(Level maxReachedLevel)
    {
        foreach (DisplayLevelName displayLevel in displayLevels)
        {
            if (maxReachedLevel >= displayLevel.level)
                displayLevel.ShowLevelName();
        }
    }

    private void UpdateScoreBar()
    {
        float inset = yOffsetMin + (yOffsetMax - yOffsetMin) * currentScore / Constants.scoreMax;
        scoreBar.rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, inset - cursorHeight, cursorHeight);
    }
}
