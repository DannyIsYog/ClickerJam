using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    public MonsterUpgrade upgrade;

    public float cost = 0;

    public void buyUpgrade()
    {
        this.upgrade = UpgradesManager.Instance.buyUpgrade(upgrade);
        this.cost = this.upgrade.cost;
        Debug.Log(this.cost);
    }
}
