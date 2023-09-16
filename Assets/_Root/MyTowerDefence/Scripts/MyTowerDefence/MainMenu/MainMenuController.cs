
using Settings;
using UnityEngine;
using Utils;
using InGameConstants;
using UnityEngine.SceneManagement;
using Game;

namespace UI
{
    internal sealed class MainMenuController : BaseController
    {
        private readonly Profile _profile;
        private readonly MainMenuView _view;
        private readonly Transform _startPoint;
        private Camera _mainCamera;
        private CameraView _cameraView;
        

        public MainMenuController(Transform startPoint,Profile profile)
        {
            _startPoint = startPoint;
            _profile = profile;
            _view = LoadView();
            _view.Init(Play,QuitGame);
            _mainCamera = Object.FindObjectOfType<Camera>();
            _cameraView = _mainCamera.GetComponent<CameraView>();
            _mainCamera.transform.position = _cameraView.StartPointForMainMenuCamera.position;
            _mainCamera.transform.rotation = _cameraView.StartPointForMainMenuCamera.rotation;
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
            _profile.CurrentState.Value = GameState.LevelSelect;
        }

        private void QuitGame()
        {
            _profile.CurrentState.Value = GameState.QuitGame;
        }
    }
}
