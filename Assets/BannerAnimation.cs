using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BannerAnimation : MonoBehaviour
{
    public AnimationCurve animationCurve;

    public float animationDuration = 2;

    private Text bannerText;

    private Vector3 defaultBannerPos;
    private Vector2 targetBannerPos = new Vector2(0, 400);

    // Start is called before the first frame update
    void Start()
    {
        bannerText = GetComponentInChildren<Text>();
        defaultBannerPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AnimateBanner(string levelName)
    {
        bannerText.text = levelName;
        StartCoroutine(AnimateBackAndForth(animationDuration, animationDuration));
    }

    private IEnumerator AnimateBackAndForth(float fadeDuration, float timeoutDuration)
    {
        yield return AnimationMove(targetBannerPos, fadeDuration);
        float timeout = 0;
        while (timeout <= timeoutDuration)
        {
            timeout += Time.deltaTime;
            yield return null;
        }
        yield return AnimationMove(defaultBannerPos, fadeDuration);
    }

    private IEnumerator AnimationMove(Vector3 target, float duration)
    {
        float t = 0;
        float ratio = 0;
        Vector3 origin = transform.localPosition;

        while (t <= duration)
        {
            t += Time.deltaTime;

            ratio = animationCurve.Evaluate(t / duration);

            transform.localPosition = Vector3.Slerp(origin, target, ratio);

            yield return null;
        }
        yield return null;
    }

}
