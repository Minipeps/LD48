using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public SettingsManager settingsManager;
    public AudioSource sfxWin;
    public AudioSource sfxLoose;
    public AudioSource sfxDevilFail;
    public AudioSource sfxAngelFail;
    public AudioSource sfxAmbDepth1;
    public AudioSource sfxAmbDepth2;
    public AudioSource sfxAmbDepth3;
    public AudioSource musicLevel1;
    public AudioSource musicLevel2;
    public AudioSource musicLevel3;
    public AudioSource musicLevel4;
    public AudioSource musicLevel5;
    public AudioSource sfxTransition;
    public AudioSource sfxCongrats;
    public AudioSource sfxReprimand;
    public AudioSource sfxFuse8;
    public AudioSource sfxFuse6;
    public AudioSource sfxFuse4;

    private float commentTimer = 0;
    private System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
	    UpdateCountdown(Time.deltaTime);
    }

    public void PlayFuse(Level level)
    {
        if (!settingsManager.soundEnabled)
        {
            return;
        }
        switch (level)
        {
            case Level.Level1:
	            sfxFuse8.Play();
		        break;
            case Level.Level2:
	            sfxFuse8.Play();
		        break;
            case Level.Level3:
	            sfxFuse6.Play();
		        break;
            case Level.Level4:
	            sfxFuse6.Play();
		        break;
            case Level.Level5:
	            sfxFuse4.Play();
		        break;
            default:
	            sfxFuse8.Play();
		        break;
        }
    }

    public void PlayComment(bool isWin)
    {
        var randPlay = random.Next(0, Constants.commentProba);
        if (!settingsManager.soundEnabled || randPlay != 0)
        {
            return;
        }
        var commentTimezone = random.Next(0, 8);
        if (isWin && !sfxCongrats.isPlaying)
        {
            sfxCongrats.time = commentTimezone * 2;
            sfxCongrats.Play();
        }
        else if (!isWin && !sfxReprimand.isPlaying)
        {
            sfxReprimand.time = commentTimezone * 2;
            sfxReprimand.Play();
        }
        commentTimer = 2;
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

    public void PlaySpecialFeatureFailSound(bool isDevil)
    {
        if (!settingsManager.soundEnabled)
        {
            return;
        }
        if (isDevil)
        {
            sfxDevilFail.Play();
        }
        else
        {
            sfxAngelFail.Play();
        }
    }

    public void PlayLevelTransition()
    {
        if (!settingsManager.soundEnabled)
        {
            return;
        }
        sfxTransition.Play();
    }

    public void PlayMusic(Level level, GameState gameState)
    {
        StopAllMusics();
        if (!settingsManager.soundEnabled || gameState == GameState.Menu)
        {
            return;
        }
        switch (level)
        {
            case Level.Level1:
                musicLevel1.Play();
                break;
            case Level.Level2:
                musicLevel2.Play();
                break;
            case Level.Level3:
                musicLevel3.Play();
                break;
            case Level.Level4:
                musicLevel4.Play();
                break;
            case Level.Level5:
                musicLevel5.Play();
                break;
        }
    }

    private void StopAllMusics()
    {
        musicLevel1.Stop();
        musicLevel2.Stop();
        musicLevel3.Stop();
        musicLevel4.Stop();
        musicLevel5.Stop();
    }

    public void PlayAmbiance(Level previousLevel, Level newLevel)
    {
        if (ShouldKeepAmbiance(previousLevel, newLevel))
        {
            return;
        }
        StopAllAmbiances();
        if (!settingsManager.soundEnabled)
        {
            return;
        }
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

    public void StopAllAmbiances()
    {
        sfxAmbDepth1.Stop();
        sfxAmbDepth2.Stop();
        sfxAmbDepth3.Stop();
    }

    public void StopAllFuses()
    {
        sfxFuse8.Stop();
        sfxFuse6.Stop();
        sfxFuse4.Stop();
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

    private void UpdateCountdown(float time)
    {
        commentTimer -= time;
        if (commentTimer <= 0)
        {
            sfxCongrats.Stop();
            sfxReprimand.Stop();
        }
    }
}
