using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISupermarketUpgrade : MonoBehaviour
{
    public SupermarketUpgrade upgrade;
    [SerializeField] private Text _buttonText;
    public void buyUpgrade()
    {
        this.upgrade = UpgradesManager.Instance.buyUpgrade(upgrade);
        updateText();
    }
    private void updateText()
    {
        var _buttonText = gameObject.GetComponentInChildren<UnityEngine.UI.Text>();
        if (upgrade.moneyFlat > 0)
            _buttonText.text = upgrade.upgradeName + "    lvl." + upgrade.level + "\n" + Mathf.CeilToInt(upgrade.cost) + "M    +" + upgrade.moneyFlat.ToString() + "Money";
        else
            _buttonText.text = upgrade.upgradeName + "    lvl." + upgrade.level + "\n" + Mathf.CeilToInt(upgrade.cost) + "M    x" + upgrade.moneyMultiplier.ToString() + "Money";

    }

    private void Awake()
    {
        updateText();
    }
}
