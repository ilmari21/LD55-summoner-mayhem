using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoaderScript : MonoBehaviour
{
    public Canvas uiCanvas;

    public Button startGame, pauseGame, resumeGame, backToMenu;

    bool gameIsOn;

    void Awake()
    {
        gameIsOn = false;
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(uiCanvas);
        startGame.gameObject.SetActive(true);
        pauseGame.gameObject.SetActive(false);
        resumeGame.gameObject.SetActive(false);
        backToMenu.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        startGame.gameObject.SetActive(false);
        gameIsOn = true;
        SceneManager.LoadScene("MainScene");
    }

    public void GameOver()
    {
        backToMenu.gameObject.SetActive(true);
        SceneManager.LoadScene("GameOver");
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseGame.gameObject.SetActive(false);
        resumeGame.gameObject.SetActive(true);
        backToMenu.gameObject.SetActive(true);
    }
    public void ResumeGame()
    {
        backToMenu.gameObject.SetActive(false);
        resumeGame.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BackToMenu()
    {
        pauseGame.gameObject.SetActive(false);
        resumeGame.gameObject.SetActive(false);
        backToMenu.gameObject.SetActive(false);
        startGame.gameObject.SetActive(true);
        gameIsOn = false;
        Destroy(gameObject);
        SceneManager.LoadScene("MainMenu");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) 
        {
            PauseGame();
        }
    }
}
