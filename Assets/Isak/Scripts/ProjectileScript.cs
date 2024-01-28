using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.XR.CoreUtils;
using UnityEngine;
using Random = UnityEngine.Random;

public class ProjectileScript : MonoBehaviour
{
    //public GameObject[] fruits;
    public GameObject[] audience;
    public GameObject target;
    public Transform throwRelease;
    /// <summary>
    /// Time for MATH
    /// </summary>
    float projectileAngle, throwDistance, throwTime = 0;
    [SerializeField][Tooltip("How often they should throw")][Range(0f, 1f)]
    float throwDelay;
    [SerializeField][Tooltip("The increase in throwingspeed overtime")][Range(0f, 0.5f)]
    float throwDecay;
    public bool throwProjectile = true;
    [Range(100f, 5000f)]public float projectileForce;

    void Start(){
        for(int i = 0; i < audience.Length; i++){
            audience[i].transform.GetChild(3).transform.LookAt(target.transform);
        }
    }
    void Update()
    {
        throwTime += Time.deltaTime;
        if(throwTime > throwDelay && throwProjectile){
            StartCoroutine(Throw(audience[Random.Range(0, audience.Length)]));
            throwTime = 0;
        }
        if(throwDelay > 0.2f){
                throwDelay -= throwDecay * Time.deltaTime;
            }
        /*if(Input.GetMouseButtonDown(0)){
            StartCoroutine(Throw(audience[Random.Range(0, audience.Length)]));
        }*/
    }
    void ThrowOnOff(bool onOff){
        throwProjectile = onOff;
    }

    IEnumerator Throw(GameObject thrower){
        thrower.GetComponent<Animator>().Play("New State 0");
        yield return new WaitForSeconds(0.8f);
            throwRelease = thrower.transform.GetChild(3).transform;
            throwRelease.LookAt(target.transform);

            projectileAngle = Random.Range(-60f, -45f);
            throwRelease.Rotate(projectileAngle, 0.0f, 0.0f);

            GameObject projectile = ThrowablePool.SharedInstance.GetPooledObject(); 
            if (projectile != null) {
                projectile.transform.position = throwRelease.transform.position;
                projectile.transform.rotation = throwRelease.transform.rotation;
                projectile.SetActive(true);
            }
            float distanceFix = (Vector3.Distance(throwRelease.position, target.transform.position) - 10) * 50;
            projectile.GetComponent<Rigidbody>().velocity = throwRelease.forward * (-projectileAngle + projectileForce + distanceFix) * 0.006f;
            //Debug.Log(Vector3.Distance(throwRelease.position, target.transform.position));

            yield return new WaitForSeconds(4f);
            projectile.SetActive(false);
    }
}
