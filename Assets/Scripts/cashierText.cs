using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cashierText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Canvas.ForceUpdateCanvases();

        gameObject.GetComponent<ScrollRect>().verticalNormalizedPosition = 0f;

        Canvas.ForceUpdateCanvases();

    }
}
