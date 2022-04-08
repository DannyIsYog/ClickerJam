using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientManager : MonoBehaviour
{
    [SerializeField] GameObject customer;
    [SerializeField] List<GameObject> customerPositions;
    [SerializeField] GameObject firstCustomer;
    [SerializeField] GameObject secondCustomer;
    [SerializeField] GameObject chatBubble;
    [SerializeField] List<string> DialogueOptions;
    [SerializeField] List<Sprite> customersSprites;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void createCustomer()
    {
        this.firstCustomer = Instantiate(this.customer, this.customerPositions[0].transform);
        int spriteNum = Random.Range(0, customersSprites.Count);
        int dialogueNum = Random.Range(0, DialogueOptions.Count);
        this.chatBubble.GetComponent<chatBubble>().writeText(DialogueOptions[dialogueNum]);
        this.firstCustomer.GetComponent<SpriteRenderer>().sprite = this.customersSprites[spriteNum];
    }

    void move1()
    {
        this.firstCustomer.transform.position = this.customerPositions[1].transform.position;
        this.chatBubble.GetComponent<chatBubble>().clearText();
    }

    void switchCustomer()
    {
        this.secondCustomer = firstCustomer;
        createCustomer();
    }

    public void moveLine()
    {
        if (firstCustomer == null)
        {
            createCustomer();
        }
        else if (firstCustomer != null && secondCustomer == null)
        {
            move1();
            switchCustomer();
        }
        else
        {
            Destroy(secondCustomer.gameObject, 0f);
            move1();
            switchCustomer();
        }
    }
}
