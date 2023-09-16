using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = nameof(EnemyModel),menuName = "Game/ " + nameof(EnemyModel))]
    public sealed class EnemyModel:ScriptableObject
    {
        [SerializeField] private float _enemySpeed;
        [SerializeField] private int _enemyHealth;
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private int _priceForEnemy;

        public float Speed => _enemySpeed;
        public int Health => _enemyHealth;
        public GameObject EnemyPrefab => _enemyPrefab;
        public int PriceForEnemy => _priceForEnemy;
    }
}
