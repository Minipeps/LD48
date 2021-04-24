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

    private float yOffsetMin = 63.39f;
    private float yOffsetMax = 575.6f;

    private float cursorHeight = 100f;

    // Start is called before the first frame update
    void Start()
    {

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

    private void UpdateScoreBar()
    {
        float inset = yOffsetMin + (yOffsetMax - yOffsetMin) * currentScore / Constants.scoreMax;
        scoreBar.rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, inset, cursorHeight);
    }
}
