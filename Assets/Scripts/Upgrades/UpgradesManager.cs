using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UpgradesManager : MonoBehaviour
{
    Dictionary<string, SupermarketUpgrade> supermarketUpgrades = new Dictionary<string, SupermarketUpgrade>();
    Dictionary<string, MonsterUpgrade> monsterUpgrades = new Dictionary<string, MonsterUpgrade>();
    public static UpgradesManager Instance { get; private set; }

    public GameObject supermarketMenuUI;
    public GameObject dungeonMenuUI;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    public SupermarketUpgrade buyUpgrade(SupermarketUpgrade upgrade)
    {

        string upgradeName = upgrade.upgradeName;

        //Verifies if the upgrade is already registered, if not register it
        if (!supermarketUpgrades.ContainsKey(upgradeName)) supermarketUpgrades[upgradeName] = upgrade;
        upgrade = supermarketUpgrades[upgradeName];

        //Verifies if the player has enough money to buy the upgrade
        if (!CurrencyManager.Instance.removeMonsterCurrency((ulong)upgrade.cost)) return upgrade;

        //Applies upgrade
        //reference to item manager += upgrade.moneyFlat;
        //reference to item manager *= (upgrade.moneyMultiplier >= 1 ? upgrade.moneyMultiplier : 1);

        //Increase cost and level
        upgrade.level++;
        upgrade.cost *= upgrade.growthCost;
        Debug.Log(upgrade.cost);

        //update it on the dictionary
        supermarketUpgrades[upgradeName] = upgrade;
        return upgrade;
    }

    public MonsterUpgrade buyUpgrade(MonsterUpgrade upgrade)
    {

        string upgradeName = upgrade.upgradeName;

        //Verifies if the upgrade is already registered, if not register it
        if (!monsterUpgrades.ContainsKey(upgradeName)) monsterUpgrades[upgradeName] = upgrade;
        upgrade = monsterUpgrades[upgradeName];

        //Verifies if the player has enough money to buy the upgrade
        if (!CurrencyManager.Instance.removeSupermarketCurrency((ulong)upgrade.cost)) return upgrade;

        //Applies upgrade
        PlayerManager.Instance.damage += upgrade.damageFlat;
        PlayerManager.Instance.damage *= (upgrade.damageMultiplier >= 1 ? upgrade.damageMultiplier : 1);

        //Increase cost and level
        upgrade.level++;
        upgrade.cost *= upgrade.growthCost;

        //update it on the dictionary
        monsterUpgrades[upgradeName] = upgrade;
        return upgrade;
    }

    public void changeDungeonUI()
    {
        dungeonMenuUI.SetActive(true);
        supermarketMenuUI.SetActive(false);
    }

    public void changeSupermarketUI()
    {
        supermarketMenuUI.SetActive(true);
        dungeonMenuUI.SetActive(false);
    }

    public ulong getMoneyUpgrade(ulong init)
    {
        ulong add = 1;
        ulong mult = 1;
        foreach (KeyValuePair<string, SupermarketUpgrade> spUpgrade in supermarketUpgrades)
        {
            add += spUpgrade.Value.moneyFlat;
            if (spUpgrade.Value.moneyMultiplier > 0) mult += spUpgrade.Value.moneyMultiplier;
        }

        return (init + add) * mult;
    }
}