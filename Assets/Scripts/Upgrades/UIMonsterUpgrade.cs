using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIMonsterUpgrade : MonoBehaviour
{
    public MonsterUpgrade upgrade;
    [SerializeField] private Text _buttonText;

    [SerializeField] private Image image;
    public void buyUpgrade()
    {
        this.upgrade = UpgradesManager.Instance.buyUpgrade(upgrade);
        updateText();
    }


    private void updateText()
    {
        var _buttonText = gameObject.GetComponentInChildren<UnityEngine.UI.Text>();
        if (upgrade.damageFlat > 0)
            _buttonText.text = upgrade.upgradeName + "    lvl." + upgrade.level + "\n" + Mathf.CeilToInt(upgrade.cost) + "S    +" + upgrade.damageFlat.ToString() + "Atk";
        else
            _buttonText.text = upgrade.upgradeName + "    lvl." + upgrade.level + "\n" + Mathf.CeilToInt(upgrade.cost) + "S    x" + upgrade.damageMultiplier.ToString() + "Atk";

    }

    private void Awake()
    {
        updateText();
        image.sprite = upgrade.Sprite;
        image.SetNativeSize();
    }
}
