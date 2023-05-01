using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField] private Color _hoverColor;
    [SerializeField] private Vector3 _positionOffSet;

    private GameObject _turret;
    private Renderer _rend;
    private Color _startColor;

    private BuildManager _buildManager;

    private void Start()
    {
        _rend = GetComponent<Renderer>();
        _startColor = _rend.material.color;
        _buildManager = BuildManager.Instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (_buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        if (_turret != null)
        {
            Debug.Log("Can't build there - TODO: Display on screen");
            return;
        }

        GameObject turretToBuild = BuildManager.Instance.GetTurretToBuild();
        _turret = (GameObject)Instantiate(turretToBuild, transform.position + _positionOffSet, transform.rotation);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (_buildManager.GetTurretToBuild() == null)
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
