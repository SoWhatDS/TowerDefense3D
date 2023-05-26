using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;

    public NodeUI nodeUI;

    public GameObject buildEffect;
    public GameObject sellEffect;

    private TurretBluePrint _turretToBuild;
    private Node _selectedNode;

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;
    }

    public bool CanBuild { get { return _turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= _turretToBuild._cost; } }

    public void SelectNode(Node node)
    {
        if (_selectedNode == node)
        {
            DeselectNode();
        }
        _selectedNode = node;
        _turretToBuild = null;
        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        _selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        _turretToBuild = turret;
        DeselectNode();
    }

    public TurretBluePrint GetTurretToBuild()
    {
        return _turretToBuild;
    }

}
