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
        private Profile _profile;

        public LevelSelectController(Transform startPoint,Profile profile)
        {
            _startPoint = startPoint;
            _profile = profile;
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
            _profile.CurrentState.Value = GameState.StartGame;
        }
    }
}
