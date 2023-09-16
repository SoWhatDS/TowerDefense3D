using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Game
{
    internal sealed class ProfileLevelSelect 
    {
        public readonly SubscriptionProperty<LevelState> CurrentLevelState;

        public ProfileLevelSelect(LevelState LevelState)
        {
            CurrentLevelState = new SubscriptionProperty<LevelState>();
            CurrentLevelState.Value = LevelState;
        }
    }
}
