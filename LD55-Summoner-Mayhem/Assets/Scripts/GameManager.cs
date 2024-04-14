using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int levelIndex;
    [SerializeField] GameObject midLevelUi;
    bool midLevel;
    public List<GameObject> levels;
    public List<GameObject> summoners;
    [SerializeField] EnemyManager enemyManager;
    PlayerController playerCon;
    [SerializeField] TMP_Text levelText;


    void Start() {
        playerCon = FindObjectOfType<PlayerController>();
        levelIndex = 0;
        StartLevel();
    }

    void Update() {
        if (summoners.Count == 0 && midLevel == false) {
            LoadNextLevel();
        }    
        if (midLevel == true && Input.GetKeyDown(KeyCode.Space)) {
            StartNextLevel();
        }
    }

    public void GameOver() {
        //Game Over Stuff
        Debug.Log("Game Over");
    }

    public void LoadNextLevel() {
        Time.timeScale = 0;
        playerCon.GetComponent<PlayerAttack>().canAttack = false;
        levels[levelIndex].SetActive(false);
        levelIndex++;
        if (levelIndex >= levels.Count) {
            Debug.Log("No more levels");
        }
        midLevel = true;
        midLevelUi.SetActive(true);
        levelText.text = "Level " + levelIndex + " Complete";
        levels[levelIndex].SetActive(true);
        foreach (var enemy in enemyManager.enemies) {
            Destroy(enemy);
        }
        playerCon.ResetPlayer();
    }

    void StartNextLevel() {
        midLevelUi.SetActive(false);
        playerCon.GetComponent<PlayerAttack>().canAttack = true;
        midLevel = false;
        Time.timeScale = 1;
        enemyManager.UpdateCivilians();
    }

    void StartLevel() {
        //start stuff

    }

  
}
