using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    [Range(0, 100)]
    public int timerProgress = 100;

    private RectTransform rope;
    private float ropeWidth = 494;

    // Start is called before the first frame update
    void Start()
    {
        rope = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        float inset = (float)(100 - timerProgress) / 100 * ropeWidth;
        rope.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, inset, ropeWidth - inset);
    }

    public void SetProgress(int progress)
    {
        timerProgress = progress;
    }
}
