using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scripts : MonoBehaviour
{
    public GameObject[] fruits;
    public Transform throwRelease;
    [Range(100f, 1000f)]public float force;

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Random.seed = System.DateTime.Now.Millisecond;
            GameObject projectile = Instantiate(fruits[Random.Range(0, fruits.Length)], throwRelease.position, throwRelease.rotation);
            projectile.GetComponent<Rigidbody>().velocity = throwRelease.forward * force * Time.deltaTime;
        }
    }
}
