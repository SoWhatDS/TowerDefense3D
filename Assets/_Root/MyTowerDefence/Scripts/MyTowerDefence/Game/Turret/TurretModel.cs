using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = nameof(TurretModel), menuName = "Game/ " + nameof(TurretModel))]
    public sealed class TurretModel : ScriptableObject
    {
        [Header("Attributes for turret")]
        [SerializeField] private float _range;
        [SerializeField] private float _turnSpeed;

        [Header("Attributes for build turret")]
        [SerializeField] private TypeTurret _typeTurret;
        [SerializeField] private GameObject _turretPrefab;
        [SerializeField] private int _price;
        [SerializeField] private Vector3 _offsetToBuild;
        public bool IsCanBuild;

        [Header("Attributes for bullet")]
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private GameObject _bulletImpactEffect;
        [SerializeField] private int _bulletDamage;

        [SerializeField] private bool _isUseLaser;
        [SerializeField] private LineRenderer _lineRenderer;

        [Header("Attributes for upgrade")]
        [SerializeField] private GameObject _upgradeTurretPrefab;
        [SerializeField] private int _upgradeCost;
        [SerializeField] private int _sellTurretCost;
        [SerializeField] private int _sellUpgradableTurretCost;

        public bool IsUpgradable;
        
        public float Range => _range;
        public float TurnSpeed => _turnSpeed;

        public TypeTurret TypeTurret => _typeTurret;
        public GameObject TurretPrefab => _turretPrefab;
        public int Price => _price;
        public Vector3 OffSetToBuild => _offsetToBuild;

        public GameObject BulletPrefab => _bulletPrefab;
        public float BulletSpeed => _bulletSpeed; 
        public GameObject BulletImpactEffect => _bulletImpactEffect;
        public int BulletDamage => _bulletDamage;

        public bool IsUseLaser => _isUseLaser;
        public LineRenderer LineRenderer => _lineRenderer;

        public GameObject UpgradeTurretPrefab => _upgradeTurretPrefab;
        public int UpgradeCost => _upgradeCost;
        public int SellTurretCost => _sellTurretCost;
        public int SellUpgradableTurretCost => _sellUpgradableTurretCost;
    }
}
