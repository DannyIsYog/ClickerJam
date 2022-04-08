using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static GameObject Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this.gameObject)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this.gameObject;
        }
        DontDestroyOnLoad(gameObject);
    }

}
