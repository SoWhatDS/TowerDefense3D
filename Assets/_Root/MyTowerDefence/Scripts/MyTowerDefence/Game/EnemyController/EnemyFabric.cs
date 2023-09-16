
using UnityEngine;
using Utils;
using InGameConstants;
using Settings;
using ObjectPool;
using System.Collections.Generic;
using System;
using Object = UnityEngine.Object;

namespace Game
{
    internal sealed class EnemyFabric
    {
        private EnemyModel _enemyModel;
        private LevelView _levelView;
        private EnemyView _enemyView;
        private PlayerStatisticsModel _playerStatisticsModel;
        public int EnemiesAlive = 0;

        private IViewServices _viewServices;
        private List<EnemyView> _enemies = new List<EnemyView>();

        public List<EnemyView> Enemies => _enemies;

        public EnemyFabric(SettingsContainer settings,LevelView levelView,IViewServices viewServices)
        {
            _enemyModel = settings.EnemyModel;
            _playerStatisticsModel = settings.PlayerStatisticsModel;
            _levelView = levelView;
            _viewServices = viewServices;
        }

        public EnemyView CreateEnemy()
        {
            _enemyView = _viewServices.Instantiate<EnemyView>(_enemyModel.EnemyPrefab,_levelView.StartGame.position);
            _enemyView.init(_enemyModel,_levelView.WayPoints,_playerStatisticsModel);
            _enemyView.IsDeath = false;
            Enemies.Add(_enemyView);
            return _enemyView;
        }

        public EnemyView CreateEnemyFromWave(GameObject enemyPrefab)
        {
            _enemyView = _viewServices.Instantiate<EnemyView>(enemyPrefab, _levelView.StartGame.position);
            _enemyView.init(_enemyModel, _levelView.WayPoints, _playerStatisticsModel);
            _enemyView.IsDeath = false;
            Enemies.Add(_enemyView);
            EnemiesAlive++;
            return _enemyView;
        }

        public void Dispose()
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                Object.Destroy(_enemies[i].gameObject);
                _viewServices.Dispose(_enemies[i].gameObject);
            }
        }
    }
}
