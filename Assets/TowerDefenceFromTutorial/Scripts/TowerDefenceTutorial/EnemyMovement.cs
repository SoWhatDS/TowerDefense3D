using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform _target;
    private int _wavePointIndex = 0;
    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _target = WayPoints.wayPoints[0];
    }

    private void Update()
    {
        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * _enemy._speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _target.position) <= 0.4f)
        {
            GetNextWayPoint();
        }
        _enemy._speed = _enemy._startSpeed;
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
        WaveSpawner.EnemiesAlive--;
    }
}
