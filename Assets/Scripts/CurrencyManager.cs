using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance { get; private set; }
    [SerializeField] ulong monsterCurrency;
    [SerializeField] ulong supermarketCurrency;

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


    #region MonsterCurrency
    public void addMonsterCurrency(ulong monsterCurrencyToAdd)
    {
        this.monsterCurrency += monsterCurrencyToAdd;
    }

    public void removeMonsterCurrency(ulong monsterCurrencyToRemove)
    {
        this.monsterCurrency += monsterCurrencyToRemove;
    }

    #endregion

    #region SupermarketCurrency
    public void addSupermarketCurrency(ulong supermarketCurrencyToAdd)
    {
        this.supermarketCurrency += supermarketCurrencyToAdd;
    }

    public void removeSupermarketCurrency(ulong supermarketCurrencyToRemove)
    {
        this.supermarketCurrency += supermarketCurrencyToRemove;
    }

    #endregion
}
