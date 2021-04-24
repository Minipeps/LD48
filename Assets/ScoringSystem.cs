using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    static int MINSCORE = 0;
    static int MAXSCORE = 10000;

    int currentScore = 0;

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
        if ((currentScore) > MAXSCORE)
        {
            currentScore = MAXSCORE;
        } else if (currentScore < MINSCORE)
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
