using System.Collections;
using System.Collections.Generic;
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
        levels[levelIndex].SetActive(false);
        levelIndex++;
        midLevel = true;
        midLevelUi.SetActive(true);
    }

    void StartNextLevel() {
        levels[levelIndex].SetActive(true);
        midLevelUi.SetActive(false);
        playerCon.ResetPlayer();
        Time.timeScale = 1;
        enemyManager.UpdateCivilians();
    }

    void StartLevel() {
        //start stuff

    }

  
}
