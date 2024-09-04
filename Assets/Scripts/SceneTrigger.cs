using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    [SerializeField] LevelLoader loader;
    [SerializeField] int levelIndex;

    public void TriggerLoadLevel(){
        Debug.Log("Do smthn");
        loader.LoadLevel(levelIndex);
    }

}
