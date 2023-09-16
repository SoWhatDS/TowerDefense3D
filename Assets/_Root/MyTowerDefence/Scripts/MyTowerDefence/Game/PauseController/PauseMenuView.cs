using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game
{
    public class PauseMenuView : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseUI;
        [SerializeField] private Button _retryButton;
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private Button _continueButton;

        private UnityAction _retryAction;
        private UnityAction _mainMenuAction;
        private UnityAction _continueAction;

        public void Init(UnityAction retryAction,UnityAction mainMenuAction,UnityAction continueAction)
        {
            _retryAction = retryAction;
            _mainMenuAction = mainMenuAction;
            _continueAction = continueAction;
            _retryButton.onClick.AddListener(_retryAction);
            _mainMenuButton.onClick.AddListener(_mainMenuAction);
            _continueButton.onClick.AddListener(_continueAction);
            _pauseUI.SetActive(false);
        }

        public void Toggle()
        {
            _pauseUI.SetActive(!_pauseUI.activeSelf);

            if (_pauseUI.activeSelf)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }

        private void OnDestroy()
        {
            Time.timeScale = 1f;
            _retryButton.onClick.RemoveListener(_retryAction);
            _mainMenuButton.onClick.RemoveListener(_mainMenuAction);
            _continueButton.onClick.RemoveListener(_continueAction);
        }
    }
}
