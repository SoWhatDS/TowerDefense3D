using System.Collections;
using System.Collections.Generic;
using InGameConstants;
using ObjectPool;
using Settings;
using UnityEngine;
using Utils;

namespace Game
{
    internal sealed class GameController : BaseController
    {
        private Profile _profile;
        private Transform _startPoint;
        private CameraModel _cameraModel;
        private LevelView _levelView;
        private SettingsContainer _settings;

        private EnemyFabric _enemyFabric;
        private TurretFabric _turretFabric;
        private IViewServices _viewServices;

        private CameraController _cameraController;
        private LevelController _levelController;
        private EnemyController _enemyController;
        private WaveSpawnerController _waveSpawnerController;
        private TurretController _turretController;
        private BuildController _buildController;
        private ShopController _shopController;
        private PlayerStatiscicsController _playerStatisticsController;
        private UpgradeController _upgradeController;
        private PauseController _pauseController;

        private ProfileLevelSelect _profileLevelSelect;

        public GameController(Transform startPoint, Profile profile,SettingsContainer settings)
        {
            _startPoint = startPoint;
            _profile = profile;
            _settings = settings;
            _cameraModel = settings.CameraModel;
            _levelView = LoadLevel();
            _viewServices = new ViewServices();
            _enemyFabric = new EnemyFabric(_settings, _levelView,_viewServices);
            _turretFabric = new TurretFabric(_viewServices,_settings.AllTurretsInGameModel,_levelView);

            CreateControllers();
        }

        private LevelView LoadLevel()
        {
            GameObject prefab = ResourceLoader.LoadPrefab(GameConstants.LevelGamePath);
            GameObject objectView = Object.Instantiate(prefab, _startPoint.position, Quaternion.identity);
            AddGameObject(objectView);
            return objectView.GetComponent<LevelView>();
        }

        private void CreateControllers()
        {
            _cameraController = new CameraController(_cameraModel);
            AddControllers(_cameraController);

            _levelController = new LevelController();
            AddControllers(_levelController);

            _waveSpawnerController = new WaveSpawnerController(_settings, _enemyFabric,_levelView.WaveSpawnerView,_profile);
            AddControllers(_waveSpawnerController);

            _enemyController = new EnemyController(_enemyFabric,_viewServices);
            AddControllers(_enemyController);

            _turretController = new TurretController(_turretFabric,_enemyFabric);
            AddControllers(_turretController);

           _playerStatisticsController = new PlayerStatiscicsController(_settings.PlayerStatisticsModel,
                _settings.AllTurretsInGameModel,_levelView.PlayerStatisticsView,_profile);
            AddControllers(_playerStatisticsController);

            _buildController = new BuildController(_turretFabric,_levelView,_settings.PlayerStatisticsModel);
            AddControllers(_buildController);

            _shopController = new ShopController(_levelView,_settings.AllTurretsInGameModel);
            AddControllers(_shopController);
            
            _upgradeController = new UpgradeController(_levelView,_turretFabric,_settings.PlayerStatisticsModel);
            AddControllers(_upgradeController);

            _pauseController = new PauseController(_levelView,_profile);
            AddControllers(_pauseController);

        }

        protected override void OnDispose()
        {
            _cameraController?.Dispose();
            _levelController?.Dispose();
            _enemyController?.Dispose();
            _waveSpawnerController?.Dispose();
            _turretController?.Dispose();
            _buildController?.Dispose();
            _shopController?.Dispose();
            _playerStatisticsController?.Dispose();
            _upgradeController?.Dispose();
            _pauseController?.Dispose();
        }
    }
}
