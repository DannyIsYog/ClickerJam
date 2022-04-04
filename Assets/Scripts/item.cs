using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    [SerializeField] int speed;
    bool moving = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            //move
            transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }

    void move()
    {
        moving = !moving;
    }
}
