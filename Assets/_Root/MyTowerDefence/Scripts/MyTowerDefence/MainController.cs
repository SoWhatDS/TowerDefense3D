
using Settings;
using UI;
using UnityEngine;
using Utils;
using LevelSelect;
using Game;
using Tools;

internal sealed class MainController : BaseController
{
    private readonly Profile _profile;
    private readonly Transform _startPoint;
    private readonly SettingsContainer _settings;
    private readonly SceneFaderView _sceneFader;

    private MainMenuController _mainMenuController;
    private GameController _gameController;
    private LevelSelectController _levelSelectController;

    public MainController(Transform startPoint,Profile profile,SettingsContainer settings,SceneFaderView sceneFaderView)
    {
        _settings = settings;
        _profile = profile;
        _startPoint = startPoint;
        _sceneFader = sceneFaderView;
        _profile.CurrentState.SubscribeOnChange(OnChangeGameState);
        OnChangeGameState(_profile.CurrentState.Value);
    }

    private void OnChangeGameState(GameState state)
    {
        DisposeAllControllers();

        switch (state)
        {
            case GameState.MainMenu:
                _sceneFader.FadeInScene();
                _mainMenuController = new MainMenuController(_startPoint,_profile);
                break;
            case GameState.StartGame:
                _sceneFader.FadeInScene();
                _gameController = new GameController(_startPoint,_profile,_settings);
                break;
            case GameState.LevelSelect:
                _sceneFader.FadeInScene();
                _levelSelectController = new LevelSelectController(_startPoint,_profile);
                break;
            default:
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                _levelSelectController?.Dispose();
                break;
        }
    }

    private void DisposeAllControllers()
    {
        _gameController?.Dispose();
        _levelSelectController?.Dispose();
        _mainMenuController?.Dispose();
    }

    protected override void OnDispose()
    {
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
        _levelSelectController?.Dispose();
        _profile.CurrentState.UnSubcribeOnChange(OnChangeGameState);
    }
}
