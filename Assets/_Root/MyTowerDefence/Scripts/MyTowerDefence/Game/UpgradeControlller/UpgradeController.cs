using System.Collections;
using System.Collections.Generic;
using InGameConstants;
using JoostenProductions;
using UnityEngine;
using Utils;

namespace Game
{
    internal class UpgradeController : BaseController
    {
        private UpgradeView _upgradeView;
        private LevelView _levelView;
        private NodeView[] _nodes;
        private TurretView _selectedTurret;
        private NodeView _selectedNode;
        private TurretFabric _turretFabric;
        private PlayerStatisticsModel _playerStatisticsModel;

        public UpgradeController(LevelView levelView, TurretFabric turretFabric, PlayerStatisticsModel playerStatisticsModel)
        {
            _upgradeView = LoadView();
            _upgradeView.Init(UpgradeTurret, SellTurret);
            _upgradeView.gameObject.SetActive(false);
            _levelView = levelView;
            _nodes = _levelView.NodesView;
            _turretFabric = turretFabric;
            _playerStatisticsModel = playerStatisticsModel;
            SubscribeOnUpgrade();
        }

        private UpgradeView LoadView()
        {
            GameObject prefab = ResourceLoader.LoadPrefab(GameConstants.UpgradeUIPrefab);
            GameObject objectView = Object.Instantiate(prefab);
            AddGameObject(objectView);
            return objectView.GetComponent<UpgradeView>();
        }

        private void ActivateUpgradeUI(NodeView selectedNode)
        {
            if (selectedNode.TurretOnNode == null)
            {
                DeactivateUpgradeUI();
            }
            else
            {
                _upgradeView.transform.position = selectedNode.TurretOnNode.transform.position;
                _upgradeView.Activate();
                _selectedNode = selectedNode;
                _selectedTurret = _selectedNode.TurretOnNode;
            }
        }

        private void DeactivateUpgradeUI()
        {           
            _upgradeView.Deactivate();
        }

        private void UpgradeTurret()
        {
            _playerStatisticsModel.OnCheckMoneyForUpgrade?.Invoke(_selectedTurret.GetTurretModel());
            if (_selectedTurret == null || _selectedTurret.GetTurretModel().IsUpgradable || _playerStatisticsModel.NotEnoughMoney == true)
            {
                return;
            }

            _selectedNode.TurretOnNode = _turretFabric.BuildUpgradeTurret(_selectedTurret);
            _selectedNode.TurretOnNode.GetTurretModel().IsUpgradable = true;
            DeactivateUpgradeUI();
            
        }

        private void SellTurret()
        {
            if (_selectedNode.TurretOnNode == null)
            {
                return;
            }
            _playerStatisticsModel.OnSellTurret.Invoke(_selectedTurret.GetTurretModel());
            _turretFabric.SellTurret(_selectedTurret);
            _selectedNode.TurretOnNode = null;
            DeactivateUpgradeUI();          
        }

        private void SubscribeOnUpgrade()
        {
            for (int i = 0; i < _nodes.Length; i++)
            {
                _nodes[i].UpradeTurretOnNode += ActivateUpgradeUI;
            }
        }

        private void UnSubscribeOnUpgrade()
        {
            for (int i = 0; i < _nodes.Length; i++)
            {
                _nodes[i].UpradeTurretOnNode -= ActivateUpgradeUI;
            }
        }


        protected override void OnDispose()
        {
            UnSubscribeOnUpgrade();
        }


    }
}
