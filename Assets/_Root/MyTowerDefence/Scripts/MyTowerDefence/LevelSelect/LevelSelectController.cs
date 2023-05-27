using System.Collections;
using System.Collections.Generic;
using InGameConstants;
using Settings;
using UnityEngine;
using Utils;

namespace LevelSelect
{
    internal sealed class LevelSelectController : BaseController
    {
        private LevelSelectView _levelSelectView;
        private Transform _startPoint;
        private SettingsForGame _settings;

        public LevelSelectController(Transform startPoint,SettingsForGame settings)
        {
            _startPoint = startPoint;
            _settings = settings;
            _levelSelectView = LoadLevelSelectView();
            _levelSelectView.Init(SelectLevel);
        }

        private LevelSelectView LoadLevelSelectView()
        {
            GameObject prefab = ResourceLoader.LoadPrefab(GameConstants.LevelSelectPath);
            GameObject objectView = Object.Instantiate(prefab,_startPoint.position,Quaternion.identity);
            AddGameObject(objectView);
            return objectView.GetComponent<LevelSelectView>();
        }

        private void SelectLevel()
        {
            _settings.CurrentState.Value = GameState.StartGame;
        }
    }
}
