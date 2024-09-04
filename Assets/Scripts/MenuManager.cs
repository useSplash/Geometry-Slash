using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public CanvasGroup group;

    AudioManager audioManager;

    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start(){
        Close();
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (group.alpha == 1){
                Close();
                if (audioManager){
                    audioManager.PlaySFX(audioManager.unpause, 1.0f, 1.0f);
                }
            }
            else {
                Open();
                if (audioManager){
                    audioManager.PlaySFX(audioManager.pause, 1.0f, 1.0f);
                }
            }
        }
    }

    public void Open(){
        group.alpha = 1;
        group.interactable = true;
        group.blocksRaycasts = true;
        Time.timeScale = 0.0f;
    }

    public void Close(){
        group.alpha = 0;
        group.interactable = false;
        group.blocksRaycasts = false;
        Time.timeScale = 1.0f;
    }
}
