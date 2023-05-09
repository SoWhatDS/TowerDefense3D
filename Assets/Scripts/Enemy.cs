
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public float _speed;
    [SerializeField] private float _health = 100;
    [SerializeField] private int _priceForEnemy = 50;
    [SerializeField] private GameObject _enemyDieEffect;
    public float _startSpeed;


    private void Start()
    {
        _speed = _startSpeed;    
    }

    public void TakeDamage(float amount)
    {
        _health -= amount;

        if (_health <= 0)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        _speed = _startSpeed * (1f - pct);
    }

    private void Die()
    {
        PlayerStats.Money += _priceForEnemy;
        GameObject dieEffect = (GameObject)Instantiate(_enemyDieEffect, transform.position, Quaternion.identity);
        Destroy(dieEffect, 2f);
        Destroy(gameObject);
    }


}
