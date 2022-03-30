using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnSpots;
    public GameObject enemy;
    private int randomSpawnSpot;
    private Transform enemyPosition;
    private int x = 0;
    public float secondsBetweenSpawn = 3.0f;
    public float elapsedTime = 0.0f;
    void Start()
    {
        randomSpawnSpot = Random.Range(0, spawnSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        EnemySpawn();
        elapsedTime += Time.deltaTime;
    }

    void EnemySpawn()
    {
        randomSpawnSpot = Random.Range(0, spawnSpots.Length);
        if (x < 5 && elapsedTime > secondsBetweenSpawn)
        {
            elapsedTime = 0;
            Instantiate(enemy, spawnSpots[randomSpawnSpot].position, Quaternion.identity);
            x++;
        }
    }
}
