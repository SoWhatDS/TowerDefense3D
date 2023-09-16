using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    internal sealed class ShopController : BaseController
    {
        private AllTurretsInGameModel _allTurretsModelInGame;
        private ShopView _shopView;

        public ShopController(LevelView levelView,AllTurretsInGameModel allTurretsModelInGame)
        {
            _allTurretsModelInGame = allTurretsModelInGame;
            _shopView = levelView.ShopView;
            _shopView.Init(SelectStandartTurret,SelectMissleTurret,SelectTowerTurret,SelectLaserBeamerTurret);
        }

        private void SelectStandartTurret()
        {
            _allTurretsModelInGame.SelectTurretModelToBuild(TypeTurret.StandartTurret);
        }

        private void SelectMissleTurret()
        {
            _allTurretsModelInGame.SelectTurretModelToBuild(TypeTurret.MissleTurret);
        }

        private void SelectTowerTurret()
        {
            _allTurretsModelInGame.SelectTurretModelToBuild(TypeTurret.TowerTurret);
        }

        private void SelectLaserBeamerTurret()
        {
            _allTurretsModelInGame.SelectTurretModelToBuild(TypeTurret.LaserBeamerTurret);
        }
    }
}
