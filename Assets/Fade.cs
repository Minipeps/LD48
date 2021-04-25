using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public AnimationCurve animationCurve;
    public float duration;

    // Start is called before the first frame update
    void Start()
    {
        Color color = GetComponent<Image>().color;
        GetComponent<Image>().color = new Color(color.r, color.g, color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FadeIn()
    {
        StartCoroutine(FadeAnimation(1, duration));
    }

    IEnumerator FadeAnimation(float targetOpacity, float duration)
    {
        float t = 0;
        float ratio = 0;
        Color color = GetComponent<Image>().color;

        while (t <= duration)
        {
            t += Time.deltaTime;

            ratio = animationCurve.Evaluate(t / duration);

            GetComponent<Image>().color = new Color(color.r, color.g, color.b, targetOpacity * ratio + color.a * (1 - ratio));

            yield return null;
        }
        yield return null;
    }
}

