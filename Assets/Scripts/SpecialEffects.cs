using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEffects : MonoBehaviour
{
    [SerializeField] ParticleSystem hitEffect;
    Transform parentPosition;

    void Awake(){
        parentPosition = GetComponent<Transform>();
        }

    public void PlayHitEffect(){
        ParticleSystem instance = Instantiate(hitEffect, parentPosition.position, Quaternion.identity);
        Destroy(instance.gameObject,
                instance.main.duration + instance.main.startLifetime.constantMax);
    }
}
