using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject monsterCurrencyUI;
    public GameObject supermarketCurrencyUI;

    public GameObject dungeonUpgradeUI;

    public GameObject buttonDungeonUpgradeUI;

    public GameObject supermarketUpgradeUI;

    public GameObject buttonSupermarketUpgradeUI;

    public GameObject upgradesBackground;

    public GameObject changeSceneButton;
    public static GameObject Instance { get; private set; }
    public static CanvasManager managerInstace { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this.gameObject)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this.gameObject;
        }

        if (managerInstace != null && managerInstace != this)
        {
            Destroy(gameObject);
        }
        else
        {
            managerInstace = this;
        }
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(this);
    }

    public void firstEnemyDead()
    {
        monsterCurrencyUI.SetActive(true);
    }

    public void firstItemScan()
    {
        supermarketCurrencyUI.SetActive(true);
    }

    public void DungeonUpgrades()
    {
        dungeonUpgradeUI.SetActive(true);
        buttonDungeonUpgradeUI.SetActive(true);
        upgradesBackground.SetActive(true);
    }

    public void SupermarketUpgrades()
    {
        buttonSupermarketUpgradeUI.SetActive(true);
        if (upgradesBackground == null) upgradesBackground = GameObject.Find("Menu_Background");
        upgradesBackground.SetActive(true);
    }

    public void changeSceneActivate()
    {
        changeSceneButton.SetActive(true);
    }

}
