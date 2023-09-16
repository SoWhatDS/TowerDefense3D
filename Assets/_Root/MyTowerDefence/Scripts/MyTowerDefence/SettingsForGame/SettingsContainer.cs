
using Game;
using Tools;
using UnityEngine;
using Utils;

namespace Settings
{
    [CreateAssetMenu(fileName = nameof(SettingsContainer),menuName ="Settings/ "+ nameof(SettingsContainer))]
    public class SettingsContainer : ScriptableObject
    {
        [Header("Settings for Camera Controller")]
        [SerializeField] private CameraModel _cameraModel;

        [Header("Settings for Enemy Controller")]
        [SerializeField] private EnemyModel _enemyModel;

        [Header("Settings for WaveSpawner Controller")]
        [SerializeField] private WaveSpawnerModel _waveSpawnerModel;

        [Header("Settings for Player Statistics")]
        [SerializeField] private PlayerStatisticsModel _playerStatisticsModel;

        [Header("Settings for All Turret In Game")]
        [SerializeField] private AllTurretsInGameModel _allTurretsInGameModel;


        public CameraModel CameraModel => _cameraModel;
        public EnemyModel EnemyModel => _enemyModel;
        public WaveSpawnerModel WaveSpawnerModel => _waveSpawnerModel;
        public PlayerStatisticsModel PlayerStatisticsModel => _playerStatisticsModel;
        public AllTurretsInGameModel AllTurretsInGameModel => _allTurretsInGameModel;
    }
}
