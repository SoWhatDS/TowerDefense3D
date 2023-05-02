using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint _standardTurret;
    public TurretBluePrint _missileLauncher;

    BuildManager buildManager;


    private void Start()
    {
        buildManager = BuildManager.Instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Purchased ");
        buildManager.SelectTurretToBuild(_standardTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher Purchased ");
        buildManager.SelectTurretToBuild(_missileLauncher);
    }
}
