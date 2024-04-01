using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI displayScore;
    [SerializeField] Slider displayHealth;
    [SerializeField] Health playerHealth;
    ScoreKeeper scoreKeeper;

    void Awake(){
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

        }
    void Start(){
        displayHealth.maxValue = playerHealth.GetHealth();
        DisplayHealth();
        DisplayScore();
        }


    void Update(){
        DisplayHealth();
        DisplayScore();
        }

    void DisplayScore(){
        displayScore.text = "Score: " + scoreKeeper.GetPlayerScore().ToString();
        }
    
    void DisplayHealth(){
        displayHealth.value = playerHealth.GetHealth();
        }
}
