using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{   
    [SerializeField] GameObject clientCart;
    [SerializeField] ClientCart currentCart;
    [SerializeField] GameObject ClientManager;
    [SerializeField] int maxClicks;
    [SerializeField] int maxMoney;
    [SerializeField] GameObject firstPosition;
    [SerializeField] GameObject item;

    private Vector2 move = new Vector2(-50,0);
    // Start is called before the first frame update
    void Start()
    {
        createEntity();
        this.ClientManager.GetComponent<ClientManager>().moveLine();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void createEntity(){
        int clicks = Random.Range(1,maxClicks);
        int money = Random.Range(1,maxMoney);
        this.currentCart = Instantiate(clientCart,firstPosition.transform).GetComponent<ClientCart>();
        this.currentCart.setClicks(clicks);
        this.currentCart.setSupermarketCurrency(money);
    }

    public void buttonClicked(){
        //Change sprites as the player clicks the button
        if(this.currentCart.getClicks() == this.currentCart.getTotalNumberClicks() +1){
            this.currentCart.oneClick();
            this.ClientManager.GetComponent<ClientManager>().moveLine();
            this.currentCart.GetComponent<Rigidbody2D>().AddForce(move,ForceMode2D.Impulse);
            CurrencyManager.instance.addSupermarketCurrency((ulong) currentCart.getSupermarketCurrency());
            Destroy(currentCart.gameObject,.5f);
            Invoke("createEntity",1f);
            
        }
        else if (this.currentCart.getClicks() > this.currentCart.getTotalNumberClicks()){
            Sprite sprite = this.currentCart.getRandomSprite();
            SpriteRenderer spriteRenderer = Instantiate(item,firstPosition.transform).GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
            spriteRenderer.gameObject.GetComponent<Rigidbody2D>().AddForce(move,ForceMode2D.Impulse);
            Destroy(spriteRenderer.gameObject,1f);
            this.currentCart.oneClick();
        }
    }

}
