﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    PlayerController playerController;
    public bool gameStarted { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        gameStarted = true;
    }

    public void RestartGame()
    {
        //Invoke("Load", 1f);
        SceneManager.LoadScene(1);

    }

    private void Load()
    {
        SceneManager.LoadScene(0);

    }

}
