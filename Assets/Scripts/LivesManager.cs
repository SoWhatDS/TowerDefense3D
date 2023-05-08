using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesManager : MonoBehaviour
{
    private bool isEndGame = false;

    private void Update()
    {
        if (isEndGame)
        {
            return;
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        isEndGame = true;
        Debug.Log("Game Over!");
    }
}
