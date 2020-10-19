using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCheck : MonoBehaviour
{
    [SerializeField] public HPBar pillarHealthBar;
    public UI_MasterMenuController UIController;

    private void Start()
    {

    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     Debug.Log("LOST GAME!");
    //     UIController.GameOver();
    // }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Testing");
        UIController.GameOver();
    }

    public void Hit()
    {
        pillarHealthBar.Damage();
        if(!pillarHealthBar.Alive())
        {
            Debug.Log("LOST GAME!");
            UIController.GameOver();
        }
    }
}
