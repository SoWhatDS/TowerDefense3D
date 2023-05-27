using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public SceneFeder sceneFeder;

    public string menuSceneName = "MainMenu";

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFeder.FadeTo(nextLevel);
    }
    public void Menu()
    {
        sceneFeder.FadeTo(menuSceneName);
    }
}
