
using Settings;
using UnityEngine;
using Utils;
using InGameConstants;
using UnityEngine.SceneManagement;

namespace UI
{
    internal sealed class MainMenuController : BaseController
    {
        private readonly SettingsForGame _settings;
        private readonly MainMenuView _view;
        private readonly Transform _startPoint;

        public MainMenuController(Transform startPoint,SettingsForGame settings)
        {
            _startPoint = startPoint;
            _settings = settings;
            _view = LoadView();
            _view.Init(Play,QuitGame);
        
        }

        private MainMenuView LoadView()
        {
            GameObject prefab = ResourceLoader.LoadPrefab(GameConstants.MainMenuPath);
            GameObject objectView = Object.Instantiate(prefab, _startPoint.position, Quaternion.identity);
            AddGameObject(objectView);
            return objectView.GetComponent<MainMenuView>();
        }

        private void Play()
        {
            _settings.CurrentState.Value = GameState.LevelSelect;
        }

        private void QuitGame()
        {
            _settings.CurrentState.Value = GameState.QuitGame;
        }
    }
}
