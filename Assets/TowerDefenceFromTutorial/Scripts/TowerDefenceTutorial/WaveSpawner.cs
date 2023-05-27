using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    [SerializeField] private float _timeBetweenWaves = 5f;
    [SerializeField] private float _countDown = 2f;
    [SerializeField] private int _waveIndex = 0;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private TMP_Text _waveCountDownText;

    public static int EnemiesAlive = 0;
    public LivesManager livesManager;


    private void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (_waveIndex == waves.Length)
        {
            livesManager.WinLevel();
            this.enabled = false;
        }

        if (_countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countDown = _timeBetweenWaves;
            return;
        }
        _countDown -= Time.deltaTime;
        _countDown = Mathf.Clamp(_countDown, 0f, Mathf.Infinity);
        _waveCountDownText.text = string.Format("{0:00.00}", _countDown);
    }

    IEnumerator SpawnWave()
    {
  
        PlayerStats.Rounds++;
        Wave wave = waves[_waveIndex];

        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }
        _waveIndex++;

       
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, _spawnPoint.position, _spawnPoint.rotation);
    }
}
