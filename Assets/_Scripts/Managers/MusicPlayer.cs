using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {


    public AudioClip[] songs;

    private static MusicPlayer _instance;
    private AudioSource music;
	void Start () {
	    if (_instance != null && _instance != this) {
	        Destroy (gameObject);
	    } else {
	        _instance = this;
	        DontDestroyOnLoad(gameObject);

	        music = GetComponent<AudioSource>();
	        music.clip = songs[0];
	        music.loop = false;
            music.Play();
	    }
	}

    protected void OnLevelWasLoaded(int level) {
        var clipName = music.clip.name;

        switch (level)
        {
            case 0:
                music.clip = songs[0];
                music.loop = false;
                break;
            case 1:
                music.clip = songs[1];
                music.loop = true;
                break;
            case 2:
                music.clip = songs[2];
                music.loop = true;
                break;
        }

        var newName = music.clip.name;
        if (clipName != newName)
            music.Play();
    }
}
