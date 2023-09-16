using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game
{
    internal sealed class PlayerStatisticsView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _playerMoneyText;
        [SerializeField] private TMP_Text _playerLivesText;
        [SerializeField] private GameObject _GameOverUI;
        [SerializeField] private TMP_Text _playerRoudsText;
        [SerializeField] private Button _retryButton;
        [SerializeField] private Button _menuButton;

        public TMP_Text PlayerMoneyText => _playerMoneyText;
        public TMP_Text PlayerLivesText => _playerLivesText;
        public TMP_Text PlayerRoundsTect => _playerRoudsText;
        public GameObject GameOverUI => _GameOverUI;

        private UnityAction _retryGameAction;
        private UnityAction _backToMainMenuAction;

        public void Init(UnityAction retryGameAction,UnityAction backToMainMenu)
        {
            _retryGameAction = retryGameAction;
            _backToMainMenuAction = backToMainMenu;

            _retryButton.onClick.AddListener(_retryGameAction);
            _menuButton.onClick.AddListener(_backToMainMenuAction);
        }

        private void OnDestroy()
        {
            _retryButton.onClick.RemoveListener(_retryGameAction);
            _menuButton.onClick.RemoveListener(_backToMainMenuAction);
        }



    }
}
