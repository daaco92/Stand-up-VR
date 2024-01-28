using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollisionScript : MonoBehaviour
{
    public ProjectileHitScript pHitScript;
    public AudioSource tomato, piano;
    public void OnCollisionEnter(Collision collision){
        StartCoroutine(pHitScript.ScreenSplash());
        if(collision.gameObject.tag == "Piano"){
            PlayCrashSound();
        } else {
            PlaySound();
        }
    }

    void PlaySound(){
        tomato.Play();
    }
    void PlayCrashSound(){
        piano.Play();
    }
}
