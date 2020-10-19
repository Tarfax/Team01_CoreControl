using System;
using System.Collections;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;
using MC_Utility;

public class UI_InGameHUD : MonoBehaviour
{
    public Slider ammoSlider;
    public Image ammoFill;
    public GameObject gameCleared;
    // public Text maxAmountOfBullets;
    // public Text currentAmountOfBullets;
    public Text myCurrentScore;
    // public Text currentScore;
   
    private GameObject playerRef;
    private Player_ProjectileAbsorber _myBullets;
    
    
    
    public int maxBullets;
    public int currentBullets;
    public float gameClearedTextTime;
    
    private bool isGameCleared = false;
    private bool isWaveCleared = false;

    public void Start()
    {
        gameCleared.SetActive(false);
        playerRef = GameObject.Find("SpaceMan");
        _myBullets = playerRef.GetComponent<Player_ProjectileAbsorber>();
        currentBullets = _myBullets.ProjectileCount;
        maxBullets = _myBullets.AmountToAbsorb;
        ammoSlider.maxValue = maxBullets;
        ammoSlider.value = currentBullets;
        // maxAmountOfBullets.text = (maxBullets).ToString();
    }

    public void Update()
    {
        ammoSlider.value = currentBullets;
        // ammoFill.color = Color.white;
        currentBullets = _myBullets.ProjectileCount;
        // currentAmountOfBullets.text = currentBullets.ToString();
        myCurrentScore.text = ScoreManager.GetPlayerScoreString();
        
        isGameCleared = EnemySpawnerManager.LastStageCleared();
        // isWaveCleared = EnemySpawnerManager.BossCleared();
        
        if (!isWaveCleared)
        {
            // Debug.Log("aktiv");
            isWaveCleared = EnemySpawnerManager.BossCleared();
            return;
        }
        else 
        {
            Debug.Log("Hej");
            isWaveCleared = false;
            WaveCleared();
        }
        
        if (!isGameCleared)
        {
            return;
        }
        else
        {
            isGameCleared = false;
            WaveCleared();
        }
    }
    
    // Unregister Event
    // private void OnDisable()
    // {
    //     EventSystem<EnemyDeathEvent>.UnregisterListener(OnDeathEvent);
    // }
    //
    // // Register Event
    // private void OnEnable()
    // {
    //     EventSystem<EnemyDeathEvent>.RegisterListener(OnDeathEvent);
    // }
    //
    // private void OnDeathEvent(EnemyDeathEvent deathEvent)
    // {
    //     if (deathEvent.EnemyType == EnemyType.BossAlien)
    //     {
    //         gameCleared.SetActive(true);
    //     }
    // }
    
    private void WaveCleared()
    {
        gameCleared.SetActive(true);
        StartCoroutine(ExecuteAfterTime(gameClearedTextTime));
    }
    
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
            
        gameCleared.SetActive(false);
    }
}
