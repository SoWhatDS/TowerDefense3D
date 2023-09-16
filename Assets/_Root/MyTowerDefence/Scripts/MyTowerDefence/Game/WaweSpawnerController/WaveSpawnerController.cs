using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Settings;
using JoostenProductions;
using TMPro;
using Utils;

namespace Game
{
    internal sealed class WaveSpawnerController : BaseController
    {
        private WaveSpawnerModel _model;
        private EnemyFabric _enemyFabric;
        private WaveSpawnerView _waveSpawnerView;
        private TMP_Text _waveTimerText;
        private Profile _profile;

        private bool _isSpawning = false;
        private float _timer = 0.0f;

        private int _countEnemyOnWave = 0;
        private float _startCountDown = 5;
        private int _startWaveIndex = 0;

        private EnemyView _enemy;
        private Wave _wave;
        private int _enemiesAlive = 0;

        public WaveSpawnerController(SettingsContainer settingsContainer,EnemyFabric enemyFabric,WaveSpawnerView waveSpawnerView,Profile profile)
        {
            _model = settingsContainer.WaveSpawnerModel;
            _enemyFabric = enemyFabric;
            _waveTimerText = waveSpawnerView.WaveTimerText;
            _wave = _model.Waves[_model.WaveIndex];
            _profile = profile;
            UpdateManager.SubscribeToUpdate(WaveSpawner);
        }

        private void WaveSpawner()
        {
            if (_model.CountDown <= 0f && _isSpawning == false)
            {
                NextWave();
                return;
            }

            if (_isSpawning)
            {
                _timer += Time.deltaTime;
                _model.CountDown = 0.0f;

                if (_countEnemyOnWave == 0 && _enemyFabric.EnemiesAlive > 0)
                {
                    return;
                }
                else if (_enemyFabric.EnemiesAlive <= 0 && _countEnemyOnWave == 0)
                {

                    _isSpawning = false;
                    _model.WaveIndex++;
                    _model.CountDown = _model.TimeBetweenWaves;
                    return;

                }

                if (_timer >= _model.SpawnDelay)
                {
                    SpawnEnemy(_wave.Enemy);
                    _timer = 0.0f;
                }
            }

            _model.CountDown -= Time.deltaTime;
            _model.CountDown = Mathf.Clamp(_model.CountDown, 0f, Mathf.Infinity);

            _waveTimerText.text = string.Format("{0:00.00}", _model.CountDown);

        }

        private void NextWave()
        {
            if (_model.WaveIndex == _model.Waves.Length)
            {
                _profile.CurrentState.Value = GameState.LevelSelect;
            }
            _model.CountDown = _model.TimeBetweenWaves;
            _wave = _model.Waves[_model.WaveIndex];
            _countEnemyOnWave = _wave.Count;
            _isSpawning = true;
        }

        private void SpawnEnemy()
        {
          _countEnemyOnWave--;
          _enemy = _enemyFabric.CreateEnemy();
          AddGameObject(_enemy.gameObject);
          Debug.Log(_enemyFabric.EnemiesAlive);
        }

        private void SpawnEnemy(GameObject enemyPrefab)
        {
            _countEnemyOnWave--;
            _enemy = _enemyFabric.CreateEnemyFromWave(enemyPrefab);
            AddGameObject(_enemy.gameObject);
            Debug.Log(_enemyFabric.EnemiesAlive);
        }

        protected override void OnDispose()
        {
            UpdateManager.UnsubscribeFromUpdate(WaveSpawner);
            _model.WaveIndex = _startWaveIndex;
            _model.CountDown = _startCountDown;
        }
    }
}
    
