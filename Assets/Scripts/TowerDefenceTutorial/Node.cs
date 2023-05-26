using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField] private Color hoverColor;
    [SerializeField] private Color notEnoughMoney;
    [SerializeField] private Vector3 _positionOffSet;

    [Header("Optional")]
    public GameObject _turret;
    public TurretBluePrint turretBluePrint;
    public bool isUpgraded = false;

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
        if (_turret != null)
        {
            _buildManager.SelectNode(this);
            return;
        }
        if (!_buildManager.CanBuild)
        {
            return;
        }

        BuildTurret(_buildManager.GetTurretToBuild());
    }

    private void BuildTurret(TurretBluePrint bluePrint)
    {
        if (PlayerStats.Money < bluePrint._cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= bluePrint._cost;
        GameObject turret = (GameObject)Instantiate(bluePrint._prefab, GetBuildPosition(), Quaternion.identity);
        _turret = turret;
        turretBluePrint = bluePrint;
        GameObject effect = (GameObject)Instantiate(_buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
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
        if (_buildManager.HasMoney)
        {
            _rend.material.color = hoverColor;
        }
        else
        {
            _rend.material.color = notEnoughMoney;
        }
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBluePrint.upgradeCost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= turretBluePrint.upgradeCost;
        Destroy(_turret);
        GameObject turret = (GameObject)Instantiate(turretBluePrint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        _turret = turret;
        GameObject effect = (GameObject)Instantiate(_buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBluePrint.GetSellAmount();
        Destroy(_turret);

        GameObject effect = (GameObject)Instantiate(_buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        turretBluePrint = null;
    }

    private void OnMouseExit()
    {
        _rend.material.color = _startColor;
    }
}
