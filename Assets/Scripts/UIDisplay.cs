using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] TextMeshProUGUI displayScore;

    [Header("Health")]
    [SerializeField] Slider displayHealth;
    [SerializeField] Health playerHealth;

    [Header("Wave")]
    [SerializeField] TextMeshProUGUI displayWave;
    EnemySpawner enemySpawner;
    ScoreKeeper scoreKeeper;

    void Awake(){
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        }
    void Start(){
        displayHealth.maxValue = playerHealth.GetHealth();
        DisplayHealth();
        DisplayScore();
        DisplayWave();
        }


    void Update(){
        DisplayHealth();
        DisplayScore();
        DisplayWave();
        }

    void DisplayScore(){
        displayScore.text = "Score: " + scoreKeeper.GetPlayerScore().ToString();
        }
    
    void DisplayHealth(){
        displayHealth.value = playerHealth.GetHealth();
        }

    void DisplayWave(){
        displayWave.text = "WAVE: " + enemySpawner.wave.ToString();
        }
}
