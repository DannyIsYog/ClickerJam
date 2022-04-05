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

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void dealDamage(ulong damage)
    {
        this.health -= damage;
        if (this.health == 0)
        {
            CurrencyManager.Instance.addMonsterCurrency(currencyDrop);
            EnemiesManager.Instance.removeFirstInLine();
            Destroy(gameObject);
        }
    }
}
