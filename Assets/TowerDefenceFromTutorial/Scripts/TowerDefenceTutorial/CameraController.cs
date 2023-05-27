using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _panSpeed;
    [SerializeField] private float _panBorderThickness;
    [SerializeField] private float _scrollSpeed;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    private bool _isMovement = true;

    private void Update()
    {
        if (LivesManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - _panBorderThickness)
        {
            transform.Translate(Vector3.forward * _panSpeed * Time.deltaTime,Space.World);
        }

        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= _panBorderThickness)
        {
            transform.Translate(Vector3.back * _panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - _panBorderThickness)
        {
            transform.Translate(Vector3.right * _panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= _panBorderThickness)
        {
            transform.Translate(Vector3.left * _panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 position = transform.position;
        position.y -= scroll * 1000 * _scrollSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, minY, maxY);
        transform.position = position;


    }
}
