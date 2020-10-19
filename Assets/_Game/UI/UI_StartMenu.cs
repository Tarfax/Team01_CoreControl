using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using MC_Utility;
using UnityEngine.EventSystems;

public class UI_StartMenu : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject optionsMenuUI;
    public GameObject controlsMenuUI;
    public GameObject startNewGameUI;
    public InputField usernameInput;
    public static string username;
    public AudioSource[] AudioSource;

    public UI_SceneManager myManager;

    // public Animation cameraSequence;
    // public Animator cameraAnimator;
    private void Awake()
    {
        // myManager = GetComponent<UI_SceneManager>();
        mainMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
        controlsMenuUI.SetActive(false);
        startNewGameUI.SetActive(false);
    }

    private void Start()
    {
        if (username != null)
        {
            usernameInput.text = username;
        }
    }

    public void StartGame()
    {
        // cameraAnimator.GetComponent<Animator>().SetBool("PlayGame", true);
        // cameraSequence.Play("Start");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        EventSystem<GameStartEvent>.FireEvent(null);
        ScoreManager.SetPlayerName(username);
        myManager.StartGame();
    }

    public void StartNewGame()
    {
        mainMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        controlsMenuUI.SetActive(false);
        startNewGameUI.SetActive(true);
        // mySceneManager
    }
    
    public void SettingsMenu()
    {
        mainMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
        controlsMenuUI.SetActive(false);
        startNewGameUI.SetActive(false);
    }

    public void ControlsMenu()
    {
        mainMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        controlsMenuUI.SetActive(true);
        startNewGameUI.SetActive(false);
    }

    public void BackToMainMenu()
    {
        mainMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
        controlsMenuUI.SetActive(false);
        startNewGameUI.SetActive(false);
    }

    public void SaveUsername(string newName)
    {
        username = newName;
        Debug.Log(username);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void PlaySound(int index)
    {
        SoundPlayer.Instance.PlaySound(AudioSource[index]);

    }
}
