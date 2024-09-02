using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChangeTrigger : MonoBehaviour
{
    [SerializeField] DirectionalLightHandler lightHandler;
    [SerializeField] float intensity;
    protected virtual void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player"){
            lightHandler.ChangeIntensity(intensity);
        }
    }
}
