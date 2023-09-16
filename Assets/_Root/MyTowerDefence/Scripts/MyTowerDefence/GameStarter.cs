
using Settings;
using Tools;
using UnityEngine;
using Utils;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private SettingsContainer _settings;
    [SerializeField] private SceneFaderView _sceneFader;

    private const GameState InitialState = GameState.MainMenu;

    private MainController _mainController;

    private void Start()
    {
        var profile = new Profile(InitialState);
        _mainController = new MainController(_startPoint,profile,_settings,_sceneFader);
    }

    private void OnDestroy()
    {
        _mainController.Dispose();
    }
}
