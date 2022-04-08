using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SupermarketUpgrade", menuName = "Upgrades/SupermarketUpgrade", order = 1)]
public class SupermarketUpgrade : ScriptableObject
{
    public Sprite Sprite;
    public string upgradeName;
    public ulong moneyMultiplier;
    public ulong moneyFlat;
    [HideInInspector] public int level = 0;
    public float cost;
    public float growthCost;
}
