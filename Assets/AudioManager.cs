using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    public AudioSource sfxWin;
    public AudioSource sfxLoose;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playResultSound(bool win) {
	if (win) {
		Debug.Log("PLAY WIN");
		sfxWin.Play();
	} else {
		sfxLoose.Play();
	}
    }
}
