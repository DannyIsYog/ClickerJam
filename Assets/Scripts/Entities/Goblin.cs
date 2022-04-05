using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] ulong currencyDrop;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void dealDamage(int damage)
    {
        this.health -= damage;
        if (this.health < 0)
        {
            CurrencyManager.instance.addMonsterCurrency(currencyDrop);
            Destroy(gameObject);
        }
    }
}
