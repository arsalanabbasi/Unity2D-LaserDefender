using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting SFX")]
    [SerializeField] AudioClip playerShootingSfx;
    [SerializeField] [Range(0f, 1f)] float playerShootingVolume = 0.069f;
    [SerializeField] AudioClip aiShootingSfx;
    [SerializeField] [Range(0f, 1f)] float aiShootingVolume = 0.079f;

    [Header("Damage SFX")]
    [SerializeField] AudioClip damageSfx;
    [SerializeField] [Range(0f, 1f)] float damageVolume = 0.149f;

    public void PlayPlayerShootingSfx(){
        PlaySFX(playerShootingSfx, playerShootingVolume);
        }

    public void PlayAiShootingSfx(){
        PlaySFX(aiShootingSfx, aiShootingVolume);
        }

    public void PlayDamageSfx(){
        PlaySFX(damageSfx, damageVolume);
        }

    void PlaySFX(AudioClip clip, float volume){
        if(clip != null){
            Vector3 cameraPosition = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPosition, volume);
            }
        }
}
