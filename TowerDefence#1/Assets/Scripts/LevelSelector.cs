using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{

    public SceneFader fader;
    public Button[] levelButtons;

    void Start()
    {

        int levelReached = PlayerPrefs.GetInt("LevelReached", 1);

        // Any Level we reached is clickable, any level not reached is not clickable
        for (int i = 0; i < levelButtons.Length; i++)
        {
            // checks if the level number i is less or greater than our reached level
            if ((i + 1) > levelReached)
            {
                levelButtons[i].interactable = false;
            }

        }
    }

    public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }

}
