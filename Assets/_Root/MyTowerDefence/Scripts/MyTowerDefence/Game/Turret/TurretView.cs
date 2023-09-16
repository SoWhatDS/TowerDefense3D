using System.Collections;
using System.Collections.Generic;
using ObjectPool;
using UnityEngine;

namespace Game
{
    internal sealed class TurretView : MonoBehaviour
    {
        [SerializeField] private Transform _partToRotate;
        [SerializeField] private Transform _firePoint;
        //Laser in Model
        [SerializeField] private bool _isUseLaser;
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private GameObject _laserImpact;
        [SerializeField] private int _damageOverTime;
        [SerializeField] private float _slowPercent;

        private float _distanceToEnemy;
        private float _shortestDistance;
        private EnemyView _nearestEnemy;
        private EnemyView _targetEnemy;
        public Transform _target;

        private float _range;
        private float _rotateSpeed;

        private float _fireRate = 1f;
        private float _fireCountDown = 0f;

        private IViewServices _viewServices;
        private GameObject _bulletPrefab;
        private GameObject _bulletImpact;
        private float _speedBullet;
        private int _bulletDamage;

        private TurretModel _turretModel;

        public void Init(TurretModel turretModel, IViewServices viewServices)
        {
            _range = turretModel.Range;
            _rotateSpeed = turretModel.TurnSpeed;
            _viewServices = viewServices;
            _bulletPrefab = turretModel.BulletPrefab;
            _speedBullet = turretModel.BulletSpeed;
            _bulletDamage = turretModel.BulletDamage;
            _bulletImpact = turretModel.BulletImpactEffect;
            _turretModel = turretModel;
        }

        public void CheckDistanceToTarget(List<EnemyView> enemies)
        {
            _shortestDistance = Mathf.Infinity;
            _nearestEnemy = null;

            for (int i = 0; i < enemies.Count; i++)
            {
                _distanceToEnemy = Vector3.Distance(transform.position, enemies[i].transform.position);

                if (_distanceToEnemy < _shortestDistance)
                {
                    _shortestDistance = _distanceToEnemy;
                    _nearestEnemy = enemies[i];
                }
            }
        }

        public void Shoot()
        {
            if (_target == null)
            {
                if (_isUseLaser)
                {
                    if (_lineRenderer.enabled)
                    {
                        _lineRenderer.enabled = false;
                        _laserImpact.SetActive(false);
                    }
                }
                return;
            }

            if (_isUseLaser)
            {
                Laser();
            }
            else
            {
                if (_fireCountDown <= 0)
                {
                    Fire();
                    _fireCountDown = 1f / _fireRate;
                }
                _fireCountDown -= Time.deltaTime;
            }
        }

        public void ChangeTarget()
        {
            if (_nearestEnemy != null && _shortestDistance <= _range)
            {
                _target = _nearestEnemy.transform;
                _targetEnemy = _nearestEnemy;
                RotateTurret();
            }
            else
            {
                _target = null;
            }
        }

        private void Laser()
        {
            Vector3 direction = _firePoint.position - _target.position;
            _lineRenderer.enabled = true;
            _lineRenderer.SetPosition(0, _firePoint.position);
            _lineRenderer.SetPosition(1, _target.position);           
            _laserImpact.SetActive(true);
            _laserImpact.transform.position = _target.position + direction.normalized * 0.5f;
            _laserImpact.transform.rotation = Quaternion.LookRotation(direction);
            _targetEnemy.TakeDamage(_damageOverTime * Time.deltaTime);
            _targetEnemy.Slow(_slowPercent);
        }

        private void Fire()
        {
            BulletView bullet = _viewServices.Instantiate<BulletView>(_bulletPrefab, _firePoint.position);
            bullet.Init(_speedBullet,_viewServices,_bulletDamage,_bulletImpact);
            bullet.TakeTarget(_target);
        }
        

        private void RotateTurret()
        {
            Vector3 direction = _target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Vector3 rotation = Quaternion.Lerp(_partToRotate.rotation, lookRotation, Time.deltaTime * _rotateSpeed).eulerAngles;
            _partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }

        public TurretModel GetTurretModel()
        {
            return _turretModel;
        }

    }
}
