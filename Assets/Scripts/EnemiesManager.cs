using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] List<GameObject> queue;
    [SerializeField] List<GameObject> enemiesList;

    [SerializeField] List<GameObject> spawnPoints;

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
    void Start()
    {
        queue = new List<GameObject>();
        foreach (GameObject spawnPoint in spawnPoints)
            queue.Add(Instantiate(enemiesList[Random.Range(0, enemiesList.Count)], spawnPoint.transform));

    }

    void spawnEntity()
    {
        queue.Add(Instantiate(enemiesList[Random.Range(0, enemiesList.Count)], spawnPoints[spawnPoints.Count - 1].transform));
    }

    public void removeFirstInLine()
    {
        queue.RemoveAt(0);
        queue[0].transform.position = spawnPoints[0].transform.position;
        spawnEntity();
    }

    public void damageFirstInLine()
    {
        PlayerManager.Instance.dealDamage(queue[0].GetComponent<Enemy>());
    }
}
