using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    static int MINSCORE = 0;
    static int MAXSCORE = 100000;

    int currentScore = MAXSCORE / 2;

    public Image scoreBar;
    public GameObject profile;

    [Range(0, 100)]
    public int decreasingRate = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreBar();
    }

    public void IncreaseScore(int value)
    {
        if ((currentScore += value) > MAXSCORE)
        {
            currentScore = MAXSCORE;
        }
    }

    public void DecreaseScore(int value)
    {
        if ((currentScore -= value) < MINSCORE)
        {
            currentScore = MINSCORE;
        }
    }

    private void UpdateScoreBar()
    {
        float inset = GetComponent<RectTransform>().rect.height * (float)(currentScore) / MAXSCORE;
        scoreBar.rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, inset, 10);
    }
}
