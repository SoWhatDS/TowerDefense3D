
using Settings;
using UnityEngine;
using Utils;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;

    private const GameState InitialState = GameState.MainMenu;

    private MainController _mainController;

    private void Start()
    {
        var settingsForGame = new SettingsForGame(InitialState);
        _mainController = new MainController(_startPoint,settingsForGame);
    }

    private void OnDestroy()
    {
        _mainController.Dispose();
    }
}
