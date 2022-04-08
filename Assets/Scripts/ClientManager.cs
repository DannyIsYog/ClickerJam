using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientManager : MonoBehaviour
{   
    [SerializeField] GameObject customer;
    [SerializeField] List<GameObject> customerPositions;
    [SerializeField] GameObject firstCustomer;
    [SerializeField] GameObject secondCustomer;
    [SerializeField] List<Sprite> customersSprites;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void createCustomer(){
        this.firstCustomer = Instantiate(this.customer,this.customerPositions[0].transform);
        this.firstCustomer.GetComponent<SpriteRenderer>().sprite = this.customersSprites[0];
        this.firstCustomer.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    void move1(){
        this.firstCustomer.transform.position = this.customerPositions[1].transform.position;
    }

    void switchCustomer(){
        this.secondCustomer = firstCustomer;
        createCustomer();
    }

    public void moveLine(){
        if (firstCustomer == null){
            createCustomer();
        }
        else if (firstCustomer != null && secondCustomer == null){
            move1();
            switchCustomer();
        }
        else{
            move1();
            Destroy(secondCustomer.gameObject,.5f);
            switchCustomer();
        }
    }
}
