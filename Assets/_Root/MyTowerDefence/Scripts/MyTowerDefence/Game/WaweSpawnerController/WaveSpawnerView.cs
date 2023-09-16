using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game
{
    internal sealed class WaveSpawnerView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _waveTimerText;

        public TMP_Text WaveTimerText => _waveTimerText;
    }
}
