
using UnityEngine;
using Utils;

namespace Settings
{
    internal sealed class SettingsForGame 
    {
        public readonly SubscriptionProperty<GameState> CurrentState;

        public SettingsForGame(GameState initialState)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentState.Value = initialState;
        }
    }
}
