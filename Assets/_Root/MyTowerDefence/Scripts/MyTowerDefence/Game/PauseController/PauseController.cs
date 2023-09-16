using System.Collections;
using System.Collections.Generic;
using JoostenProductions;
using Settings;
using UnityEngine;
using Utils;

namespace Game
{
    internal class PauseController : BaseController
    {
        private LevelView _levelView;
        private PauseMenuView _pauseMenuView;
        private Profile _profile;

        public PauseController(LevelView levelView,Profile profile)
        {
            _levelView = levelView;
            _pauseMenuView = _levelView.PauseMenuView;
            _pauseMenuView.Init(Retry, ExitToMainMenu,ContinueGame);
            _profile = profile;
            UpdateManager.SubscribeToUpdate(PauseUpdate);
        }

        private void PauseUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
            {
                _pauseMenuView.Toggle();
            }
        }

        private void Retry()
        {
            _profile.CurrentState.Value = GameState.StartGame;
        }

        private void ExitToMainMenu()
        {
            _profile.CurrentState.Value = GameState.MainMenu;
        }

        private void ContinueGame()
        {
            _pauseMenuView.Toggle();
        }

        protected override void OnDispose()
        {
            UpdateManager.UnsubscribeFromUpdate(PauseUpdate);
        }
    }
}
