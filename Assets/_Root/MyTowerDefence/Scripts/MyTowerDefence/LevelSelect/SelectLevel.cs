using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    [Serializable]
    internal class SelectLevel 
    {
        public Button selectLevelButton;
        public LevelView levelToLoad;
    }
}
