﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public string menuSceneName = "MainMenu";
    public SceneFader sceneFader;

    public void Retry()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }

}
