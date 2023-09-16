using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Game
{
    [CreateAssetMenu(fileName = nameof(CameraModel),menuName = "Game/ " + nameof(CameraModel))]
    public class CameraModel : ScriptableObject
    {
        [SerializeField] private float _panBorderThickness;
        [SerializeField] private float _scrollSpeed;
        [SerializeField] private float _minY;
        [SerializeField] private float _maxY;
        [SerializeField] private float _cameraSpeed;

        public float MinY => _minY;
        public float MaxY => _maxY;

        public float CameraSpeed => _cameraSpeed;

        public float PanBorderThickness => _panBorderThickness;

        public float ScrollSpeed => _scrollSpeed;

    }
}
