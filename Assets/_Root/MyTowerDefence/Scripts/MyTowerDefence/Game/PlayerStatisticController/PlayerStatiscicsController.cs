using System.Collections;
using System.Collections.Generic;
using JoostenProductions;
using Settings;
using TMPro;
using UnityEngine;
using Utils;

namespace Game
{
    internal sealed class PlayerStatiscicsController : BaseController
    {
        private PlayerStatisticsModel _playerStatisticModel;
        private PlayerStatisticsView _playerStatisticsView;
        private AllTurretsInGameModel _allTurretsInGameModel;
        private Profile _profile;
        private GameObject _GameOverUI;
        private int _turretToBuildPrice;
        private TMP_Text _playerMoneyText;

        internal PlayerStatiscicsController(PlayerStatisticsModel playerStatisticModel,
            AllTurretsInGameModel allTurretsInGameModel,PlayerStatisticsView playerStatisticsView,Profile profile)
        {
            _playerStatisticModel = playerStatisticModel;
            _playerStatisticsView = playerStatisticsView;
            _allTurretsInGameModel = allTurretsInGameModel;
            _profile = profile;
            _playerMoneyText = _playerStatisticsView.PlayerMoneyText;
            _playerStatisticsView.Init(RetryGame,BackToMainmenu);
            _GameOverUI = playerStatisticsView.GameOverUI;
            _GameOverUI.SetActive(false);
            _playerStatisticModel.Money = 500;
            _playerStatisticModel.Lives = 5;
            _playerStatisticModel.OnCheckMoneyForBuild += SpendPlayerMoneyForBuild;
            _playerStatisticModel.OnCheckMoneyForUpgrade += SpendPlayerMoneyForUpgrade;
            _playerStatisticModel.OnSellTurret += ReturnMoneyFromSellTurret;
            UpdateManager.SubscribeToUpdate(Update);
        }

        private void Update()
        {
            if (_playerStatisticModel.Lives < 0)
            {
                EndGame();
                return;
            }
            _playerStatisticsView.PlayerLivesText.text = _playerStatisticModel.Lives.ToString() + " LIVES";
            _playerMoneyText.text = _playerStatisticModel.Money.ToString();
            
        }

        private void SpendPlayerMoneyForBuild()
        {
            _turretToBuildPrice = _allTurretsInGameModel.TurretModelToBuild.Price;
            if (_playerStatisticModel.Money < _turretToBuildPrice)
            {
                _playerStatisticModel.NotEnoughMoney = true;
                return;
            }
            _playerStatisticModel.Money -= _turretToBuildPrice;
            _playerStatisticModel.NotEnoughMoney = false;
        }

        private void SpendPlayerMoneyForUpgrade(TurretModel _turretModelOnNode)
        {
            if (_turretModelOnNode == null || _playerStatisticModel.Money < _turretModelOnNode.UpgradeCost || _turretModelOnNode.IsUpgradable == true)
            {
                _playerStatisticModel.NotEnoughMoney = true;
                return;
            }
            _playerStatisticModel.Money -= _turretModelOnNode.UpgradeCost;
            _playerStatisticModel.NotEnoughMoney = false;
        }

        private void ReturnMoneyFromSellTurret(TurretModel _turretModelOnNode)
        {
            if (_turretModelOnNode == null)
            {
                return;
            }
            else if (_turretModelOnNode.IsUpgradable)
            {
                _playerStatisticModel.Money += _turretModelOnNode.SellUpgradableTurretCost;
                return;
            }

            _playerStatisticModel.Money += _turretModelOnNode.SellTurretCost;
        }

        private void EndGame()
        {
            _GameOverUI.SetActive(true);
        }

        private void RetryGame()
        {
            _profile.CurrentState.Value = GameState.StartGame;
        }

        private void BackToMainmenu()
        {
            _profile.CurrentState.Value = GameState.MainMenu;
        }

        protected override void OnDispose()
        {
            _playerStatisticModel.OnCheckMoneyForBuild -= SpendPlayerMoneyForBuild;
            _playerStatisticModel.OnCheckMoneyForUpgrade -= SpendPlayerMoneyForUpgrade;
            _playerStatisticModel.OnSellTurret -= ReturnMoneyFromSellTurret;
            UpdateManager.UnsubscribeFromUpdate(Update);
        }
    }
}
