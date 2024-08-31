using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour

{
    public Health referenceHP;
    public Slider slider;

    // Update is called once per frame
    void Update()
    {
        slider.value = referenceHP.GetCurrHP()/
                       referenceHP.GetMaxHP();


    }
}
