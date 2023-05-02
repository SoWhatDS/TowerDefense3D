using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;

    public GameObject _standardTurretPrefab;
    public GameObject _missileLauncherPrefab;

    private TurretBluePrint _turretToBuild;

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;
    }

    public bool CanBuild { get { return _turretToBuild != null; } }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < _turretToBuild._cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= _turretToBuild._cost;
        GameObject turret = (GameObject)Instantiate(_turretToBuild._prefab,node.GetBuildPosition(),Quaternion.identity);
        node._turret = turret;
        Debug.Log("Turret build! Money left: " + PlayerStats.Money);
    }

    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        _turretToBuild = turret;
    }

}
