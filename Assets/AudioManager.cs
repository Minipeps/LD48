using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public SettingsManager settingsManager;
    public AudioSource sfxWin;
    public AudioSource sfxLoose;
    public AudioSource sfxAmbDepth1;
    public AudioSource sfxAmbDepth2;
    public AudioSource sfxAmbDepth3;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playResultSound(bool win)
    {
        if (!settingsManager.soundEnabled)
        {
            return;
        }
        if (win)
        {
            sfxWin.Play();
        }
        else
        {
            sfxLoose.Play();
        }
    }

    public void playAmbience(Level level) {
    	if (level == Level.Level1) {
    	    sfxAmbDepth1.Play();
    	} else if (level == Level.Level2) {
    	    sfxAmbDepth2.Play();
	} else if (level == Level.Level3) {
    	    sfxAmbDepth3.Play();
	}
    }
}
