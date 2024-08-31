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
    AudioManager audioManager;
    public AudioClip audSource1;
    public AudioClip audSource2;
    public AudioClip audSource3;

    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    protected virtual void OnTriggerEnter(Collider collider) {
        
        if (!collider.GetComponent<Damage>()) {
            return;
        }

        if (damageSources.Contains(collider.GetComponent<Damage>().source)) {
            
            // Damage Flash
            if (GetComponent<DamageFlash>()) {
                GetComponent<DamageFlash>().FlashStart(Color.red, 0.15f);
            }
            // Particle
            if (pSystem) {
                pSystem.Play();
            }

            // Audio
            if (audioManager){
                float rand = Random.Range(1.05f, 0.95f);
                if (audSource1) {
                    audioManager.PlaySFX(audSource1, 0.2f, rand);
                }
                if (audSource2) {
                    audioManager.PlaySFX(audSource2, 0.2f, rand);
                }
                if (audSource3) {
                    audioManager.PlaySFX(audSource3, 0.2f, rand);
                }
            }

            // Impact Delay
            if (enableImpactDelay) {
                if (collider.GetComponent<Damage>().type == DamageType.light){
                    StartCoroutine(DamageDelay(0.02f));
                }
                if (collider.GetComponent<Damage>().type == DamageType.heavy){
                    StartCoroutine(DamageDelay(0.1f));
                }
            }

            // Player
            if (this.GetComponent<PlayerStateManager>()){
                if (collider.GetComponent<Damage>().type == DamageType.heavy){

                    this.GetComponent<PlayerStateManager>().SetFlinchDirection(
                        collider.GetComponent<Damage>().GetFacingDirection()
                        );
                    this.GetComponent<PlayerStateManager>().Flinch();
                }
            }

            // Enemy
            if (this.GetComponent<EnemyStateManager>()){
                if (collider.GetComponent<Damage>().type == DamageType.heavy){
                    
                    this.GetComponent<EnemyStateManager>().SetFlinchDirection(
                        collider.GetComponent<Damage>().GetFacingDirection()
                        );
                    this.GetComponent<EnemyStateManager>().Flinch();
                }
            }

            // Take Damage
            if (this.GetComponent<Health>()){
                this.GetComponent<Health>().DecreaseHP(collider.GetComponent<Damage>().amount);
            }
        }
    }
    
    // Slows Timescale on Impact
    IEnumerator DamageDelay(float duration){
        Time.timeScale = 0.0f;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1;
    }
}
