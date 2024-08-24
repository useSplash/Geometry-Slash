using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public ParticleSystem pSystem;
    public AudioSource audSource1;
    public AudioSource audSource2;
    public AudioSource audSource3;

    protected virtual void OnTriggerEnter(Collider collider) {
        // Debug.Log(collider.transform.position);
        if (GetComponent<DamageFlash>()) {
            GetComponent<DamageFlash>().FlashStart(Color.red, 0.15f);
        }
        if (pSystem) {
            pSystem.Play();
        }
        if (audSource1) {
            audSource1.pitch = Random.Range(1.05f, 0.95f);
            audSource1.Play();
        }
        if (audSource2) {
            audSource2.pitch = Random.Range(1.05f, 0.95f);
            audSource2.Play();
        }
        if (audSource3) {
            audSource3.pitch = Random.Range(1.05f, 0.95f);
            audSource3.Play();
        }
    }
}
