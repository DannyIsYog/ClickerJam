using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class chatBubble : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject textMeshPro;
    [SerializeField] GameObject speechBubbleObj;
    [SerializeField] Sprite speechBubbleSprite;

    private void start(){
    }
    public void writeText(string text){
        speechBubbleObj.GetComponent<SpriteRenderer>().sprite = speechBubbleSprite;
        textMeshPro.GetComponent<TextMeshPro>().SetText(text);
    }

    public void clearText(){
        speechBubbleObj.GetComponent<SpriteRenderer>().sprite = null;
        textMeshPro.GetComponent<TextMeshPro>().SetText("");
    }

}
