using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoaderScript : MonoBehaviour
{
    public Canvas uiCanvas;

    //public Button startGame, pauseGame, resumeGame, backToMenu;

    //public Image backGround;

    //public GameObject gameOverText;

    [SerializeField] GameObject mainMenu;

    [SerializeField] GameObject pauseMenu;

    [SerializeField] GameObject gameOver;

    void Awake()
    {
        mainMenu.SetActive(true);
        gameOver.SetActive(false);

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(uiCanvas);
        //startGame.gameObject.SetActive(true);
        //pauseGame.gameObject.SetActive(false);
        //resumeGame.gameObject.SetActive(false);
        //backToMenu.gameObject.SetActive(false);
        //gameOverText.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        mainMenu.SetActive(false);
        //startGame.gameObject.SetActive(false);
        //backGround.gameObject.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        //backToMenu.gameObject.SetActive(true);
        //backGround.gameObject.SetActive(true);
        //gameOverText.gameObject.SetActive(true);
        Time.timeScale = 0f;
        SceneManager.LoadScene("GameOver");
    }

    public void PauseGame()
    {
        AudioFW.StopLoop("Music");
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        //pauseGame.gameObject.SetActive(false);
        //resumeGame.gameObject.SetActive(true);
        //backToMenu.gameObject.SetActive(true);
    }
    public void ResumeGame()
    {
        AudioFW.PlayLoop("Music");
        pauseMenu.SetActive(false);
        //backToMenu.gameObject.SetActive(false);
        //resumeGame.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BackToMenu()
    {
        pauseMenu.SetActive(false);
        mainMenu.SetActive(true);
        gameOver.SetActive(false);

        //pauseGame.gameObject.SetActive(false);
        //resumeGame.gameObject.SetActive(false);
        //backToMenu.gameObject.SetActive(false);
        //startGame.gameObject.SetActive(true);
        //backGround.gameObject.SetActive(true);
        //gameOverText.gameObject.SetActive(false);
        Destroy(gameObject);
        Time.timeScale = 0f;
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame() {
        Application.Quit();
        Debug.Log("Quitting Game...");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) 
        {
            PauseGame();
        }
    }
}
