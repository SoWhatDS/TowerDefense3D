using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{

    public GameObject UI;
    private Node _target;
    public TMP_Text upgradeCost;
    public TMP_Text sellAmount;
    public Button upgradeButton;
    

    public void SetTarget(Node target)
    {
       _target = target;

        transform.position = _target.GetBuildPosition();

        if (!_target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBluePrint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeButton.interactable = false;
            upgradeCost.text = "DONE";
        }

        sellAmount.text = "$" + target.turretBluePrint.GetSellAmount();

        UI.SetActive(true);
    }

    public void Hide()
    {
        UI.SetActive(false);
    }

    public void Upgrade()
    {
        _target.UpgradeTurret();
        BuildManager.Instance.DeselectNode();
    }

    public void Sell()
    {
        _target.SellTurret();
        BuildManager.Instance.DeselectNode();
    }
}
