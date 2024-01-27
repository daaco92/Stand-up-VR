using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Scripts : MonoBehaviour
{
    public GameObject[] fruits;
    public GameObject[] audience;
    public Transform throwRelease;
    [Range(100f, 5000f)]public float force;

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            StartCoroutine(Throw(audience[Random.Range(0, audience.Length)]));
        }
    }

    IEnumerator Throw(GameObject thrower){
        thrower.GetComponent<Animator>().Play("New State 0");
        throwRelease = thrower.transform.GetChild(3).transform;
            yield return new WaitForSeconds(0.8f);
            GameObject projectile = Instantiate(fruits[Random.Range(0, fruits.Length)], throwRelease.position, throwRelease.rotation);
            projectile.GetComponent<Rigidbody>().velocity = throwRelease.forward * Random.Range(force, force + 1000f) * Time.deltaTime;
        
    }
}
