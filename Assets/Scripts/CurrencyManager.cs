using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance { get; private set; }
    [SerializeField] ulong monsterCurrency;
    [SerializeField] ulong supermarketCurrency;

    [SerializeField] private Text _monsterCurrencyText;
    [SerializeField] private Text _supermarketCurrencyText;

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
        updateUI();
    }

    public void addMonsterCurrency(ulong monsterCurrencyToAdd)
    {
        this.monsterCurrency += monsterCurrencyToAdd;
        updateUI();
    }

    public bool removeMonsterCurrency(ulong monsterCurrencyToRemove)
    {
        if (this.monsterCurrency < monsterCurrencyToRemove) return false;
        this.monsterCurrency -= monsterCurrencyToRemove;
        updateUI();
        return true;
    }

    public void addSupermarketCurrency(ulong supermarketCurrencyToAdd)
    {
        this.supermarketCurrency += supermarketCurrencyToAdd;
        updateUI();
    }

    public bool removeSupermarketCurrency(ulong supermarketCurrencyToRemove)
    {
        if (this.supermarketCurrency < supermarketCurrencyToRemove) return false;
        this.supermarketCurrency -= supermarketCurrencyToRemove;
        updateUI();
        return true;
    }
    void updateUI()
    {
        this._monsterCurrencyText.text = monsterCurrency.ToString() + "M";
        this._supermarketCurrencyText.text = supermarketCurrency.ToString() + "S";
    }


}
