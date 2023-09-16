using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [Serializable]
    internal sealed class TurretBluePrint 
    {
        [SerializeField] private GameObject _turretPrefab;
        [SerializeField] private int _cost;
    }
}
