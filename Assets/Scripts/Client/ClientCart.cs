using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientCart : MonoBehaviour
{
    [SerializeField] ulong supermarketCurrency;
    [SerializeField] int clicks;
    [SerializeField] int totalNumberClicks = 0;
    [SerializeField] List<Sprite> sprites;

    public int currentPrice = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void setTotalNumberClicks(int totalNumberClicks)
    {
        this.totalNumberClicks = totalNumberClicks;
    }

    public void oneClick()
    {
        this.totalNumberClicks += 1;
    }

    public void setClicks(int clicks)
    {
        this.clicks = clicks;
    }

    public void setSupermarketCurrency(ulong supermarketCurrency)
    {
        this.supermarketCurrency = supermarketCurrency;
    }

    public ulong getSupermarketCurrency()
    {
        return this.supermarketCurrency;
    }
    public int getClicks()
    {
        return this.clicks;
    }

    public int getTotalNumberClicks()
    {
        return this.totalNumberClicks;
    }

    public Sprite getRandomSprite()
    {
        int spriteIndex = Random.Range(0, sprites.Count);
        return sprites[spriteIndex];
    }


}
