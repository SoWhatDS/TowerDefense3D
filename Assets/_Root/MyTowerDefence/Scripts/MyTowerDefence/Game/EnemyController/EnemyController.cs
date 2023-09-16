using System.Collections;
using System.Collections.Generic;
using JoostenProductions;
using UnityEngine;
using Settings;
using System;
using Object = UnityEngine.Object;
using ObjectPool;
using static UnityEngine.EventSystems.EventTrigger;

namespace Game
{
    internal sealed class EnemyController : BaseController
    {
        private List<EnemyView> _enemies;
        private IViewServices _viewServices;
        private EnemyFabric _enemyFabric;

        public EnemyController(EnemyFabric enemyFabric, IViewServices viewServices)
        {
            _enemyFabric = enemyFabric;
            _enemies = _enemyFabric.Enemies;
            _viewServices = viewServices;
            UpdateManager.SubscribeToUpdate(Update);
        }

        private void Update()
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                if (_enemies[i] == null)
                {
                    return;
                }

                _enemies[i].Move();

                EnemyDeath(_enemies[i]);
            }
        }

        private void EnemyDeath(EnemyView enemy)
        {
            if (enemy.IsDeath)
            {
                enemy.Death();
                _viewServices.Destroy(enemy.gameObject);
                _enemies.Remove(enemy);
                _enemyFabric.EnemiesAlive--;
            }
        }

        protected override void OnDispose()
        {
            UpdateManager.UnsubscribeFromUpdate(Update);
            _enemyFabric.Dispose();
        }


    }
}
