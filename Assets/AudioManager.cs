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

    public void PlayAmbiance(Level previousLevel, Level newLevel) {
        if (ShouldKeepAmbiance(previousLevel, newLevel))
        {
            return;
        }
        StopAllAmbiances();
        switch (newLevel)
        {
            case Level.Level1:
                sfxAmbDepth1.Play();
                break;
            case Level.Level2:
                sfxAmbDepth1.Play();
                break;
            case Level.Level3:
                sfxAmbDepth2.Play();
                break;
            case Level.Level4:
                sfxAmbDepth2.Play();
                break;
            case Level.Level5:
                sfxAmbDepth3.Play();
                break;
        }
    }

    private bool ShouldKeepAmbiance(Level previousLevel, Level newLevel)
    {
        switch (previousLevel)
        {
            case Level.Level1:
                return newLevel == Level.Level2;
            case Level.Level2:
                return newLevel == Level.Level1;
            case Level.Level3:
                return newLevel == Level.Level4;
            case Level.Level4:
                return newLevel == Level.Level3;
            default:
                return false;
        }
    }

    private void  StopAllAmbiances()
    {
        sfxAmbDepth1.Stop();
        sfxAmbDepth2.Stop();
        sfxAmbDepth3.Stop();
    }
}
