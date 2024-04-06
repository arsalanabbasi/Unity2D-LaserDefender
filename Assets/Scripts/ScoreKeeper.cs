using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    
    int playerScore;
    static ScoreKeeper instance;

    void Awake(){
        ManageSingleton();
        }

    void ManageSingleton(){
        if(instance != null){
            gameObject.SetActive(false);
            Destroy(gameObject);
            }
        
        else{
            instance = this;
            DontDestroyOnLoad(gameObject);
            }
        }

    public int GetPlayerScore(){
        return playerScore;
        }

    public void SetPlayerScore(int score){
        playerScore += score;
        Mathf.Clamp(playerScore, 0, int.MaxValue);
        }

    public void ResetPlayerScore(){
        playerScore = 0;
        }

}
