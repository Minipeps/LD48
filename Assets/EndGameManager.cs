using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public Fade backgroundFade;
    public GameObject creditsHandle;
    public Fade credits1;
    public Fade frame1;
    public Fade credits2;
    public Fade frame2;
    public Fade bubble1;
    public Fade credits3;
    public Fade bubble23;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TriggerEndCredits()
    {
        backgroundFade.gameObject.SetActive(true);
        backgroundFade.FadeIn();
        StartCoroutine(EndCreditsAnimation());
    }

    IEnumerator EndCreditsAnimation()
    {
        creditsHandle.SetActive(true);
        yield return new WaitForSeconds(3);
        credits1.FadeIn();
        frame1.FadeIn();
        yield return new WaitForSeconds(3);
        credits2.FadeIn();
        frame2.FadeIn();
        yield return new WaitForSeconds(2);
        bubble1.FadeIn();
        yield return new WaitForSeconds(3);
        credits3.FadeIn();
        yield return new WaitForSeconds(2);
        bubble23.FadeIn();
    }
}
