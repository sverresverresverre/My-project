using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    float timeToSpawn;

    [SerializeField]
    float timeToStop;
    
    [SerializeField]
    float timeSinceStart = 0;

    void Start()
    {

    }

    void Update()
    {
        timeSinceStart += Time.deltaTime;

        if (timeSinceStart > timeToSpawn)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }

        if (timeSinceStart > timeToStop)
        {
            timeToSpawn = 99999;
        }
    }
}
