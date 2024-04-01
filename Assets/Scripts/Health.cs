using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] bool applyCameraShake;
    SpecialEffects specialEffects;
    AudioPlayer audioPlayer;
    CameraShake cameraShake;

    void Awake(){
        specialEffects = GetComponent<SpecialEffects>();
        cameraShake = FindObjectOfType<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            if(applyCameraShake){
                cameraShake.PlayCameraShake();
                }
            specialEffects.PlayHitEffect();
            audioPlayer.PlayDamageSfx();
            damageDealer.Hit();
        }
    }

    void TakeDamage(int damage){
        health -= damage;
        
        if (health <=0){
            Destroy(gameObject);
            }
        }
}
