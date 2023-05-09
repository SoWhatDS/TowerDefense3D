using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{ 
    [SerializeField] private float _range = 15f;
    [SerializeField] private Transform _partToRotate;
    [SerializeField] private float _turnSpeed;
    [SerializeField] private float _fireRate;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private bool _useLaser = false;
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private ParticleSystem _impactEffect;
    [SerializeField] private Light _impactLight;
    [SerializeField] private int _damageOverTime;
    [SerializeField] private float _slowPct;

    private float _fireCountDown = 0f;
    private Transform _target;
    private string _enemyTag = "Enemy";
    private Enemy _targetEnemy;
    

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void Update()
    {
        if (_target == null)
        {
            if (_useLaser)
            {
                if (_lineRenderer.enabled)
                {
                    _lineRenderer.enabled = false;
                    _impactEffect.Stop();
                    _impactLight.enabled = false;
                }
                    
            }
            return;
        }

        LockOnTarget();

        if (_useLaser)
        {
            Laser();
        }
        else
        {
            if (_fireCountDown <= 0f)
            {
                Shoot();
                _fireCountDown = 1f / _fireRate;
            }

            _fireCountDown -= Time.deltaTime;
        }

    }

    private void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(_target);
        }
    }

    private void Laser()
    {
        _targetEnemy.TakeDamage(_damageOverTime * Time.deltaTime);
        _targetEnemy.Slow(_slowPct);

        if (!_lineRenderer.enabled)
        {
            _lineRenderer.enabled = true;
            _impactEffect.Play();
            _impactLight.enabled = true;
        }
        _lineRenderer.SetPosition(0, _firePoint.position);
        _lineRenderer.SetPosition(1, _target.position);

        Vector3 direction = _firePoint.position - _target.position;
        _impactEffect.transform.position = _target.position + direction.normalized;
        _impactEffect.transform.rotation = Quaternion.LookRotation(direction); 
        
    }

    private void LockOnTarget()
    {
        Vector3 direction = _target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(_partToRotate.rotation, lookRotation, Time.deltaTime * _turnSpeed).eulerAngles;
        _partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(_enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (var enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= _range)
        {
            _target = nearestEnemy.transform;
            _targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            _target = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);      
    }

}
