
using InGameConstants;
using JoostenProductions;
using UnityEngine;
using UnityEngine.UIElements;
using Utils;

namespace Game
{
    internal sealed class CameraController : BaseController
    {
        private CameraView _cameraView;
        private CameraModel _cameraModel;
        private Camera _mainCamera;

        public CameraController(CameraModel model)
        {
            _cameraModel = model;
            _mainCamera = Object.FindAnyObjectByType<Camera>();
            _cameraView = _mainCamera.GetComponent<CameraView>();
            UpdateManager.SubscribeToUpdate(MoveCamera);
            _mainCamera.transform.position = _cameraView.StartPointForGameCamera.position;
            _mainCamera.transform.rotation = _cameraView.StartPointForGameCamera.rotation;
        }

        private void MoveCamera()
        {
            if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - _cameraModel.PanBorderThickness)
            {
                _mainCamera.transform.Translate(Vector3.forward * _cameraModel.CameraSpeed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= _cameraModel.PanBorderThickness)
            {
                _mainCamera.transform.Translate(Vector3.back * _cameraModel.CameraSpeed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - _cameraModel.PanBorderThickness)
            {
                _mainCamera.transform.Translate(Vector3.right * _cameraModel.CameraSpeed * Time.deltaTime, Space.World);
            }

            if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= _cameraModel.PanBorderThickness)
            {
                _mainCamera.transform.Translate(Vector3.left * _cameraModel.CameraSpeed * Time.deltaTime, Space.World);
            }

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            Vector3 position = _mainCamera.transform.position;
            position.y -= scroll * 1000 * _cameraModel.ScrollSpeed * Time.deltaTime;
            position.y = Mathf.Clamp(position.y, _cameraModel.MinY, _cameraModel.MaxY);
            _mainCamera.transform.position = position;
        }

        protected override void OnDispose()
        {
            UpdateManager.UnsubscribeFromUpdate(MoveCamera);
        }
    }
}
