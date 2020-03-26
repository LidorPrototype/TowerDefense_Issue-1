using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string levelToLoad = "MainLevel";
    public SceneFader sceneFader;

    public void Play()
    {
        //SceneManager.LoadScene(levelToLoad);
        //FindObjectOfType<SceneFader>().FadeTo(levelToLoad);
        sceneFader.FadeTo(levelToLoad);
    }

    public void Quit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }

}
