using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMonsterUpgrade : MonoBehaviour
{
    public MonsterUpgrade upgrade;

    public void buyUpgrade()
    {
        this.upgrade = UpgradesManager.Instance.buyUpgrade(upgrade);
    }
}
