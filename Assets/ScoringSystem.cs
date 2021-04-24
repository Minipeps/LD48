using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    static int MINSCORE = 0;
    static int MAXSCORE = 100000;

    int currentScore = MINSCORE;

    public Image scoreBar;
    public GameObject profile;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        IncreaseScore(10);
        UpdateScoreBar();
    }

    public void OnGoToHellClicked()
    {

    }

    public void OnGoToHeavenClicked()
    {

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
