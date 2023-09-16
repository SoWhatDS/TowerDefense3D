
using JoostenProductions;
using UnityEngine;
using Utils;

namespace Game
{
    internal sealed class CameraView : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private Transform _startPointForGameCamera;
        [SerializeField] private Transform _startPointForMainMenuCamera;

        public Transform StartPointForGameCamera => _startPointForGameCamera;
        public Transform StartPointForMainMenuCamera => _startPointForMainMenuCamera;
    }
}
