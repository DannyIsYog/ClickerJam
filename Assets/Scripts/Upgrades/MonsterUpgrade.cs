using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "MonsterUpgrade", menuName = "Upgrades/MonsterUpgrade", order = 2)]
public class MonsterUpgrade : ScriptableObject
{
    public Sprite Sprite;
    public string upgradeName;
    public ulong damageMultiplier;
    public ulong damageFlat;
    public int level = 0;
    public float cost;
    public float growthCost;
}