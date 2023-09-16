using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace LevelSelect
{
    internal sealed class LevelSelectView : MonoBehaviour
    {
        [SerializeField] private Button _levelSelectButton;
        [SerializeField] private SelectLevel[] _levelSelect;

        public LevelView selectedLevel;

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

        private void SubscribeLevelSelectButtons()
        {
            for (int i = 0; i < _levelSelect.Length; i++)
            {
                _levelSelect[i].selectLevelButton.onClick.AddListener(_chooseLevel);
            }
        }

        private void UnSubscribeLevelSelectButtons()
        {
            for (int i = 0; i < _levelSelect.Length; i++)
            {
                _levelSelect[i].selectLevelButton.onClick.RemoveListener(_chooseLevel);
            }
        }

        public LevelView SelectLevelToLod()
        {
            return _levelSelect[0].levelToLoad;
        }
    }
}
