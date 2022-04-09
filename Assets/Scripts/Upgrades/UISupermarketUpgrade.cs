using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISupermarketUpgrade : MonoBehaviour
{
    public SupermarketUpgrade upgrade;
    [SerializeField] private Text _NameText;
    [SerializeField] private Text _CostText;
    [SerializeField] private Text _BuffText;
    [SerializeField] private Text _LevelText;

    [SerializeField] private Image image;
    public void buyUpgrade()
    {
        this.upgrade = UpgradesManager.Instance.buyUpgrade(upgrade);
        updateText();
    }
    private void updateText()
    {
        _NameText.text = upgrade.name;
        _CostText.text = Mathf.CeilToInt(upgrade.cost).ToString() + "SP";
        _BuffText.text = upgrade.moneyFlat > 0 ? '+' + upgrade.moneyFlat.ToString() : 'x' + upgrade.moneyMultiplier.ToString();
        _LevelText.text = "lvl." + upgrade.level.ToString();
    }

    private void Awake()
    {
        _NameText = this.transform.Find("Name").GetComponent<Text>();
        _CostText = this.transform.Find("Cost").GetComponent<Text>();
        _BuffText = this.transform.Find("Buff").GetComponent<Text>();
        _LevelText = this.transform.Find("Level").GetComponent<Text>();
        image = this.transform.Find("Image").GetComponent<Image>();
        updateText();
        image.sprite = upgrade.Sprite;
        image.SetNativeSize();
    }
}
