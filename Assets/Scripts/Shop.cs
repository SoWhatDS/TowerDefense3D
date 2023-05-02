using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;


    private void Start()
    {
        buildManager = BuildManager.Instance;
    }
    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard Turret Purchased ");
        buildManager.SetTurretToBuild(buildManager._standardTurretPrefab);
    }

    public void PurchaseMissileLauncher()
    {
        Debug.Log("Missile Launcher Purchased ");
        buildManager.SetTurretToBuild(buildManager._missileLauncherPrefab);
    }
}
