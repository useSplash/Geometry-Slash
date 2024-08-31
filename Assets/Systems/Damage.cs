using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum DamageSource{
    Player,
    Enemy,
    Environment
}

public enum DamageType{
    light,
    heavy
}

public class Damage : MonoBehaviour
{
    public DamageSource source;
    public DamageType type;
    public float amount;

    public Vector2 GetFacingDirection(){
        float radians = ((transform.eulerAngles.y) - 180 + 90) * Mathf.Deg2Rad;
        Vector2 facingVector = new Vector2(Mathf.Sin(radians), Mathf.Cos(radians));
        return facingVector;
    }

}
