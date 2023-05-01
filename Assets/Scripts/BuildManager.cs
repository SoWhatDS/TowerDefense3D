using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;

    public GameObject _standardTurretPrefab;
    public GameObject _anotherTurretPrefab;

    private GameObject _turretToBuild;

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;
    }

    public GameObject GetTurretToBuild()
    {
        return _turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        _turretToBuild = turret;
    }

}
