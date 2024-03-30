using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform projectilePosition1;
    [SerializeField] Transform projectilePosition2;
    [SerializeField] float projectileSpeed = 15f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float firingRate = 0.5f;
    Coroutine firingCoroutine;
    public bool isFiring;
    
    void Start()
    {
        
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
            GameObject instance2 = Instantiate(projectilePrefab,
                                            projectilePosition2.position, Quaternion.identity);
            
            Rigidbody2D myRigidBody1 = instance1.GetComponent<Rigidbody2D>();
            Rigidbody2D myRigidBody2 = instance2.GetComponent<Rigidbody2D>();

            if (myRigidBody1 != null && myRigidBody2 != null){
                myRigidBody1.velocity = transform.up * projectileSpeed;
                myRigidBody2.velocity = transform.up * projectileSpeed;
            }

            Destroy(instance1, projectileLifetime);
            Destroy(instance2, projectileLifetime);

            yield return new WaitForSeconds(firingRate);
            }
   
        }

}
