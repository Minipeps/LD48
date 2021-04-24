using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimation : MonoBehaviour
{
    public Transform heavenButton;
    public Transform hellButton;

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

    public void OnHeavenButtonClicked()
    {
        AnimateTo(heavenButton.position);
        shouldCheckForIdle = true;
    }

    public void OnHellButtonClicked()
    {
        AnimateTo(hellButton.position);
        shouldCheckForIdle = true;
    }

    public void ResetHandPosition()
    {
        shouldCheckForIdle = false;
        AnimateTo(defaultPos);
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
