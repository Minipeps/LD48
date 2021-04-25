using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    [Range(0, 100)]
    public int timerProgress = 100;

    private RectTransform rope;
    private float ropeWidth = 481;

    // Start is called before the first frame update
    void Start()
    {
        rope = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        float inset = (float)timerProgress / 100 * ropeWidth;
        rope.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, inset);
    }

    public void SetProgress(int progress)
    {
        timerProgress = progress;
    }
}
