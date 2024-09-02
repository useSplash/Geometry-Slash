using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class DirectionalLightHandler : MonoBehaviour
{
    Light dirLight;
    private float targetIntensity;
    [SerializeField] float adjustmentSpeed;

    void Start(){

        dirLight = GetComponent<Light>();
        targetIntensity = dirLight.intensity;
    }

    void Update(){

        dirLight.intensity = Mathf.Lerp(dirLight.intensity, targetIntensity, adjustmentSpeed);
    }

    public void ChangeIntensity(float val){
        
        targetIntensity = val;
    } 
}
