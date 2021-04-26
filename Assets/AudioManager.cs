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
    public AudioSource sfxTransition1;
    public AudioSource sfxTransition2;
    public AudioSource sfxTransition3;
    public AudioSource sfxCongrats;
    public AudioSource sfxReprimand;

    private float timer; 
     
    private System.Random random;

    // Start is called before the first frame update
    void Start()
    {
	timer = 0;
	random = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
	UpdateCountdown(Time.deltaTime);
    }

    private void UpdateCountdown(float time)
    {
        timer -= time;
        if (timer <= 0)
        {
	    sfxCongrats.Stop();
	    sfxReprimand.Stop();
        }
    }

    public void PlayComment(bool positiv)
    {
	var randPlay = random.Next(0, Constants.commentProba);
	if(randPlay == 0 && settingsManager.soundEnabled) 
	{
	    var commentIt = random.Next(0, 8);
	    if(positiv){
	    	sfxCongrats.time = commentIt * 2;
		if(!sfxCongrats.isPlaying)
		{
	    	    sfxCongrats.Play();
		}
	    } else {
	    	sfxReprimand.time = commentIt * 2;
		if(!sfxReprimand.isPlaying)
		{
	    	    sfxReprimand.Play();
		}
	    }
	    timer = 2;
	}
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

    public void StopAllMusics()
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

    public void PlayLevelTransition(Level level)
    {
        switch (level)
        {
            case Level.Level1:
                sfxTransition1.Play();
                break;
            case Level.Level2:
                sfxTransition1.Play();
                break;
            case Level.Level3:
                sfxTransition2.Play();
                break;
            case Level.Level4:
                sfxTransition2.Play();
                break;
            case Level.Level5:
                sfxTransition3.Play();
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
}
