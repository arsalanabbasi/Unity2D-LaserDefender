using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score;
    [SerializeField] bool applyCameraShake;
    SpecialEffects specialEffects;
    AudioPlayer audioPlayer;
    CameraShake cameraShake;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;
    

    void Awake(){
        specialEffects = GetComponent<SpecialEffects>();
        cameraShake = FindObjectOfType<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
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
        
        if (health <=0)
        {
            Die();
        }
    }

    void Die(){
        if (!isPlayer){
            scoreKeeper.SetPlayerScore(score);
            }
        
        else{
            levelManager.LoadGameOver();
            }
        
        Destroy(gameObject);
    }

    public int GetHealth(){
        return health;
        }
    
}
