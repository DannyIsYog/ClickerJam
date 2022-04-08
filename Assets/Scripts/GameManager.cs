using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int scene;
    // Start is called before the first frame update
    void Start()
    {
        this.scene = 0;
    }

    public void changeScene()
    {
        //if in dungeon, load supermarket
        if (scene == 0)
        {
            SceneManager.LoadScene("Supermarket");
            scene = 1;
        }
        else
        {
            SceneManager.LoadScene("Dungeon");
            scene = 0;
        }
    }
}
