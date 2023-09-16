
using UnityEngine;
using Utils;

namespace Settings
{
    internal sealed class Profile
    {
        public readonly SubscriptionProperty<GameState> CurrentState;

        public Profile(GameState initialState)
        {
            CurrentState = new SubscriptionProperty<GameState>();
            CurrentState.Value = initialState;
        }
    }
}
