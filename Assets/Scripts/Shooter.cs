using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Laser Object & Positioning")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform projectilePosition1;
    [SerializeField] Transform projectilePosition2;

    [Header("Laser Attributes")]
    [SerializeField] float projectileSpeed = 15f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseFiringRate = 0.5f;
    
    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float minFiringRate = 0.7f;
    [SerializeField] float firingRateVariance = 0.4f;
    Coroutine firingCoroutine;
    [HideInInspector] public bool isFiring;
    
    void Start()
    {
        if (useAI){
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
            GameObject instance1 = Instantiate(projectilePrefab,
                                            projectilePosition1.position, Quaternion.identity);
            
            
            Rigidbody2D myRigidBody1 = instance1.GetComponent<Rigidbody2D>();
            
            if (myRigidBody1 != null){
                myRigidBody1.velocity = projectilePosition1.up * projectileSpeed;
                }

            Destroy(instance1, projectileLifetime);
            
            if (!useAI){
                GameObject instance2 = Instantiate(projectilePrefab,
                                            projectilePosition2.position, Quaternion.identity);

                Rigidbody2D myRigidBody2 = instance2.GetComponent<Rigidbody2D>();
                if (myRigidBody2 != null){
                    myRigidBody2.velocity = projectilePosition2.up * projectileSpeed;
                    }

                Destroy(instance2, projectileLifetime);
            }

            if(useAI){
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