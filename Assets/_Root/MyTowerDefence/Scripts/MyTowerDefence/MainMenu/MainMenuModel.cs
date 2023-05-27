using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ui
{
    [CreateAssetMenu(fileName = nameof(MainMenuModel),menuName = "UI/" + nameof(MainMenuModel))]
    public class MainMenuModel : ScriptableObject
    {
        [SerializeField] private GameObject _turretPrefab;
        [SerializeField] private GameObject _sceneFederPrefab;

        public GameObject TurretPrefab => _turretPrefab;
        public GameObject SceneFederPrefab => _sceneFederPrefab;
    }
}
