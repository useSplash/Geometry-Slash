using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{

    public List<MeshRenderer> meshList;
    List<Color> origColors = new List<Color>();

    // Start is called before the first frame update
    void Start(){
        for (int i = 0; i < meshList.Count; i++) {
            origColors.Add(meshList[i].material.GetColor("_EmissionColor"));
        }
    }

    public void FlashStart(Color flashColor, float flashTime){
        for (int i = 0; i < meshList.Count; i++) {
            meshList[i].material.SetColor("_EmissionColor", flashColor);
        }
        Invoke("FlashStop", flashTime);
    }

    public void FlashStop(){
        for (int i = 0; i < meshList.Count; i++) {
            meshList[i].material.SetColor("_EmissionColor", origColors[i]);
        }
    }
}
