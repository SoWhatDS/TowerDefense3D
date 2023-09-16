
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game
{
    internal sealed class ShopView : MonoBehaviour
    {
        [SerializeField] private Button _selectStandartTurretButton;
        [SerializeField] private Button _selectMissleTurretButton;
        [SerializeField] private Button _selectTowerTurretButton;
        [SerializeField] private Button _selectLaserBeamerButton;

        private UnityAction _selectStandartTurret;
        private UnityAction _selectMissleTurret;
        private UnityAction _selectTowerTurret;
        private UnityAction _selectLaserBeamerTurret;

        public void Init(UnityAction selectStandartTurret, UnityAction selectMissleTurret, UnityAction selectTowerTurret,UnityAction selectLaserBeamerTurret)
        {
            _selectStandartTurret = selectStandartTurret;
            _selectMissleTurret = selectMissleTurret;
            _selectTowerTurret = selectTowerTurret;
            _selectLaserBeamerTurret = selectLaserBeamerTurret;

            _selectStandartTurretButton.onClick.AddListener(_selectStandartTurret);
            _selectMissleTurretButton.onClick.AddListener(_selectMissleTurret);
            _selectTowerTurretButton.onClick.AddListener(_selectTowerTurret);
            _selectLaserBeamerButton.onClick.AddListener(_selectLaserBeamerTurret);
        }

        private void OnDestroy()
        {
            _selectStandartTurretButton.onClick.RemoveListener(_selectStandartTurret);
            _selectMissleTurretButton.onClick.RemoveListener(_selectMissleTurret);
            _selectTowerTurretButton.onClick.RemoveListener(_selectTowerTurret);
            _selectLaserBeamerButton.onClick.RemoveListener(_selectLaserBeamerTurret);
        }


    }
}
