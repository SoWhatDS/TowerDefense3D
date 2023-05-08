
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _health = 100;
    [SerializeField] private int _priceForEnemy = 50;
    [SerializeField] private GameObject _enemyDieEffect;

    private Transform _target;
    private int _wavePointIndex = 0;

    private void Start()
    {
        _target = WayPoints.wayPoints[0];
    }

    private void Update()
    {
        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * _speed * Time.deltaTime,Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }
    }

    public void TakeDamage(int amount)
    {
        _health -= amount;

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStats.Money += _priceForEnemy;
        GameObject dieEffect = (GameObject)Instantiate(_enemyDieEffect, transform.position, Quaternion.identity);
        Destroy(dieEffect, 2f);
        Destroy(gameObject);
    }

    private void GetNextWayPoint()
    {
        if (_wavePointIndex >= WayPoints.wayPoints.Length - 1)
        {
            EndPath();
            return;
        }
        _wavePointIndex++;
        _target = WayPoints.wayPoints[_wavePointIndex];
    }

    private void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
