using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = nameof(AllTurretsInGameModel),menuName = "Game/ " + nameof(AllTurretsInGameModel))]
    public class AllTurretsInGameModel : ScriptableObject
    {
        [SerializeField] private List<TurretModel> _allTurretsInGame;

        private GameObject _standartTurretPrefab;
        private GameObject _missleTurretPrefab;
        private GameObject _towerTurretPrefab;
        private GameObject _laserBeamerTurretPrefab;  

        public TurretModel _turretModelToBuild = null;

        public TurretModel TurretModelToBuild => _turretModelToBuild;

        public GameObject StandartTurretPrefab => _standartTurretPrefab;
        public GameObject MissleTurretPrefab => _missleTurretPrefab;
        public GameObject TowerTurretPrefab => _towerTurretPrefab;
        public GameObject LaserBeamerPrefab => _laserBeamerTurretPrefab;

        public void SelectTurretModelToBuild(TypeTurret typeTurret)
        {
            for (int i = 0; i < _allTurretsInGame.Count; i++)
            {
                if (typeTurret == _allTurretsInGame[i].TypeTurret)
                {
                    _turretModelToBuild = _allTurretsInGame[i];
                }
            }
        }

        public GameObject GetTurretPrefab()
        {
            switch (_turretModelToBuild.TypeTurret)
            {
                case  TypeTurret.StandartTurret:
                   return _standartTurretPrefab = _turretModelToBuild.TurretPrefab;
                case TypeTurret.MissleTurret:
                    return _missleTurretPrefab = _turretModelToBuild.TurretPrefab;
                case TypeTurret.TowerTurret:
                    return _towerTurretPrefab = _turretModelToBuild.TurretPrefab;
                case TypeTurret.LaserBeamerTurret:
                    return _laserBeamerTurretPrefab = _turretModelToBuild.TurretPrefab;
                default:
                    return null;      
            }
        }
    }
}
