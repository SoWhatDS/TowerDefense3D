using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;

    private void Update()
    {
        _moneyText.text = "$" + PlayerStats.Money.ToString();
    }
}
