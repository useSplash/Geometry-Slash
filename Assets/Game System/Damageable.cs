using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public List<DamageSource> damageSources;

    [Header("Hit Effect Settings")]
    public bool enableImpactDelay;
    public ParticleSystem pSystem;
    public AudioSource audSource1;
    float pitch1;
    public AudioSource audSource2;
    float pitch2;
    public AudioSource audSource3;
    float pitch3;

    void Start(){
        if (audSource1) {
            pitch1 = audSource1.pitch;
        }
        if (audSource2) {
            pitch2 = audSource2.pitch;
        }
        if (audSource3) {
            pitch3 = audSource3.pitch;
        }
    }

    protected virtual void OnTriggerEnter(Collider collider) {
        
        if (!collider.GetComponent<Damage>()) {
            return;
        }
        
        if (damageSources.Contains(collider.GetComponent<Damage>().source)) {
            if (GetComponent<DamageFlash>()) {
                GetComponent<DamageFlash>().FlashStart(Color.red, 0.15f);
            }
            if (pSystem) {
                pSystem.Play();
            }
            if (audSource1) {
                audSource1.pitch = Random.Range(pitch1 - 0.05f, pitch1 + 0.05f);
                audSource1.Play();
            }
            if (audSource2) {
                audSource2.pitch = Random.Range(pitch2 - 0.05f, pitch2 + 0.05f);
                audSource2.Play();
            }
            if (audSource3) {
                audSource3.pitch = Random.Range(pitch3 - 0.05f, pitch3 + 0.05f);
                audSource3.Play();
            }
            if (enableImpactDelay) {
                if (collider.GetComponent<Damage>().type == DamageType.light){
                    StartCoroutine(DamageDelay(0.02f));
                }
                if (collider.GetComponent<Damage>().type == DamageType.heavy){
                    StartCoroutine(DamageDelay(0.1f));
                }
            }

            OnDamageTrigger();
        }
    }

    public void OnDamageTrigger(){
        // To activate
    }
    
    IEnumerator DamageDelay(float duration){
        Time.timeScale = 0.0f;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1;
    }
}
