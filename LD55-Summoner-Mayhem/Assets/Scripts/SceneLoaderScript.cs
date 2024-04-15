using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoaderScript : MonoBehaviour
{
    public Canvas uiCanvas;

    [SerializeField] GameObject audioFw;

    //public Button startGame, pauseGame, resumeGame, backToMenu;

    //public Image backGround;

    //public GameObject gameOverText;

    [SerializeField] GameObject mainMenu;

    [SerializeField] GameObject pauseMenu;

    [SerializeField] GameObject gameOver;

    [SerializeField] GameObject gameWin;


    void Awake()
    {
        mainMenu.SetActive(true);
        gameOver.SetActive(false);

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(uiCanvas);
        DontDestroyOnLoad(audioFw);
        //startGame.gameObject.SetActive(true);
        //pauseGame.gameObject.SetActive(false);
        //resumeGame.gameObject.SetActive(false);
        //backToMenu.gameObject.SetActive(false);
        //gameOverText.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        AudioFW.Play("Select");
        mainMenu.SetActive(false);
        //startGame.gameObject.SetActive(false);
        //backGround.gameObject.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    public void GameOver()
    {
        AudioFW.StopLoop("Music");
        AudioFW.StopLoop("Gunfire");
        gameOver.SetActive(true);
        //backToMenu.gameObject.SetActive(true);
        //backGround.gameObject.SetActive(true);
        //gameOverText.gameObject.SetActive(true);
        Time.timeScale = 0f;
        SceneManager.LoadScene("GameOver");
    }

    public void PauseGame()
    {
        AudioFW.Play("Select");
        AudioFW.StopLoop("Music");
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        //pauseGame.gameObject.SetActive(false);
        //resumeGame.gameObject.SetActive(true);
        //backToMenu.gameObject.SetActive(true);
    }
    public void ResumeGame()
    {
        AudioFW.Play("Select");
        AudioFW.PlayLoop("Music");
        pauseMenu.SetActive(false);
        //backToMenu.gameObject.SetActive(false);
        //resumeGame.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BackToMenu()
    {
        AudioFW.Play("Select");
        pauseMenu.SetActive(false);
        mainMenu.SetActive(true);
        gameOver.SetActive(false);
        gameWin.SetActive(false);

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

    public void GameWin() {
        SceneManager.LoadScene("GameWin");
        gameWin.SetActive(true);
    }

    public void QuitGame() {
        AudioFW.Play("Select");
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
