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

    public void PurchaseAnotherTurret()
    {
        Debug.Log("Another Turret Purchased ");
        buildManager.SetTurretToBuild(buildManager._anotherTurretPrefab);
    }
}
