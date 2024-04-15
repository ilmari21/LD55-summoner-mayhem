using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int levelIndex;
    [SerializeField] GameObject midLevelUi;
    bool midLevel;
    public List<GameObject> levels;
    public List<GameObject> summoners;
    SceneLoaderScript sceneLoader;
    [SerializeField] EnemyManager enemyManager;
    PlayerController playerCon;
    [SerializeField] TMP_Text levelText;


    void Start() {
        sceneLoader = FindObjectOfType<SceneLoaderScript>();
        playerCon = FindObjectOfType<PlayerController>();
        levelIndex = 0;
        StartLevel();
        AudioFW.PlayLoop("Music");
    }

    void Update() {
        if (summoners.Count == 0 && midLevel == false)
        {
            foreach (var civ in enemyManager.civilians)
            {
                Destroy(civ);
            }
            LoadNextLevel();
        }    
        if (midLevel == true && Input.GetKeyDown(KeyCode.Space)) {
            StartNextLevel();
        }
    }

    public void GameOver() {
        //Game Over Stuff
        Debug.Log("Game Over");
        sceneLoader.GameOver();
    }

    public void LoadNextLevel() {
        Time.timeScale = 0;
        playerCon.GetComponent<PlayerAttack>().canAttack = false;
        levels[levelIndex].SetActive(false);
        levelIndex++;
        if (levelIndex >= levels.Count) {
            sceneLoader.GameWin();
            return;
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
