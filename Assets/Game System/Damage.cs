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
}
