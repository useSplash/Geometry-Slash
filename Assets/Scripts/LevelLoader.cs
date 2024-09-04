using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime;

    public void LoadLevel(int index){

        StartCoroutine(LevelTransition(index));
    }

    IEnumerator LevelTransition(int levelIndex){

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        
        SceneManager.LoadScene(levelIndex);
    }
}
