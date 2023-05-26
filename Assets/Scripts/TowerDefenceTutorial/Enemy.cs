
using System;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public float _speed;
    [SerializeField] private float _startHealth = 100;
    [SerializeField] private int _priceForEnemy = 50;
    [SerializeField] private GameObject _enemyDieEffect;
    public float _startSpeed;
    public Image healthBar;
    private float health;
    private bool isDead = false;


    private void Start()
    {
        _speed = _startSpeed;
        health = _startHealth;
        Debug.Log(health);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health/_startHealth;

        if (health <= 0 && !isDead)
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
        isDead = true;
        PlayerStats.Money += _priceForEnemy;
        GameObject dieEffect = (GameObject)Instantiate(_enemyDieEffect, transform.position, Quaternion.identity);
        Destroy(dieEffect, 2f);
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }


}
