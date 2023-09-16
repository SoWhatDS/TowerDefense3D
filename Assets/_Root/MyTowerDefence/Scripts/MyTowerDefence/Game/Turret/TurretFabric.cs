using System;
using System.Collections;
using System.Collections.Generic;
using ObjectPool;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game
{
    internal sealed class TurretFabric 
    {
        private IViewServices _viewservices;
        private LevelView _levelView;
        private List<TurretView> _turrets;
        private TurretView _turret;
        private AllTurretsInGameModel _allTurretsModelInGame;
        private TurretModel _turretModelToBuild;

        public List<TurretView> Turrets => _turrets;

        public TurretFabric(IViewServices viewServices,AllTurretsInGameModel allTurretsModel,LevelView levelView)
        {
            _turrets = new List<TurretView>();
            _viewservices = viewServices;
            _levelView = levelView;
            _allTurretsModelInGame = allTurretsModel;
        }

        public TurretView BuildTurret(Transform transform)
        {
            _turretModelToBuild = _allTurretsModelInGame.TurretModelToBuild;
            _turretModelToBuild.IsUpgradable = false;
            _turret = _viewservices.Instantiate<TurretView>(_turretModelToBuild.TurretPrefab, transform.position + _turretModelToBuild.OffSetToBuild);
            _turret.Init(_turretModelToBuild, _viewservices);
            _turrets.Add(_turret);
            return _turret;          
        }

        public TurretView BuildUpgradeTurret(TurretView selectedTurret)
        {
            _turret = selectedTurret;
            _turrets.Remove(_turret);
            _viewservices.Destroy(selectedTurret.gameObject);
            TurretModel selectedTurretModel = _turret.GetTurretModel();
            selectedTurretModel.IsUpgradable = true;
            _turret = _viewservices.Instantiate<TurretView>(selectedTurretModel.UpgradeTurretPrefab, _turret.transform.position);
            _turret.Init(selectedTurretModel,_viewservices);
            _turrets.Add(_turret);
            return _turret;
        }

        public void SellTurret(TurretView selectedTurret)
        {
            _viewservices.Destroy(selectedTurret.gameObject);
            _turrets.Remove(selectedTurret);
        }

        public void Dispose()
        {
            for (int i = 0; i < _turrets.Count; i++)
            {
                Object.Destroy(_turrets[i].gameObject);
                _viewservices.Dispose(_turrets[i].gameObject);
            }
        }
    }
}
