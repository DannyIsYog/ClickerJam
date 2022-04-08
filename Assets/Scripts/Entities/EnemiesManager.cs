using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] List<GameObject> queue;
    [SerializeField] List<GameObject> enemiesList;

    [SerializeField] List<GameObject> spawnPoints = new List<GameObject>();

    [SerializeField] public int level;

    [SerializeField] int waveSize;

    [SerializeField] bool isBoss;

    public static EnemiesManager Instance { get; private set; }

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
    public void StartDungeon()
    {
        spawnPoints[0] = GameObject.Find("Front");
        spawnPoints[1] = GameObject.Find("2ndPlace");
        calculateWaveSize();
        queue = new List<GameObject>();
        GameObject enemy;
        int i = 1;
        foreach (GameObject spawnPoint in spawnPoints)
        {
            enemy = Instantiate(enemiesList[Random.Range(0, enemiesList.Count)], spawnPoint.transform);
            enemy.GetComponent<SpriteRenderer>().sortingOrder = i;
            queue.Add(enemy);
            waveSize--;
            i--;
        }
    }

    void handleWave()
    {
        GameObject enemy;
        if (waveSize == 0)
        {
            level++;
            calculateWaveSize();
        }
        if (waveSize == 1) this.isBoss = true;
        enemy = Instantiate(enemiesList[Random.Range(0, enemiesList.Count)], spawnPoints[spawnPoints.Count - 1].transform);
        enemy.GetComponent<SpriteRenderer>().sortingOrder = 0;
        queue.Add(enemy);
        waveSize--;

    }

    public void removeFirstInLine()
    {
        //Removes enemy from the queue
        queue.RemoveAt(0);

        //moves the enemy in the back to the front of the queue
        queue[0].transform.position = spawnPoints[0].transform.position;
        queue[0].GetComponent<SpriteRenderer>().sortingOrder = 1;

        handleWave();
    }

    public void damageFirstInLine()
    {
        PlayerManager.Instance.dealDamage(queue[0].GetComponent<Enemy>());
    }

    public bool isEnemyInFrontBoss()
    {
        if (!this.isBoss) return false;

        this.isBoss = false;
        return true;
    }

    void calculateWaveSize()
    {
        waveSize = Mathf.CeilToInt(10 * Mathf.Pow(1.1f, this.level));
    }
}
