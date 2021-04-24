using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    [Range(Constants.scoreMin, Constants.scoreMax)]
    public int currentScore = Constants.scoreMin;

    public Image scoreBar;
    public GameObject profile;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreBar();
    }

    public void UpdateScore(int value)
    {
        currentScore = value;
        if ((currentScore) > Constants.scoreMax)
        {
            currentScore = Constants.scoreMax;
        } else if (currentScore < Constants.scoreMin)
        {
            currentScore = Constants.scoreMin;
        }
    }

    private void UpdateScoreBar()
    {
        float inset = GetComponent<RectTransform>().rect.height * (float)(currentScore) / Constants.scoreMax;
        scoreBar.rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, inset, GetComponent<RectTransform>().rect.height);
    }
}
