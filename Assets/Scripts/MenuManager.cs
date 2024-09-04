using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public CanvasGroup group;

    void Start(){
        Close();
    }

    public void Open(){
        group.alpha = 1;
        group.interactable = true;
        group.blocksRaycasts = true;
    }

    public void Close(){
        group.alpha = 0;
        group.interactable = false;
        group.blocksRaycasts = false;
    }
}
