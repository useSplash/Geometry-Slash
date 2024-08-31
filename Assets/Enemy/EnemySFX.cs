using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySFX : MonoBehaviour
{
    AudioManager audioManager;
    public AudioClip windup;
    public AudioClip release;

    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void PlayWindup(){
        if (windup) {
            audioManager.PlaySFX(windup, 0.2f, 2.5f);
        }
        else {
            Debug.Log("No Sound File");
        }
    }

    public void PlayRelease(){
        if (release) {
            audioManager.PlaySFX(release, 0.5f, 1.0f);
        }
        else {
            Debug.Log("No Sound File");
        }
    }
}