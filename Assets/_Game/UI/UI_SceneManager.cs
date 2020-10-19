using MC_Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_SceneManager : MonoBehaviour {
    public GameObject mainMenu;
    public GameObject inGameHUD;

    public GameObject startMessageGameObject;

    public static bool IsRestarted = false;

    private void Awake() {
        if (IsRestarted == false) {
            MainMenu();
        }
    }
    private void Start() {
        if (IsRestarted == true) {
            HasRestartedGame();
        }
    }

    public void MainMenu() {
        Time.timeScale = 0f;
        mainMenu.SetActive(true);
        inGameHUD.SetActive(false);
    }

    public void StartGame() {
        Time.timeScale = 1f;
        mainMenu.SetActive(false);
        inGameHUD.SetActive(true);
    }

    public void HasRestartedGame() {
        StartGame();
        IsRestarted = false;
        EventSystem<GameStartEvent>.FireEvent(null);
        Destroy(startMessageGameObject);
    }


}
