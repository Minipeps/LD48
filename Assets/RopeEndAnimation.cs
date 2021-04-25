using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RopeEndAnimation : MonoBehaviour
{
    public GameObject fire;
    public float animationSpeed = 1;
    public float amplitude = 0.1f;

    private TimerController timer;
    private float animationCycle = 0;
    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<TimerController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool nearExtreme = 4 > timer.timerProgress || timer.timerProgress > 96;
        animationCycle += Time.deltaTime;
        Vector3 newScale = new Vector3(-1, 1, 1);
        newScale *= 1 + Mathf.Sin(animationSpeed * animationCycle) * amplitude;
        newScale *= nearExtreme ? 0.5f : 1;
        fire.GetComponent<RectTransform>().localScale = newScale;
        fire.GetComponent<Image>().color = Color.HSVToRGB(0, 0.25f + Mathf.Sin(animationSpeed * animationCycle) / 8, 1);
    }
}
