using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private List<Spawner> spawnerList = new List<Spawner>();
    [SerializeField] private float delayReset;
    [SerializeField] private TMP_Text enemyCountText;

    private float delay;
    private bool canSpawn;
    private int enemyCount = 0;

    private void Start()
    {
        foreach (Spawner spawner in spawnerList)
        {
            spawner.SpawnEnemy();
        }
    }

    private void Update()
    {
        if (canSpawn)
        {
            Spawn();
        }

        delay -= Time.deltaTime;

        if (delay <= 0)
        {
            canSpawn = true;
            delay = delayReset;
        }
    }

    private void Spawn()
    {
        int randomInt = Random.Range(0, spawnerList.Count - 1);
        spawnerList[randomInt].SpawnEnemy();
        canSpawn = false;
    }

    public void AddCount()
    {
        enemyCount++;
        enemyCountText.text = enemyCount.ToString();

        if (enemyCount >= 10 && enemyCount < 20)
        {
            delay = 10;
        }
        else if (enemyCount >= 20)
        {
            delay = 5;
        }
    }
}
