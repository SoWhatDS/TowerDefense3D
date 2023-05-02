using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField] private Color _hoverColor;
    [SerializeField] private Vector3 _positionOffSet;

    [Header("Optional")]
    public GameObject _turret;

    private Renderer _rend;
    private Color _startColor;

    private BuildManager _buildManager;

    private void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
        _buildManager = BuildManager.Instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + _positionOffSet;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!_buildManager.CanBuild)
        {
            return;
        }
        if (_turret != null)
        {
            Debug.Log("Can't build there - TODO: Display on screen");
            return;
        }

        _buildManager.BuildTurretOn(this);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!_buildManager.CanBuild)
        {
            return;
        }
        _rend.material.color = _hoverColor;
    }

    private void OnMouseExit()
    {
        _rend.material.color = _startColor;
    }
}
