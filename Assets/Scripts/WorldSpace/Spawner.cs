using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemyController enemyControl;
    [SerializeField] private GameObject objectToSpawn;

    public void SpawnEnemy()
    {
        Instantiate(objectToSpawn, gameObject.transform);
    }
}
