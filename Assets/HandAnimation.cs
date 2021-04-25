using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandAnimation : MonoBehaviour
{
    public AnimationCurve animationCurve;

    public float animationDuration;
    public float idleTime;

    private Vector2 defaultPos;
    private float currentIdleTime;
    private bool shouldCheckForIdle;

    // Start is called before the first frame update
    void Start()
    {
        defaultPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Reset hand to default pos if no button was clicked for some time
        if (shouldCheckForIdle)
        {
            currentIdleTime += Time.deltaTime;
            if (currentIdleTime > idleTime)
            {
                ResetHandPosition();
            }
        }
    }

    public void OnButtonClicked(string buttonName)
    {
        // Get button position
        GameObject button;
        if (button = GameObject.Find(buttonName))
        {
            AnimateTo(button.transform.position);
            shouldCheckForIdle = true;
        }
        else
        {
            Debug.LogWarning(buttonName + " not found!");
        }
    }

    public void ResetHandPosition()
    {
        AnimateTo(defaultPos);
        shouldCheckForIdle = false;
    }

    private void AnimateTo(Vector3 target)
    {
        // Reset idle time if an animation is started
        currentIdleTime = 0;
        StartCoroutine(AnimationMove(target, animationDuration));
    }

    private IEnumerator AnimationMove(Vector3 target, float duration)
    {
        float t = 0;
        float ratio = 0;
        Vector3 origin = transform.position;

        while (t <= duration)
        {
            t += Time.deltaTime;

            ratio = animationCurve.Evaluate(t / duration);

            transform.position = Vector3.Slerp(origin, target, ratio);

            yield return null;
        }
        yield return null;
    }
}
