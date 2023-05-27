
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    internal class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _quitGameButton;

        private UnityAction _startGameAction;
        private UnityAction _quitGameAction;

        public void Init(UnityAction startGameAction,UnityAction quitGameAction)
        {
            _startGameAction = startGameAction;
            _quitGameAction = quitGameAction;
            _startGameButton.onClick.AddListener(_startGameAction);
            _quitGameButton.onClick.AddListener(_quitGameAction);
        }

        private void OnDestroy()
        {
            _startGameButton.onClick.RemoveListener(_startGameAction);
            _quitGameButton.onClick.RemoveListener(_quitGameAction);
        }
    }
}
