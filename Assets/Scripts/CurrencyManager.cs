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

    public bool removeMonsterCurrency(ulong monsterCurrencyToRemove)
    {
        if (this.monsterCurrency < monsterCurrencyToRemove) return false;
        this.monsterCurrency -= monsterCurrencyToRemove;
        return true;
    }

    #endregion

    #region SupermarketCurrency
    public void addSupermarketCurrency(ulong supermarketCurrencyToAdd)
    {
        this.supermarketCurrency += supermarketCurrencyToAdd;
    }

    public bool removeSupermarketCurrency(ulong supermarketCurrencyToRemove)
    {
        if (this.supermarketCurrency < supermarketCurrencyToRemove) return false;
        this.supermarketCurrency -= supermarketCurrencyToRemove;
        return true;
    }

    #endregion
}
