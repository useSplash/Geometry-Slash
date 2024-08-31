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
            
            // Damage Flash
            if (GetComponent<DamageFlash>()) {
                GetComponent<DamageFlash>().FlashStart(Color.red, 0.15f);
            }
            // Particle
            if (pSystem) {
                pSystem.Play();
            }

            // Audio
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
