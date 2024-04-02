using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    
    int playerScore;

    

    public int GetPlayerScore(){
        return playerScore;
        }

    public void setPlayerScore(int score){
        playerScore += score;
        Mathf.Clamp(playerScore, 0, int.MaxValue);
        }

    public void resetPlayerScore(){
        playerScore = 0;
        }

}
