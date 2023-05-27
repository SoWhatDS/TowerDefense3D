using System.Collections;
using System.Collections.Generic;
using InGameConstants;
using Settings;
using UnityEngine;
using Utils;

namespace Game
{
    internal sealed class GameController : BaseController
    {
        private SettingsForGame _settings;
        private Transform _startPoint;

        public GameController(Transform startPoint, SettingsForGame settings)
        {
            _settings = settings;
            _startPoint = startPoint;
            LoadLevel();
        }

        private void LoadLevel()
        {
            GameObject prefab = ResourceLoader.LoadPrefab(GameConstants.LevelGamePath);
            GameObject objectView = Object.Instantiate(prefab, _startPoint.position, Quaternion.identity);
            AddGameObject(objectView);
        }
    }
}
