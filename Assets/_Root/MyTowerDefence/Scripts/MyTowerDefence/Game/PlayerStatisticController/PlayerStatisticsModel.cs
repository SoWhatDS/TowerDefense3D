using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = nameof(PlayerStatisticsModel),menuName = "PlayerStatistics/ " + nameof(PlayerStatisticsModel))]
    public class PlayerStatisticsModel : ScriptableObject
    {
        [SerializeField] private int _money = 500;
        [SerializeField] private int _lives = 5;
        [SerializeField] private int _rounds;

        public Action<TurretModel> OnCheckMoneyForUpgrade;
        public Action OnCheckMoneyForBuild;
        public Action<TurretModel> OnSellTurret;

        public bool NotEnoughMoney = false;

        public int Money { get; set; }
        public int Lives { get; set; }
        public int Rounds { get; set; }

    }
}
