using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class ProjectileHitScript : MonoBehaviour
{
    public GameObject screenOverlay;
    [SerializeField][Tooltip("Speed of decay on the splash effect, it goes from 1-0 so make it small plz")]
    [Range(0f, 1f)]
    float decay;

    public IEnumerator ScreenSplash(){
        for(float splashTime = 1; splashTime > 0; splashTime -= decay){
            screenOverlay.GetComponent<Renderer>().sharedMaterial.SetFloat("_Tiling_and_Alpha", splashTime);
            Debug.Log("Decaying");
            yield return null;
        }
        screenOverlay.GetComponent<Renderer>().sharedMaterial.SetFloat("_Tiling_and_Alpha", 0);
    }

    void OnDisable(){
        screenOverlay.GetComponent<Renderer>().sharedMaterial.SetFloat("_Tiling_and_Alpha", 0);
    }
}
