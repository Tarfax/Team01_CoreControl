using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UI_EndMenu : MonoBehaviour
{
    public static bool GameHasEnded;
    public GameObject inGameUI;
    public GameObject endGameUI;
    // public GameObject coreObject;
    private bool isDead = false;

    private void Awake()
    {
        GameHasEnded = false;
        inGameUI.SetActive(true);
        endGameUI.SetActive(false);
    }

    // private void Start()
    // {
    //     coreObject = coreObject.GetComponent<GameObject>();
    // }

    public void LostGame()
    {
        GameHasEnded = true;
        GameOver();
    }
    
    public void GameOver()
    {
        if(GameHasEnded == true)
        {
            inGameUI.SetActive(false);
            endGameUI.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            return;
        }
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        GameHasEnded = false;
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        GameHasEnded = false;
        Debug.Log("Loading Level...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
