using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrackPlayer : MonoBehaviour
{
    AudioManager audioManager;
    public AudioClip startMusic;

    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        if (audioManager){
            audioManager.PlayMusic(startMusic);
        }
    }
}
