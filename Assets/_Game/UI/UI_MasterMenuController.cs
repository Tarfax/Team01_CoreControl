using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using MC_Utility;

public class UI_MasterMenuController : MonoBehaviour {
    public static bool gameIsPaused;
    public static bool gameHasEnded;

    public GameObject pauseGameIU;
    public GameObject inGameUI;
    public GameObject gameOverUI;
    public GameObject waveClearedUI;
    public Text bonusPoints;
    public Text playerName;

    [HideInInspector] public int maxBullets = 5;
    [HideInInspector] public int currentBullets;

    public float timeClearedText = 2f;

    public Text myCurrentScore;
    public Text myEndScore;
    public Text theHighScore;
    public Text theHighScoreName;
    public Text tempScore;

    public Slider ammoSlider;
    public Image ammoFill;

    public AudioSource[] audioSources;

    private GameObject _playerRef;
    private Player_ProjectileAbsorber _myBullets;
    private UI_SceneManager myManager;

    private bool isWaveCleared = false;
    private bool isGameCleared = false;

    private void Start() {
        myManager = GetComponentInParent<UI_SceneManager>();
        _playerRef = GameObject.Find("SpaceMan");
        _myBullets = _playerRef.GetComponent<Player_ProjectileAbsorber>();

        playerName.text = ScoreManager.GetPlayerName();
        inGameUI.SetActive(true);
        tempScore.gameObject.SetActive(false);
        gameHasEnded = false;
        gameIsPaused = false;
        pauseGameIU.SetActive(false);
        gameOverUI.SetActive(false);
        waveClearedUI.SetActive(false);


        bonusPoints.text = ScoreManager.GetPlatformScoreString();
        bonusPoints.gameObject.SetActive(false);
        currentBullets = _myBullets.ProjectileCount;
        ammoSlider.maxValue = 5;
        ammoSlider.value = currentBullets;
    }

    private void Update() {
        if (Keyboard.current.escapeKey.wasPressedThisFrame == true) {
            if (gameIsPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }

        myCurrentScore.text = ScoreManager.GetPlayerScoreString();
        currentBullets = _myBullets.ProjectileCount;
        ammoSlider.value = currentBullets;
        bonusPoints.text = "Bonus: " + ScoreManager.GetPlatformScoreString();

        // isGameCleared = EnemySpawnerManager.LastStageCleared();

        if (!isWaveCleared) {
            isWaveCleared = EnemySpawnerManager.BossCleared();
            return;
        }
        else {
            isWaveCleared = false;
            WaveCleared();
        }

        if (!isGameCleared) {
            isGameCleared = EnemySpawnerManager.LastStageCleared();
        }
        else {
            GameOver();
        }
    }

    private void WaveCleared() {
        tempScore = myCurrentScore;
        myCurrentScore.gameObject.SetActive(false);
        bonusPoints.gameObject.SetActive(true);
        tempScore.gameObject.SetActive(true);
        waveClearedUI.SetActive(true);
        StartCoroutine(ExecuteAfterTime(timeClearedText));
    }

    IEnumerator ExecuteAfterTime(float time) {
        yield return new WaitForSeconds(time);

        waveClearedUI.SetActive(false);
        bonusPoints.gameObject.SetActive(false);
        tempScore.gameObject.SetActive(false);
        myCurrentScore.gameObject.SetActive(true);
    }

    public void Resume() {
        SoundPlayer.Instance.PlaySound(audioSources[1]);  // play sound 1
        gameIsPaused = false;
        Time.timeScale = 1f;
        inGameUI.SetActive(true);
        pauseGameIU.SetActive(false);
        gameOverUI.SetActive(false);
    }

    private void Pause() {
        gameIsPaused = true;
        Time.timeScale = 0f;
        inGameUI.SetActive(false);
        pauseGameIU.SetActive(true);
        gameOverUI.SetActive(false);
    }

    public void LoadMenu() {
        gameIsPaused = false;
        SoundPlayer.Instance.PlaySound(audioSources[1]);
        Time.timeScale = 1f;
        gameHasEnded = false;
        myManager.MainMenu();
        // SceneManager.LoadScene(0);
    }

    public void RestartGame() {
        //gameIsPaused = false;
        //
        //Time.timeScale = 1f;
        //gameHasEnded = false;
        UI_SceneManager.IsRestarted = true;
        SceneManager.LoadScene(0);
    }

    public void GameOver() {
        // if (!isGameCleared)
        // {
        //     return;
        // }
        // else
        // {

        gameOverUI.SetActive(true);
        EventSystem<GameOverEvent>.FireEvent(null);
        isGameCleared = false;
        myEndScore.text = myCurrentScore.text;
        theHighScore.text = ScoreManager.GetHighScorePoint(0);
        theHighScoreName.text = ScoreManager.GetHighScoreName(0) + ": ";
        inGameUI.SetActive(false);
        pauseGameIU.SetActive(false);
        Time.timeScale = 0f;
        // }
    }

    public void QuitGame() {
        SoundPlayer.Instance.PlaySound(audioSources[1]);
        Application.Quit();
    }
}
