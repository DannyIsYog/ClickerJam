using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ulong health;
    [SerializeField] ulong currencyDrop;

    // Start is called before the first frame update
    void Start()
    {
        int level = EnemiesManager.Instance.level;
        bool isBoss = EnemiesManager.Instance.isEnemyInFrontBoss();

        //Calculate Health
        float a = Mathf.Pow(1.55f, level - 1);
        this.health = (ulong)10 * (ulong)(level - 1 + Mathf.Pow(1.55f, level - 1));
        if (isBoss) this.health *= 10;

        //Calculate currencyDrop
        this.currencyDrop = this.health / 10;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void dealDamage(ulong damage)
    {
        this.health -= damage;
        if (this.health == 0) die();
    }

    void die()
    {
        CurrencyManager.Instance.addMonsterCurrency(currencyDrop);
        EnemiesManager.Instance.removeFirstInLine();
        Destroy(gameObject);
    }
}
