using System.Collections;
using System.Collections.Generic;
using InGameConstants;
using UI;
using UnityEngine;
using Utils;
using Settings;
using JoostenProductions;
using ObjectPool;

namespace Game
{
    internal sealed class TurretController : BaseController
    {
        private TurretFabric _turretFabric;
        private List<TurretView> _turrets;
        private EnemyFabric _enemyFabric;

        public TurretController(TurretFabric turretFabric, EnemyFabric enemyFabric)
        {
            _turretFabric = turretFabric;
            _turrets = _turretFabric.Turrets;
            _enemyFabric = enemyFabric;
            UpdateManager.SubscribeToUpdate(Update);
        }

        private void Update()
        {
            UpdateTurrets();
        }

        private void UpdateTurrets()
        {
            for (int i = 0; i < _turrets.Count; i++)
            {
                _turrets[i].CheckDistanceToTarget(_enemyFabric.Enemies);
                _turrets[i].ChangeTarget();
                _turrets[i].Shoot();
            }
        }

        protected override void OnDispose()
        {
            UpdateManager.UnsubscribeFromUpdate(Update);
            _turretFabric.Dispose();
            
        }
    }
}
