using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float shakeIntensity = 0;
    public float shakeDuration = 0;

    private RectTransform sceneRect;

    // Start is called before the first frame update
    void Start()
    {
        sceneRect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shake()
    {
        StartCoroutine(ShakeAnimation(shakeIntensity, shakeDuration));
    }

    IEnumerator ShakeAnimation(float intensity, float duration)
    {
        float t = 0;
        while (t <= duration)
        {
            t += Time.deltaTime;
            float xOffset = intensity * Mathf.Cos(Random.Range(0, Mathf.PI));
            float yOffset = intensity * Mathf.Sin(Random.Range(-Mathf.PI / 2, Mathf.PI / 2));
            sceneRect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, xOffset, sceneRect.rect.width);
            sceneRect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, -xOffset, sceneRect.rect.width);
            sceneRect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, yOffset, sceneRect.rect.height);
            sceneRect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, -yOffset, sceneRect.rect.height);

            yield return null;
        }
        sceneRect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, sceneRect.rect.width);
        sceneRect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Right, 0, sceneRect.rect.width);
        sceneRect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, sceneRect.rect.height);
        sceneRect.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 0, sceneRect.rect.height);
        yield return null;
    }
}
