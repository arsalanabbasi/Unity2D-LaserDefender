using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;


public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    void Awake() {
        enemySpawner = FindObjectOfType<EnemySpawner>(); 
        }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

 
    void Update()
    {
        FollowWaypoints();
    }

    void FollowWaypoints(){

        if(waypointIndex < waypoints.Count){
            UnityEngine.Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = UnityEngine.Vector2.MoveTowards(transform.position, targetPosition, delta);

            if(transform.position == targetPosition){
                waypointIndex++;
                }
            }
        else{
            Destroy(gameObject);
            }     
        }
}
