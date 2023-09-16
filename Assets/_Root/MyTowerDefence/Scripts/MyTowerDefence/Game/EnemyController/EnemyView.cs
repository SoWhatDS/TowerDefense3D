using System.Collections;
using System.Collections.Generic;
using JoostenProductions;
using ObjectPool;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace Game
{
    internal sealed class EnemyView : MonoBehaviour
    {
        [SerializeField] private Image _healthImage;

        private float _speed;
        private float _health;
        private float _startHealth;
        private int _priceForEnemy;
        private float _minDistanceToTarget = 0.2f;
        public Transform _target;
        private int _wayPointIndex = 0;
        private Transform[] _wayPoints;
        private PlayerStatisticsModel _playerStatisticsModel;
        private EnemyModel _enemyModel;
        private float _startSpeed;
        private float _enemySpeed;
        public bool IsDeath;


        public void init(EnemyModel enemyModel, Transform[] wayPoints,PlayerStatisticsModel playerStatisticsModel)
        {
            _enemyModel = enemyModel;
            _wayPoints = wayPoints;
            _priceForEnemy = _enemyModel.PriceForEnemy;
            _target = _wayPoints[0];
            _playerStatisticsModel = playerStatisticsModel;
            _startSpeed = enemyModel.Speed;
            _startHealth = enemyModel.Health;
            _health = _startHealth;
            _enemySpeed = _startSpeed;
        }

        public void Move()
        {
            Transform enemyTransform = transform;

            Vector3 direction = _target.position - enemyTransform.position;
            enemyTransform.Translate(direction.normalized * _enemySpeed * Time.deltaTime, Space.World);

            if (Vector3.Distance(enemyTransform.position, _target.position) <= _minDistanceToTarget)
            {
                ChangeTarget();
            }

            _enemySpeed = _startSpeed;
        }

        public void TakeDamage(float damage)
        {
            _health -= damage;
            _healthImage.fillAmount = _health / _startHealth;
            if (_health <= 0)
            {
                _playerStatisticsModel.Money += _priceForEnemy;
                Death();
            }
        }

        public void Slow(float pct)
        {
            _enemySpeed = _startSpeed * (1f - pct); 
        }

        private void ChangeTarget()
        {
            if (_wayPointIndex >= _wayPoints.Length - 1)
            {
                IsDeath = true;
                _playerStatisticsModel.Lives--;
                Death();
                return;
            }
            _wayPointIndex++;
            _target = _wayPoints[_wayPointIndex];
        }

        public void Death()
        {
            IsDeath = true;
            _wayPointIndex = 0;
            _healthImage.fillAmount = _startHealth;
            
        }

    }
}
