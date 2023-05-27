using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundsSurvived : MonoBehaviour
{
    public TMP_Text RoundsText;


    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        RoundsText.text = "0";
        int round = 0;

        yield return new WaitForSeconds(0.7f);

        while (round < PlayerStats.Rounds)
        {
            round++;
            RoundsText.text = round.ToString();
            yield return new WaitForSeconds(0.05f);
        }

    }
}
