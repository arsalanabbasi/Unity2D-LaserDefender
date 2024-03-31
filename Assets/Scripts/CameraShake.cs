using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1f;
    [SerializeField] float shakeMagnitude = 0.35f;
    Vector3 initialCameraPosition;


    void Start(){
        initialCameraPosition = transform.position;
    }

    public void PlayCameraShake(){
        StartCoroutine(Shake());
        }

    IEnumerator Shake(){

        float elapsedTime = 0;
        while(elapsedTime < shakeDuration){
            transform.position = initialCameraPosition +
                             (Vector3)Random.insideUnitCircle * shakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            }

        transform.position = initialCameraPosition;
        }
}
