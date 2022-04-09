using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] GameObject clientCart;
    [SerializeField] ClientCart currentCart;
    [SerializeField] GameObject ClientManager;
    [SerializeField] int minClicks = 2;
    [SerializeField] int maxClicks = 50;
    [SerializeField] ulong maxMoney = 1;
    [SerializeField] ulong minMoney = 10;

    [SerializeField] GameObject firstPosition;
    [SerializeField] GameObject item;

    [SerializeField] GameObject conveyorLights;
    [SerializeField] GameObject buttonLights;

    [SerializeField] TextMeshProUGUI listOfItemsText;

    [SerializeField] TextMeshProUGUI priceText;

    Queue<string> listOfItems = new Queue<string>();

    private Vector2 move = new Vector2(-50, 0);
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

    private void createEntity()
    {
        int clicks = Random.Range(minClicks, maxClicks);
        ulong money = UpgradesManager.Instance.getMoneyUpgrade((ulong)(Mathf.CeilToInt(Random.Range(minMoney, maxMoney)) * Mathf.CeilToInt(clicks / 10)));
        this.currentCart = Instantiate(clientCart, firstPosition.transform).GetComponent<ClientCart>();
        this.currentCart.setClicks(clicks);
        this.currentCart.setSupermarketCurrency(money);
    }

    public void buttonClicked()
    {
        //Change sprites as the player clicks the button
        if (this.currentCart.getClicks() == this.currentCart.getTotalNumberClicks() + 1)
        {
            this.currentCart.oneClick();
            this.ClientManager.GetComponent<ClientManager>().moveLine();
            this.currentCart.GetComponent<Rigidbody2D>().AddForce(move, ForceMode2D.Impulse);
            CurrencyManager.Instance.addSupermarketCurrency(currentCart.getSupermarketCurrency());
            AudioManager.instance.Play("cashier_bip");
            Destroy(currentCart.gameObject, .5f);
            flashLight();
            CanvasManager.managerInstace.SupermarketUpgrades();
            CanvasManager.managerInstace.firstItemScan();
            Invoke("createEntity", 1f);
            resetScanText();
        }
        else if (this.currentCart.getClicks() > this.currentCart.getTotalNumberClicks())
        {
            Sprite sprite = this.currentCart.getRandomSprite();
            SpriteRenderer spriteRenderer = Instantiate(item, firstPosition.transform).GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
            spriteRenderer.sortingOrder = 3;

            listOfItems.Enqueue(spriteRenderer.sprite.name + "\n");
            buildScanText();

            int iteamPrice = Random.Range(1, ((int)this.currentCart.getSupermarketCurrency() - this.currentCart.currentPrice) / this.currentCart.getClicks());
            this.currentCart.currentPrice += iteamPrice;
            priceText.text = this.currentCart.currentPrice + "SD";


            spriteRenderer.gameObject.GetComponent<Rigidbody2D>().AddForce(move, ForceMode2D.Impulse);
            AudioManager.instance.Play("cashier_bip");
            flashLight();
            Destroy(spriteRenderer.gameObject, 1f);
            this.currentCart.oneClick();
        }
    }

    public void flashLight()
    {
        if (conveyorLights.activeSelf) conveyorLights.SetActive(false);
        else conveyorLights.SetActive(true);

        if (buttonLights.activeSelf) buttonLights.SetActive(false);
        else buttonLights.SetActive(true);
    }

    public void buildScanText()
    {
        string text = "";

        if (listOfItems.Count >= 10)
        {
            listOfItems.Dequeue();
        }

        foreach (var item in listOfItems)
        {
            text += item;
        }
        listOfItemsText.text = text;
    }

    public void resetScanText()
    {
        listOfItemsText.text = "";
        listOfItems.Clear();
    }

}
