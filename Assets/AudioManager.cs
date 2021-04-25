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

    public void PlayResultSound(bool win)
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

    public void PlayAmbiance(Level level) {
        StopAllAmbiances();
        switch (level)
        {
            case Level.Level1:
                sfxAmbDepth1.Play();
                break;
            case Level.Level2:
                sfxAmbDepth2.Play();
                break;
            case Level.Level3:
                sfxAmbDepth3.Play();
                break;
            case Level.Level4:
                // TODO
                break;
            case Level.Level5:
                // TODO
                break;
        }
    }

    private void  StopAllAmbiances()
    {
        sfxAmbDepth1.Stop();
        sfxAmbDepth2.Stop();
        sfxAmbDepth3.Stop();
    }
}
