using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    public AudioSource swordComboHit1;
    public AudioSource swordComboHit2;
    public AudioSource swordComboHit3;

    public void PlaySwordComboHit1(){
        if (swordComboHit1) {
            swordComboHit1.Play();
        }
        else {
            Debug.Log("No Sound File");
        }
    }

    public void PlaySwordComboHit2(){
        if (swordComboHit2) {
            swordComboHit2.Play();
        }
        else {
            Debug.Log("No Sound File");
        }
    }

    public void PlaySwordComboHit3(){
        if (swordComboHit3) {
            swordComboHit3.Play();
        }
        else {
            Debug.Log("No Sound File");
        }
    }
}
