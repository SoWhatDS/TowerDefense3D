
using Settings;
using UI;
using UnityEngine;
using Utils;
using LevelSelect;
using Game;

internal sealed class MainController : BaseController
{
    private readonly SettingsForGame _settings;
    private readonly Transform _startPoint;

    private MainMenuController _mainMenuController;
    private GameController _gameController;
    private LevelSelectController _levelSelectController;

    public MainController(Transform startPoint,SettingsForGame settingsForGame)
    {
        _settings = settingsForGame;
        _startPoint = startPoint;
        _settings.CurrentState.SubscribeOnChange(OnChangeGameState);
        OnChangeGameState(_settings.CurrentState.Value);
    }

    protected override void OnDispose()
    {
        _mainMenuController ?.Dispose();
        _gameController ?.Dispose();
        _levelSelectController?.Dispose();
        _settings.CurrentState.UnSubcribeOnChange(OnChangeGameState);
    }

    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.MainMenu:
                _mainMenuController = new MainMenuController(_startPoint,_settings);
                _gameController?.Dispose();
                _levelSelectController?.Dispose();
                break;
            case GameState.StartGame:
                _gameController = new GameController(_startPoint,_settings);
                _mainMenuController?.Dispose();
                _levelSelectController?.Dispose();
                break;
            case GameState.LevelSelect:
                _levelSelectController = new LevelSelectController(_startPoint,_settings);
                _mainMenuController?.Dispose();
                break;
            default:
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                _levelSelectController?.Dispose();
                break;
        }
    }
}
