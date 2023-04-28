
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

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

    private void GetNextWayPoint()
    {
        if (_wavePointIndex >= WayPoints.wayPoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        _wavePointIndex++;
        _target = WayPoints.wayPoints[_wavePointIndex];
    }
}
