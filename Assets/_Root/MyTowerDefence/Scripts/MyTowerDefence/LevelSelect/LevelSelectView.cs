using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace LevelSelect
{
    internal sealed class LevelSelectView : MonoBehaviour
    {
        [SerializeField] private Button _levelSelectButton;

        private UnityAction _chooseLevel;

        public void Init(UnityAction chooseLevel)
        {
            _chooseLevel = chooseLevel;
            _levelSelectButton.onClick.AddListener(_chooseLevel);
        }

        private void OnDestroy()
        {
            _levelSelectButton.onClick.RemoveListener(_chooseLevel);
        }
    }
}
