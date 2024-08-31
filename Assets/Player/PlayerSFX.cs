using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void PlaySwordComboHit1(){
        if (audioManager) {
            audioManager.PlaySFX(audioManager.lightHit1SFX, 0.2f, 2.5f);
        }
        else {
            Debug.Log("No Sound File");
        }
    }

    public void PlaySwordComboHit2(){
        if (audioManager) {
            audioManager.PlaySFX(audioManager.lightHit2SFX, 0.2f, 1.0f);
        }
        else {
            Debug.Log("No Sound File");
        }
    }

    public void PlaySwordComboHit3(){
        if (audioManager) {
            audioManager.PlaySFX(audioManager.heavyHit1SFX, 0.35f, 2.5f);
        }
        else {
            Debug.Log("No Sound File");
        }
    }
}
