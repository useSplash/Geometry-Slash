using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySFX : MonoBehaviour
{
    public AudioSource windup;
    public AudioSource release;

    public void PlayWindup(){
        if (windup) {
            windup.Play();
        }
        else {
            Debug.Log("No Sound File");
        }
    }

    public void PlayRelease(){
        if (release) {
            release.Play();
        }
        else {
            Debug.Log("No Sound File");
        }
    }
}