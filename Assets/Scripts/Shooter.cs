using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Laser Object & Positioning")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] List<Transform> projectilePositions;

    [Header("Laser Attributes")]
    [SerializeField] float projectileSpeed = 15f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseFiringRate = 0.5f;
    
    [Header("AI")]
    [SerializeField] bool isAI;
    [SerializeField] float minFiringRate = 0.7f;
    [SerializeField] float firingRateVariance = 0.4f;
    Coroutine firingCoroutine;
    [HideInInspector] public bool isFiring;
    
    void Start()
    {
        if (isAI){
            isFiring = true;
            }
    }


    void Update()
    {
        Fire();
    }

    void Fire(){
        if (isFiring && firingCoroutine == null){
            firingCoroutine = StartCoroutine(FiringContinuously());
            }
        
        else if(!isFiring && firingCoroutine != null){
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
            }
        
    }   

    IEnumerator FiringContinuously(){
        while(true){
            
            foreach(Transform child in projectilePositions){
                GameObject instance = Instantiate(projectilePrefab,
                                            child.position, Quaternion.identity);
                
                Rigidbody2D myRigidBody = instance.GetComponent<Rigidbody2D>();
            
            if (myRigidBody != null){
                myRigidBody.velocity = child.up * projectileSpeed;
                }

            Destroy(instance, projectileLifetime);
                
                }
            
            if(isAI){
                yield return new WaitForSeconds(AiFiringRate());
                }
            
            else{
                yield return new WaitForSeconds(baseFiringRate);
                }
            
            }
   
        }

    float AiFiringRate(){
        float aiFireRate = Random.Range(baseFiringRate - firingRateVariance,
                                        baseFiringRate + firingRateVariance);
        return Mathf.Clamp(aiFireRate, minFiringRate, float.MaxValue);             
        }
}
