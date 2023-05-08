using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    public TMP_Text livesText;

    private void Update()
    {
        livesText.text = PlayerStats.Lives.ToString() + " LIVES";
    }

}
