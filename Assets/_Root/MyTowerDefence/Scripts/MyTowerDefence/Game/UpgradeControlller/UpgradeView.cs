using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game
{
    public class UpgradeView : MonoBehaviour
    {
        [SerializeField] private Button _upgradeButton;
        [SerializeField] private Button _sellButton;

        private UnityAction _upgradeAction;
        private UnityAction _sellAction;

        internal void Init(UnityAction upgradeAction,UnityAction sellAction)
        {
            _upgradeAction = upgradeAction;
            _sellAction = sellAction;
            _upgradeButton.onClick.AddListener(_upgradeAction);
            _sellButton.onClick.AddListener(_sellAction);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            _upgradeButton.onClick.RemoveListener(_upgradeAction);
            _sellButton.onClick.RemoveListener(_sellAction);
        }
    }
}
