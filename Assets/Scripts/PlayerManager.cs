using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    public ulong damage;

    public int scene;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void dealDamage(Enemy enemy)
    {
        enemy.dealDamage(damage);
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
