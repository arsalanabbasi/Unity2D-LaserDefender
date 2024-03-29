using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "Wave Config")]
public class WaveConfigSO : ScriptableObject
{   
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 11f;
    [SerializeField] float enemySpawnDelay = 1f;
    [SerializeField] float spawnTimeVariance = 0.4f;
    [SerializeField] float minDelayTime = 0.2f;

    public Transform GetStartingWayPoint(){
        return pathPrefab.GetChild(0);
        }

    public List<Transform> GetWaypoints(){
        List<Transform> waypoints = new List<Transform>();
        
        foreach(Transform child in pathPrefab){
            waypoints.Add(child);
            }
        return waypoints;

        }

    public float GetMoveSpeed(){
        return moveSpeed;
        }

    public int GetEnemyCount(){
        return enemyPrefabs.Count;
        }   

    public GameObject GetEnenmyPrefab(int index){
        return enemyPrefabs[index];
        }

    public float GetRandomSpawnTime(){
        float spawnTime = Random.Range(enemySpawnDelay - spawnTimeVariance,
                                       enemySpawnDelay + spawnTimeVariance);
        
        return Mathf.Clamp(spawnTime, minDelayTime, float.MaxValue);
        }
}
