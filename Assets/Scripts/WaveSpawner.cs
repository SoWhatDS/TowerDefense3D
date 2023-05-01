using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform _enemyPrefab;
    [SerializeField] private float _timeBetweenWaves = 5f;
    [SerializeField] private float _countDown = 2f;
    [SerializeField] private int _waveIndex = 0;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private TMP_Text _waveCountDownText;


    private void Update()
    {
        if (_countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _countDown = _timeBetweenWaves;
        }
        _countDown -= Time.deltaTime;
        _waveCountDownText.text = Mathf.Round(_countDown).ToString();
    }

    IEnumerator SpawnWave()
    {
        _waveIndex++; 

        for (int i = 0; i < _waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(_enemyPrefab, _spawnPoint.position, _spawnPoint.rotation);
    }
}
