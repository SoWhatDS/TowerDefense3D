using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _impactEffect;
    private Transform _target;

    public void Seek(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = _target.position - transform.position;
        float distanceThisFrame = _speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame,Space.World);

    }

    private void HitTarget()
    {
        GameObject effectGO = Instantiate(_impactEffect, transform.position, transform.rotation);
        Destroy(effectGO, 2f);
        Destroy(_target.gameObject);
        Destroy(gameObject);

    }
}
