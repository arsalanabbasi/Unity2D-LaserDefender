using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;

    [HideInInspector] public int wave;
    WaveConfigSO currentWave;
    bool isLooping = true;



    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WaveConfigSO GetCurrentWave(){
        return currentWave;
        }

    IEnumerator SpawnEnemyWaves(){
        do{
            foreach(WaveConfigSO child in waveConfigs){
                currentWave = child;
                wave++;
                for(int i=0; i< currentWave.GetEnemyCount(); i++){

                    Instantiate(currentWave.GetEnenmyPrefab(i),
                                currentWave.GetStartingWayPoint().position,
                                Quaternion.identity, transform);

                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                    }
                
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }while(isLooping);

        }
}
