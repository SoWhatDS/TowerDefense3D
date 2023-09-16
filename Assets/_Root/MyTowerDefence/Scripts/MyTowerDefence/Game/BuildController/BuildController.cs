using System.Collections;
using System.Collections.Generic;
using JoostenProductions;
using UnityEngine;

namespace Game
{
    internal sealed class BuildController : BaseController
    {
        private TurretFabric _turretFabric;
        private LevelView _levelView;
        private NodeView[] _nodes;
        private TurretView _turretOnNode;
        private PlayerStatisticsModel _playerStatisticsModel;

        public BuildController(TurretFabric turretFabric,LevelView levelView,PlayerStatisticsModel playerStatisticsModel)
        {
            _turretFabric = turretFabric;
            _levelView = levelView;
            _nodes = _levelView.NodesView;
            _playerStatisticsModel = playerStatisticsModel;
            SubscribeToBuildTurret();
        }

        private void SubscribeToBuildTurret()
        {
            for (int i = 0; i < _nodes.Length; i++)
            {
                _nodes[i].BuildTurretOnNode += BuildTurret;
                _nodes[i].Init(_levelView);
            }
        }

        private void BuildTurret()
        {
            _playerStatisticsModel.OnCheckMoneyForBuild?.Invoke();
            if (_playerStatisticsModel.NotEnoughMoney == true)
            {
                return;
            }

            _levelView.SelectedNode.TurretOnNode = _turretFabric.BuildTurret(_levelView.SelectedNode.transform);
            AddGameObject(_levelView.SelectedNode.TurretOnNode.gameObject);
        }

        private void UnSubscribeToBuildTurret()
        {
            for (int i = 0; i < _nodes.Length; i++)
            {
                _nodes[i].BuildTurretOnNode -= BuildTurret;
            }
        }

        protected override void OnDispose()
        {
            UnSubscribeToBuildTurret();
        }
    }
}
