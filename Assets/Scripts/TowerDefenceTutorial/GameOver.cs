using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TMP_Text RoundsText;
    public SceneFeder sceneFeder;
    public string menuSceneName = "MainMenu";

    private void OnEnable()
    {
        RoundsText.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
        sceneFeder.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        sceneFeder.FadeTo(menuSceneName);
    }
}
