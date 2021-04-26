using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    public Fade backgroundFade;
    public GameObject creditsHandle;
    public Fade credits1;
    public Fade frame1;
    public Text frame1Text;
    public Fade credits2;
    public Fade frame2;
    public Text frame2Text;
    public Fade bubble1;
    public Text bubble1Text;
    public Fade credits3;
    public Fade bubble23;
    public Text bubble2Text;
    public Text bubble3Text;
    public GameObject resetButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateWording(bool isFrench)
    {
        if (isFrench)
        {
            frame1Text.text = "Alors que vous étiez en plein jugement de valeur...";
            frame2Text.text = "Vous sentez une présence terrifiante qui approche.";
            bubble1Text.text = "Pfiou, j'aurais vraiment besoin de repos...";
            bubble2Text.text = "T'es arrivé bien bas, mon gars !";
            bubble3Text.text = "Avec tout le boulot\nque t'as abattu jusque là,\nqu'est-ce que tu dirais\nde me remplacer un moment ?";
        }
        else
        {
            frame1Text.text = "And while you were furiously\n judging people's worth...";
            frame2Text.text = "A terrifying presence\n approached.";
            bubble1Text.text = "Damn, I could\nuse a day off...";
            bubble2Text.text = "You went really deep\nto get there, brother!";
            bubble3Text.text = "With the great job\nyou've done here,\nmaybe you could take\nmy place for a while?";
        }
    }

    public void TriggerEndCredits()
    {
        backgroundFade.gameObject.SetActive(true);
        backgroundFade.FadeIn();
        StartCoroutine(EndCreditsAnimation());
    }

    public void Reset()
    {
        // Reset background color
        backgroundFade.Reset();
        creditsHandle.SetActive(false);
        credits1.Reset();
        frame1.Reset();
        credits2.Reset();
        frame2.Reset();
        bubble1.Reset();
        credits3.Reset();
        bubble23.Reset();
        resetButton.SetActive(false);
    }

    IEnumerator EndCreditsAnimation()
    {
        creditsHandle.SetActive(true);
        yield return new WaitForSeconds(2);
        credits1.FadeIn();
        frame1.FadeIn();
        yield return new WaitForSeconds(3);
        credits2.FadeIn();
        frame2.FadeIn();
        yield return new WaitForSeconds(2);
        bubble1.FadeIn();
        yield return new WaitForSeconds(2);
        credits3.FadeIn();
        yield return new WaitForSeconds(2);
        bubble23.FadeIn();
        // Show Congratulations
        // Show return button
        yield return new WaitForSeconds(2);
        resetButton.SetActive(true);
    }
}
