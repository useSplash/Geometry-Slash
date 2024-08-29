using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHP; 

    public float currHP; 

    public void Start(){
        currHP = maxHP;
    }

    public void DecreaseHP(float value){
        currHP -= value;
        if (currHP < 0){
            currHP = 0;
        }
    }

    public void RestoreHP(float value){
        currHP += value;
        if (currHP > maxHP){
            currHP = maxHP;
        }
    }
}
