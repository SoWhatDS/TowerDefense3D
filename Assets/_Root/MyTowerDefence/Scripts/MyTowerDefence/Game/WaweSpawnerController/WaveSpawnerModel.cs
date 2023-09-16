
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = nameof(WaveSpawner),menuName = "Game/ " + nameof(WaveSpawner))]
    public class WaveSpawnerModel : ScriptableObject
    {
        [SerializeField] private float _timeBetweenWaves = 5f;
        [SerializeField] private float _countDown = 2f;
        [SerializeField] private int _waveIndex = 0;
        [SerializeField] private float _spawnDelay = 0.5f;
        [SerializeField] private Wave[] _waves;

        public float TimeBetweenWaves { get => _timeBetweenWaves; set => _timeBetweenWaves = value; }
        public float CountDown { get => _countDown; set => _countDown = value; }
        public int WaveIndex { get => _waveIndex; set => _waveIndex = value; }
        public float SpawnDelay { get => _spawnDelay; set => _spawnDelay = value; }
        public Wave[] Waves => _waves;
    }
}
